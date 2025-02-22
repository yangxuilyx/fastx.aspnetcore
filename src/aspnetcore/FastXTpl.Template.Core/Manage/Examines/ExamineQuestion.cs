using System.ComponentModel.DataAnnotations;
using FastX.Data.Entities;
using FastX.Data.SqlSugar.DataAnnotations;

namespace FastX.App.Core.Manage.Examines;

/// <summary>
/// 考核题目
/// </summary>
[XSugarTable("Manage")]
public class ExamineQuestion : Entity
{
    /// <summary>
    /// 考核Id
    /// </summary>
    [Key]
    public Ulid ExamineId { get; set; }

    /// <summary>
    /// 题库Id
    /// </summary>
    [Key]
    public Ulid QuestionId { get; set; }
}