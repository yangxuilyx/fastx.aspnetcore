using System.ComponentModel;
using FastX.Data;
using FastX.Data.DataFilters;
using FastX.Data.Entities;
using FastX.Data.SqlSugar.DataAnnotations;

namespace FastX.App.Core.Manage.Fees;

/// <summary>
/// 党费
/// </summary>
[XSugarTable("Manage")]
public class Fee : AuditEntity
{
    /// <summary>
    /// 党费Id
    /// </summary>
    public Ulid FeeId { get; set; }

    /// <summary>
    /// 用户Id
    /// </summary>
    public Ulid UserId { get; set; }

    /// <summary>
    /// 组织Id
    /// </summary>
    public Ulid? OuId { get; set; }

    /// <summary>
    /// 单据号
    /// </summary>
    public string ReceiptNo { get; set; }

    /// <summary>
    /// 金额
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// 应缴费时间
    /// </summary>
    public DateTime ShouldPayTme { get; set; }

    /// <summary>
    /// 缴费时间
    /// </summary>
    public DateTime PaidTime { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    public string? Remark { get; set; }

    /// <summary>
    /// 支付状态
    /// </summary>
    public PayStatus PayStatus { get; set; }
}

/// <summary>
/// 支付状态
/// </summary>
public enum PayStatus
{
    /// <summary>
    /// 待支付
    /// </summary>
    [Description("未缴费")]
    _0,

    /// <summary>
    /// 已支付
    /// </summary>
    [Description("已缴费")]
    _1
}