using System.ComponentModel.DataAnnotations;

namespace FastXTpl.Template.Application.Manage.ExamineObjectQuestions.Dtos;

/// <summary>
/// 获取列表输入
/// </summary>
public class GetListExamineObjectQuestionInput
{
    /// <summary>
    /// 考核Id
    /// </summary>
    [Required]
    public string ExamineId { get; set; }

    /// <summary>
    /// 考核对象Id
    /// </summary>
    public string? ObjectId { get; set; }
}