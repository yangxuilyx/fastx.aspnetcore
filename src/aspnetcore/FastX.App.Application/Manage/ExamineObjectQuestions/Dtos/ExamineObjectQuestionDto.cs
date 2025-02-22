using System.ComponentModel.DataAnnotations;
using FastX.App.Application.Manage.Questions.Dtos;

namespace FastX.App.Application.Manage.ExamineObjectQuestions.Dtos;

public class ExamineObjectQuestionDto
{
    /// <summary>
    /// 考核Id
    /// </summary>
    [Required]
    public string ExamineId { get; set; }

    /// <summary>
    /// 题库Id
    /// </summary>
    public string QuestionId { get; set; }

    /// <summary>
    /// 考核结果
    /// </summary>
    public string? Content { get; set; }

    /// <summary>
    /// 附件地址
    /// </summary>
    public string? FileUrl { get; set; }

    /// <summary>
    /// 问题对象
    /// </summary>
    public QuestionDto Question { get; set; }
}