using FastXTpl.Template.Application.Identity.Roles.Dtos;

namespace FastXTpl.Template.Application.Identity.Roles;

/// <summary>
/// 角色管理
/// </summary>
public interface IRoleAppService
{
    /// <summary>
    /// 获取全部
    /// </summary>
    /// <returns></returns>
    Task<List<RoleDto>> GetAllAsync();

    /// <summary>
    /// 获取全部权限
    /// </summary>
    /// <returns></returns>
    Task<List<PermissionDto>> GetListPermissionAsync(string roleId);
}