using FastXTpl.Template.Core.Manage.Questions;

namespace FastXTpl.Template.Application.Manage.Questions.Dtos;

/// <summary>
/// 题库
/// </summary>
public class QuestionDto
{
    /// <summary>
    /// 题库Id
    /// </summary>
    public string QuestionId { get; set; }
    
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

    /// <summary>
    /// 题库类型
    /// </summary>
    public string QuestionTypeDesc => QuestionType.GetDescription();
}
