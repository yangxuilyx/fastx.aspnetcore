using System.ComponentModel;
using FastX.Data.Entities.AuditEntities;
using FastX.Data.SqlSugar.DataAnnotations;

namespace FastXTpl.Template.Core.Manage.Questions;

/// <summary>
/// 题库
/// </summary>
[XSugarTable("Manage")]
public class Question : AuditEntity
{
    /// <summary>
    /// 题库Id
    /// </summary>
    public Ulid QuestionId { get; set; }

    /// <summary>
    /// 编号
    /// </summary>
    public string No { get; set; }

    /// <summary>
    /// 编号及类别
    /// </summary>
    public string Catalog { get; set; }

    /// <summary>
    /// 编号及任务项
    /// </summary>
    public string Job { get; set; }

    /// <summary>
    /// 编号及具体任务
    /// </summary>
    public string JobItem { get; set; }

    /// <summary>
    /// 积分
    /// </summary>
    public int Integral { get; set; }

    /// <summary>
    /// 题库类型
    /// </summary>
    public QuestionType QuestionType { get; set; }
}

public enum QuestionType
{
    /// <summary>
    /// 部门题库
    /// </summary>
    [Description("部门题库")]
    _0,

    /// <summary>
    /// 用户题库
    /// </summary>
    [Description("用户题库")]
    _1
}