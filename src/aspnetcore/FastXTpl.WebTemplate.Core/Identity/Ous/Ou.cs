using FastX.Data.DataFilters;
using FastX.Data.Entities;
using FastX.Data.SqlSugar.DataAnnotations;

namespace FastXTpl.WebTemplate.Core.Identity.Ous;

/// <summary>
/// 组织
/// </summary>
[XSugarTable("Identity")]
public class Ou : Entity, ISoftDelete
{
    /// <summary>
    /// 组织Id
    /// </summary>
    public Ulid OuId { get; set; }

    /// <summary>
    /// 组织名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 电话
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// 地址
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// 上级Id
    /// </summary>
    public Ulid ParentId { get; set; }

    /// <summary>
    /// 组织级别
    /// </summary>
    public OuType OuType { get; set; }

    /// <summary>
    /// IsDeleted
    /// </summary>
    public bool IsDeleted { get; set; }
}
