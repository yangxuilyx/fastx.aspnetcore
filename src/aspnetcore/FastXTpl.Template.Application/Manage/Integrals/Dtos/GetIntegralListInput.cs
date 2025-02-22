using FastX.App.Core.Manage.Integrals;
using FastX.Application.Dtos;
using FastX.Data.PagedResult;

namespace FastX.App.Application.Manage.Integrals.Dtos;

/// <summary>
/// 积分
/// </summary>
public class GetIntegralListInput : IPagedResultRequest, ISortedResultRequest
{
    /// <summary>
    /// 用户Id
    /// </summary>
    public string? OperatorId { get; set; }

    /// <summary>
    /// 积分类型
    /// </summary>
    public IntegralType? Type { get; set; }

    /// <summary>
    /// 操作类型
    /// </summary>
    public OperatorType? OperatorType { get; set; }

    /// <summary>
    /// 分页信息
    /// </summary>
    public PageInfo Page { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    public string? Sorting { get; set; } = "IntegralId DESC";
}