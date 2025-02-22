using System.ComponentModel;

namespace FastX.App.Core.Identity.Users;

/// <summary>
/// 党员类型
/// </summary>
public enum UserType
{
    /// <summary>
    /// 群众
    /// </summary>
    [Description("群众")]
    _0,

    /// <summary>
    /// 正式党员
    /// </summary>
    [Description("正式党员")]
    _1,

    /// <summary>
    /// 预备党员
    /// </summary>
    [Description("预备党员")]
    _2,

    /// <summary>
    /// 发展对象
    /// </summary>
    [Description("发展对象")]
    _3,

    /// <summary>
    /// 入党积极分子
    /// </summary>
    [Description("入党积极分子")]
    _4,
}