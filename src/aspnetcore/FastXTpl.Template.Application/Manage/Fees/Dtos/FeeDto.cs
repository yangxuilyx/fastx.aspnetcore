using FastX.App.Application.Identity.Users.Dtos;
using FastX.App.Core.Manage.Fees;

namespace FastX.App.Application.Manage.Fees.Dtos;

/// <summary>
/// FeeDto
/// </summary>
public class FeeDto
{
    /// <summary>
    /// 党费Id
    /// </summary>
    public string FeeId { get; set; }

    /// <summary>
    /// 用户Id
    /// </summary>
    public string UserId { get; set; }

    /// <summary>
    /// 用户
    /// </summary>
    public UserDto User { get; set; }

    /// <summary>
    /// 组织Id
    /// </summary>
    public string? OuId { get; set; }

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
    public string Remark { get; set; }

    /// <summary>
    /// 支付状态
    /// </summary>
    public PayStatus PayStatus { get; set; }

    /// <summary>
    /// 支付状态
    /// </summary>
    public string PayStatusDesc => PayStatus.GetDescription();
}