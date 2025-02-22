namespace FastXTpl.Template.Application.Manage.Statistic.Dtos;

/// <summary>
/// 任务完成情况统计
/// </summary>
public class ExamineAnaDto
{
    /// <summary>
    /// 月份列表
    /// </summary>
    public List<string> Months { get; set; } = [];

    /// <summary>
    /// 个人完成列表
    /// </summary>
    public List<int> UserCompletedCount { get; set; } = [];

    /// <summary>
    /// 单位完成列表
    /// </summary>
    public List<int> OuCompletedCount { get; set; } = [];
}