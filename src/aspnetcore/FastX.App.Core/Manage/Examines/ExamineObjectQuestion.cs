using FastX.Data.Entities;
using FastX.Data.SqlSugar.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace FastX.App.Core.Manage.Examines;

/// <summary>
/// 考核对象题库
/// </summary>
[XSugarTable("Manage")]
public class ExamineObjectQuestion : Entity
{
    /// <summary>
    /// 考核Id
    /// </summary>
    [Key]
    public Ulid ExamineId { get; set; }

    /// <summary>
    /// 对象Id
    /// </summary>
    [Key]
    public Ulid ObjectId { get; set; }

    /// <summary>
    /// 题库Id
    /// </summary>
    [Key]
    public Ulid QuestionId { get; set; }

    /// <summary>
    /// 考核结果
    /// </summary>
    public string Content { get; set; }

    /// <summary>
    /// 附件地址
    /// </summary>
    public string? FileUrl { get; set; }

    /// <summary>
    /// 积分
    /// </summary>
    public int Integral { get; set; }

    /// <summary>
    /// 加分
    /// </summary>
    public int AddIntegral { get; set; }

    /// <summary>
    /// 减分
    /// </summary>
    public int SubIntegral { get; set; }

    /// <summary>
    /// 最终得分
    /// </summary>
    public int FinalIntegral { get; set; }
}