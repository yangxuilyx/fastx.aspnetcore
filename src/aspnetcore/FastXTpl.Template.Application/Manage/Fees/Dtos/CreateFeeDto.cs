using FastXTpl.Template.Core.Manage.Fees;

namespace FastXTpl.Template.Application.Manage.Fees.Dtos;

/// <summary>
/// CreateFeeDto
/// </summary>
public class CreateFeeDto
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
}