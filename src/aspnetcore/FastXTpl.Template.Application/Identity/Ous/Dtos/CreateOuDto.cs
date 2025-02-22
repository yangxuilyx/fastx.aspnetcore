using FastXTpl.Template.Core.Identity.Ous;

namespace FastXTpl.Template.Application.Identity.Ous.Dtos;

/// <summary>
/// 创建组织
/// </summary>
public class CreateOuDto
{
    /// <summary>
    /// 组织Id
    /// </summary>
    public string OuId { get; set; }

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
}