using FastX.AspNetCore;
using FastXTpl.Template.Application.Manage.Statistic.Dtos;

namespace FastXTpl.Template.Application.Manage.Statistic;

public interface IStatisticAppService : IApplicationService
{
    /// <summary>
    /// 用户统计
    /// </summary>
    /// <returns></returns>
    Task<UserCountDto> GetUsers();

    /// <summary>
    /// 党费统计
    /// </summary>
    /// <returns></returns>
    Task<FeeCountDto> GetFee();

    /// <summary>
    /// 任务完成情况统计
    /// </summary>
    /// <returns></returns>
    Task<ExamineStatisticDto> GetExamineStatistic();

    /// <summary>
    /// 任务完成情况分析
    /// </summary>
    /// <returns></returns>
    Task<ExamineAnaDto> GetExamineAna();
}