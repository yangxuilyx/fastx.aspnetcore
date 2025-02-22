using System.ComponentModel.DataAnnotations;

namespace FastX.App.Application.Manage.ExamineObjectQuestions.Dtos;

public class UpdateContentInput
{
    /// <summary>
    /// 考核Id
    /// </summary>
    [Required]
    public string ExamineId { get; set; }

    /// <summary>
    /// 题库Id
    /// </summary>
    [Required]
    public string QuestionId { get; set; }

    /// <summary>
    /// 考核结果
    /// </summary>
    public string Content { get; set; }

    /// <summary>
    /// 附件地址
    /// </summary>
    public string? FileUrl { get; set; }

    /// <summary>
    /// 是否完成
    /// </summary>
    public bool IsComplete { get; set; }
}