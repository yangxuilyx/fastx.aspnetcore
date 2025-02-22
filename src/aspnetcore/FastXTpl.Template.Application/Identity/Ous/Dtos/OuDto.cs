using FastX.App.Core.Identity.Ous;
using FastX.Data.SqlSugar;
using SqlSugar;

namespace FastX.App.Application.Identity.Ous.Dtos;

/// <summary>
/// 组织Dto
/// </summary>
public class OuDto
{
    /// <summary>
    /// 组织Id
    /// </summary>
    public string OuId { get; set; }

    /// <summary>
    /// Id
    /// </summary>
    public string Id => OuId;

    /// <summary>
    /// 组织名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 电话
    /// </summary>
    public string Phone { get; set; }

    /// <summary>
    /// 地址
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// 上级Id
    /// </summary>
    public string ParentId { get; set; }

    /// <summary>
    /// 组织级别
    /// </summary>
    public OuType OuType { get; set; }

    /// <summary>
    /// 组织级别
    /// </summary>
    public string OuTypeDesc => OuType.GetDescription();

    /// <summary>
    /// 子列表
    /// </summary>
    public List<OuDto> Children { get; set; }
}