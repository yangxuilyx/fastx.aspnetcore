using System.ComponentModel.DataAnnotations;

namespace FastXTpl.Template.Application.Manage.ExamineObjectQuestions.Dtos;

/// <summary>
/// 部门审核输入
/// </summary>
public class Pend1Input
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

    /// <summary>
    /// 明细
    /// </summary>
    public List<Pend1Item> Items { get; set; }
}

/// <summary>
/// 审核1明细
/// </summary>
public class Pend1Item
{
    /// <summary>
    /// 题库Id
    /// </summary>
    [Required]
    public string QuestionId { get; set; }

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
}