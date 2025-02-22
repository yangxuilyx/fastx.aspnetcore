using System.ComponentModel.DataAnnotations;
using FastX.Data.DataFilters;
using FastX.Data.Entities;
using FastX.Data.SqlSugar;
using FastX.Data.SqlSugar.DataAnnotations;
using SqlSugar;

namespace FastX.App.Core.Identity.Roles;

/// <summary>
/// 角色
/// </summary>
[XSugarTable("Identity")]
public class Role : Entity, ISoftDelete
{
    /// <summary>
    /// 角色Id
    /// </summary>
    public Ulid RoleId { get; set; }

    /// <summary>
    /// 角色名称
    /// </summary>
    public string Name{ get; set; }

    /// <summary>
    /// 角色描述
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// IsDeleted
    /// </summary>
    public bool IsDeleted { get; set; }
}