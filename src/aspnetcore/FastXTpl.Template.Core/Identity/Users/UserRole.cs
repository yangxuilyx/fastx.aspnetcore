using FastX.Data.DataFilters;
using FastX.Data.Entities;
using System.ComponentModel.DataAnnotations;
using FastX.Data.SqlSugar.DataAnnotations;

namespace FastX.App.Core.Identity.Users;

/// <summary>
/// 用户角色
/// </summary>
[XSugarTable("Identity")]
public class UserRole : Entity
{
    /// <summary>
    /// 角色Id
    /// </summary>
    [Key]
    public Ulid RoleId { get; set; }

    /// <summary>
    /// UserId
    /// </summary>
    [Key]
    public Ulid UserId { get; set; }

}