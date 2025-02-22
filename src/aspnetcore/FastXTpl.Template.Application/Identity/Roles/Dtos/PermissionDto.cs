namespace FastXTpl.Template.Application.Identity.Roles.Dtos;

public class PermissionDto
{
    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 显示名称
    /// </summary>
    public string DisplayName { get; set; }

    /// <summary>
    /// 父级名称
    /// </summary>
    public string?  Parent { get; set; }

    /// <summary>
    /// 是否选中
    /// </summary>
    public bool IsSelected { get; set; }
}