using FastX.App.Core.Manage.Questions;
using FastX.Application.Dtos;
using FastX.Data.PagedResult;

namespace FastX.App.Application.Manage.Questions.Dtos;

/// <summary>
/// 题库
/// </summary>
public class GetQuestionListInput : IPagedResultRequest, ISortedResultRequest
{
    /// <summary>
    /// 题库类型
    /// </summary>
    public QuestionType? QuestionType { get; set; }

    /// <summary>
    /// 分页信息
    /// </summary>
    public PageInfo Page { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    public string? Sorting { get; set; } = "QuestionId DESC";
}