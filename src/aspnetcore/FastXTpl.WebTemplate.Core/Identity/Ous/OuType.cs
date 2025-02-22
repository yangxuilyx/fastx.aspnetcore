using System.ComponentModel;

namespace FastXTpl.WebTemplate.Core.Identity.Ous;

/// <summary>
/// 组织级别
/// </summary>
public enum OuType
{
    /// <summary>
    /// 党支部
    /// </summary>
    [Description("党支部")]
    _0,

    /// <summary>
    /// 党总支
    /// </summary>
    [Description("党总支")]
    _1,

    /// <summary>
    /// 党委
    /// </summary>
    [Description("党委")]
    _2,

    /// <summary>
    /// 单位
    /// </summary>
    [Description("办公室")]
    _3,

    [Description("部门")]
    _4
}