using FastX.App.Core.Manage.Examines;
using FastX.Application.Dtos;
using FastX.Data.PagedResult;

namespace FastX.App.Application.Manage.Examines.Dtos;

/// <summary>
/// 在线考核
/// </summary>
public class GetExamineListInput : IPagedResultRequest, ISortedResultRequest
{
    /// <summary>
    /// 考核类型
    /// </summary>
    public ExamineType ExamineType { get; set; }

    /// <summary>
    /// 考核对象Id
    /// </summary>
    public string? ExamineObjectId { get; set; }

    /// <summary>
    /// 分页信息
    /// </summary>
    public PageInfo Page { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    public string? Sorting { get; set; } = "ExamineId DESC";
}