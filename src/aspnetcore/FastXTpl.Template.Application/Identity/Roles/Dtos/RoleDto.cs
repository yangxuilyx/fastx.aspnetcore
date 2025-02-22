namespace FastXTpl.Template.Application.Identity.Roles.Dtos;

/// <summary>
/// 角色
/// </summary>
public class RoleDto
{
    /// <summary>
    /// 角色Id
    /// </summary>

    public string RoleId { get; set; }

    /// <summary>
    /// 角色名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 角色描述
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// 角色权限
    /// </summary>
    public List<string> RolePermissions { get; set; }
}