namespace FastXTpl.Template.Application.Manage.Statistic.Dtos;

/// <summary>
/// 任务完成情况统计
/// </summary>
public class ExamineStatisticDto
{
    /// <summary>
    /// 月份列表
    /// </summary>
    public List<string> Months { get; set; } = [];

    /// <summary>
    /// 完成列表
    /// </summary>
    public List<int> CompletedCount { get; set; } = [];

    /// <summary>
    /// 未完成列表
    /// </summary>
    public List<int> NotCompletedCounts { get; set; } = [];

    /// <summary>
    /// 所有列表
    /// </summary>
    public List<int> AllCounts { get; set; } = [];
}