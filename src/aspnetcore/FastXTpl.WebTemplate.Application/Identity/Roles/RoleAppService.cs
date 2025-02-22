using FastX.Application.Services;
using FastX.Authorization.Permissions.Abstractions;
using FastX.Data.Repository;
using FastXTpl.WebTemplate.Application.Identity.Roles.Dtos;
using FastXTpl.WebTemplate.Core.Identity.Roles;
using Microsoft.AspNetCore.Authorization;

namespace FastXTpl.WebTemplate.Application.Identity.Roles;

/// <summary>
/// 角色管理
/// </summary>
[Authorize]
public class RoleAppService : CrudAppService<Role, string, RoleDto, GetRoleListInput>, IRoleAppService
{
    private readonly IPermissionDefinitionManager _permissionDefinitionManager;
    private readonly IRepository<RolePermission> _rolePermissionRepository;

    /// <summary>
    /// 角色管理
    /// </summary>
    public RoleAppService(IRepository<Role> repository, IPermissionDefinitionManager permissionDefinitionManager, IRepository<RolePermission> rolePermissionRepository) : base(repository)
    {
        _permissionDefinitionManager = permissionDefinitionManager;
        _rolePermissionRepository = rolePermissionRepository;
    }

    /// <summary>
    /// 获取全部
    /// </summary>
    /// <returns></returns>
    public async Task<List<RoleDto>> GetAllAsync()
    {
        var roles = await Repository.GetListAsync();
        return await MapToEntityDtoList(roles);
    }

    public override async Task<RoleDto> InsertOrUpdateAsync(RoleDto input)
    {
        var entity = await MapCreateDtoToEntity(input);
        entity = await Repository.InsertOrUpdateAsync(entity);

        var rolePermissions = await _rolePermissionRepository.GetListAsync(p => p.RoleId == entity.RoleId);
        await Task.WhenAll(rolePermissions.Select(async t =>
        {
            if (input.RolePermissions.All(p => p != t.Name))
                await _rolePermissionRepository.DeleteAsync(t);
        }));

        await Task.WhenAll(input.RolePermissions.Select(async t =>
        {
            var rolePermission = await _rolePermissionRepository.GetAsync(p => p.RoleId == entity.RoleId && p.Name == t);
            if (rolePermission == null)
                await _rolePermissionRepository.InsertAsync(new RolePermission()
                {
                    Name = t,
                    RoleId = entity.RoleId
                });
        }));

        return await MapToEntityDto(entity);
    }

    /// <summary>
    /// 获取全部权限
    /// </summary>
    /// <returns></returns>
    public async Task<List<PermissionDto>> GetListPermissionAsync(string roleId)
    {
        var rolePermissions = await _rolePermissionRepository.GetListAsync(p => p.RoleId == roleId);

        var permissions = _permissionDefinitionManager.GetPermissions();
        return permissions.Select(t => new PermissionDto()
        {
            Name = t.Name,
            DisplayName = t.DisplayName,
            Parent = t.Parent?.Name,
            IsSelected = rolePermissions.Any(p => p.Name == t.Name)
        }).ToList();
    }

    protected override async Task<RoleDto> MapToEntityDto(Role entity)
    {
        var roleDto = await base.MapToEntityDto(entity);

        var rolePermissions = await _rolePermissionRepository.GetListAsync(p => p.RoleId == roleDto.RoleId);
        roleDto.RolePermissions = rolePermissions.Select(t => t.Name).ToList();

        return roleDto;
    }
}