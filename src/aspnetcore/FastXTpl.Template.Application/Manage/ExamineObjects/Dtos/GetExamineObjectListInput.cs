using System.ComponentModel.DataAnnotations;
using FastX.Application.Dtos;
using FastX.Data.PagedResult;

namespace FastXTpl.Template.Application.Manage.ExamineObjects.Dtos;

public class GetExamineObjectListInput : IPagedResultRequest, ISortedResultRequest
{
    /// <summary>
    /// 考核Id
    /// </summary>
    [Required]
    public string ExamineId { get; set; }

    /// <summary>
    /// 分页信息
    /// </summary>
    public PageInfo Page { get; set; }

    /// <summary>
    /// 分页
    /// </summary>
    public string? Sorting { get; set; } = "ExamineId Desc";
}