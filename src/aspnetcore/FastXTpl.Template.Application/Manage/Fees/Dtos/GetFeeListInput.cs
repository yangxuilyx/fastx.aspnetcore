using FastX.Application.Dtos;
using FastX.Data.PagedResult;
using FastXTpl.Template.Core.Manage.Fees;

namespace FastXTpl.Template.Application.Manage.Fees.Dtos;

/// <summary>
/// 获取党费输入
/// </summary>
public class GetFeeListInput : IPagedResultRequest, ISortedResultRequest
{
    /// <summary>
    /// 组织Id
    /// </summary>
    public string OuId { get; set; }

    /// <summary>
    /// 用户Id
    /// </summary>
    public string UserId { get; set; }

    /// <summary>
    /// 缴费状态
    /// </summary>
    public PayStatus? PayStatus { get; set; }

    /// <summary>
    /// 分页信息
    /// </summary>
    public PageInfo Page { get; set; }

    /// <summary>
    /// 分页
    /// </summary>
    public string? Sorting { get; set; } = "FeeId DESC";
}