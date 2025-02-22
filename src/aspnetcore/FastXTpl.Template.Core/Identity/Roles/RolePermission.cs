using System.ComponentModel.DataAnnotations;
using FastX.Data.Entities;
using FastX.Data.SqlSugar.DataAnnotations;

namespace FastXTpl.Template.Core.Identity.Roles;

/// <summary>
/// 角色权限
/// </summary>
[XSugarTable("Identity")]
public class RolePermission : Entity
{
    /// <summary>
    /// 角色Id
    /// </summary>
    [Key]
    public Ulid RoleId { get; set; }

    /// <summary>
    /// 权限名称
    /// </summary>
    [Key]
    public string Name { get; set; }
}