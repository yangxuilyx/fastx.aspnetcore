using FastX;
using FastX.Application.Services;
using FastX.Data.Repository;
using FastXTpl.WebTemplate.Application.Identity.Users.Dtos;
using FastXTpl.WebTemplate.Core.Identity.Users;
using Microsoft.AspNetCore.Authorization;

namespace FastXTpl.WebTemplate.Application.Identity.Users;

/// <summary>
/// 用户管理
/// </summary>
[Authorize]
public class UserAppService : CrudAppService<User, string, UserDto, GetUserListInput, CreateUserDto, UserDto>, IUserAppService
{
    private readonly UserManager _userManager;
    private readonly IRepository<UserRole> _userRoleRepository;

    /// <summary>
    /// 
    /// </summary>
    public UserAppService(IRepository<User> repository, UserManager userManager, IRepository<UserRole> userRoleRepository) : base(repository)
    {
        _userManager = userManager;
        _userRoleRepository = userRoleRepository;
    }

    /// <summary>
    /// 添加用户
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>

    public override async Task<UserDto> InsertAsync(CreateUserDto input)
    {
        var user = await _userManager.FindByNameAsync(input.UserName);
        if (user != null && user.UserId != input.UserId)
            throw new UserFriendlyException("用户名已存在");

        var entity = await MapCreateDtoToEntity(input);
        var createdUser = await _userManager.CreateUserAsync(entity);
        await UpdateUserRole(createdUser.UserId, input.Roles);

        return await MapToEntityDto(createdUser);
    }

    /// <summary>
    /// UpdateAsync
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public override async Task<UserDto> UpdateAsync(UserDto input)
    {
        var entity = await MapUpdateDtoToEntity(input);
        entity = await Repository.UpdateAsync(entity, p => p.Password);

        var userDto = await MapToEntityDto(entity);

        await UpdateUserRole(userDto.UserId, input.Roles);

        return userDto;
    }

    /// <summary>
    /// MapToEntityDto
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    protected override async Task<UserDto> MapToEntityDto(User entity)
    {
        var userDto = await base.MapToEntityDto(entity);

        var userRoles = await _userRoleRepository.GetListAsync(p => p.UserId == userDto.UserId);
        userDto.Roles = userRoles.ConvertAll(t => t.RoleId.ToString());
        return userDto;
    }

    private async Task UpdateUserRole(
        string userId,
        List<string> roles)
    {
        var userRoles = await _userRoleRepository.GetListAsync(p => p.UserId == userId);
        await Task.WhenAll(userRoles.Where(t => !roles.Contains(t.RoleId)).Select(async t =>
        {
            await _userRoleRepository.DeleteAsync(t);
        }));

        await Task.WhenAll(roles.Select(async t =>
        {
            if (await _userRoleRepository.GetAsync(p => p.UserId == userId && p.RoleId == t) == null)
                await _userRoleRepository.InsertAsync(new UserRole()
                {
                    UserId = userId,
                    RoleId = t
                });
        }));
    }

    /// <summary>
    /// 获取所有组织
    /// </summary>
    /// <returns></returns>
    public async Task<List<UserDto>> GetAllAsync()
    {
        var users = await Repository.GetListAsync();
        return await MapToEntityDtoList(users);
    }
}