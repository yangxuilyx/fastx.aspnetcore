using FastX.App.Core.Manage;
using FastX.Application.Dtos;
using FastX.Data.PagedResult;

namespace FastX.App.Application.Manage.Studies.Dtos;

public class GetStudyListInput : IPagedResultRequest, ISortedResultRequest
{
    /// <summary>
    /// 标题
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// 分页信息
    /// </summary>
    public PageInfo Page { get; set; }

    /// <summary>
    /// 发布状态
    /// </summary>
    public NotiStatus? Status { get; set; }

    /// <summary>
    /// 分页
    /// </summary>
    public string? Sorting { get; set; } = "StudyId DESC";
}