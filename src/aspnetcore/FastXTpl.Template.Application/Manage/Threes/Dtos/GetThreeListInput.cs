using FastX.Application.Dtos;
using FastX.Data.PagedResult;

namespace FastXTpl.Template.Application.Manage.Threes.Dtos;

/// <summary>
/// GetThreeListInput
/// </summary>
public class GetThreeListInput : IPagedResultRequest, ISortedResultRequest
{
    /// <summary>
    /// 标题
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// 用户Id
    /// </summary>
    public string? UserId { get; set; }

    /// <summary>
    /// 组织Id
    /// </summary>
    public string? OuId { get; set; }

    /// <summary>
    /// 分页信息
    /// </summary>
    public PageInfo Page { get; set; }

    /// <summary>
    /// 分页
    /// </summary>
    public string? Sorting { get; set; } = "ThreeId DESC";
}