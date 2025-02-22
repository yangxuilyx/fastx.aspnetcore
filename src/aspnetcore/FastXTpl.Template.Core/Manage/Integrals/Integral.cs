using System.ComponentModel;
using FastX.Data;
using FastX.Data.Entities.AuditEntities;
using FastX.Data.SqlSugar.DataAnnotations;

namespace FastX.App.Core.Manage.Integrals;

/// <summary>
/// 积分
/// </summary>
[XSugarTable("Manage")]
public class Integral : AuditEntity
{
    /// <summary>
    /// 积分Id
    /// </summary>
    public Ulid IntegralId { get; set; }

    /// <summary>
    /// 积分
    /// </summary>
    public int IntegralValue { get; set; }

    /// <summary>
    /// 用户Id/组织Id
    /// </summary>
    public Ulid OperatorId { get; set; }

    /// <summary>
    /// 操作类型
    /// </summary>
    public OperatorType OperatorType { get; set; }

    /// <summary>
    /// 积分时间
    /// </summary>
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// 得分原因
    /// </summary>
    public string Reason { get; set; }

    /// <summary>
    /// 原始Id
    /// </summary>
    public Ulid SourceId { get; set; }

    /// <summary>
    /// 积分类型 0: 阅读通知 1: 学习 2: 完成考核 3: 完成工作
    /// </summary>
    public IntegralType Type { get; set; }
}

public enum IntegralType
{
    [Description("阅读通知")]
    _0,

    [Description("完成学习")]
    _1,

    [Description("完成考核")]
    _2,

    [Description("完成工作")]
    _3
}

/// <summary>
/// 操作类型
/// </summary>
public enum OperatorType
{
    /// <summary>
    /// 用户
    /// </summary>
    [Description("用户")]
    User,

    [Description("组织")]
    Ou
}
