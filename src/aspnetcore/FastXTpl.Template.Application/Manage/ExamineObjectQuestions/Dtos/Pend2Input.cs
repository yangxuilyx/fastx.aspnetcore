using System.ComponentModel.DataAnnotations;

namespace FastXTpl.Template.Application.Manage.ExamineObjectQuestions.Dtos;

public class Pend2Input
{
    /// <summary>
    /// 考核Id
    /// </summary>
    [Required]
    public string ExamineId { get; set; }

    /// <summary>
    /// 对象Id
    /// </summary>
    [Required]
    public string ObjectId { get; set; }

    /// <summary>
    /// 是否通过
    /// </summary>
    public bool Allow { get; set; }
}