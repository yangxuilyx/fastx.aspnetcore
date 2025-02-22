using System.ComponentModel;

namespace FastXTpl.Template.Core.Manage;

/// <summary>
/// 通知状态
/// </summary>
public enum NotiStatus
{
    /// <summary>
    /// 待发布
    /// </summary>
    [Description("待发布")]
    _0,

    /// <summary>
    /// 已发布
    /// </summary>
    [Description("已发布")]
    _1
}