using FastX.Application.Services;
using FastX.Data.Repository;
using FastXTpl.Template.Application.Manage.Statistic.Dtos;
using FastXTpl.Template.Core.Identity.Users;
using FastXTpl.Template.Core.Manage.Examines;
using FastXTpl.Template.Core.Manage.Fees;
using FastXTpl.Template.Core.Manage.Integrals;

namespace FastXTpl.Template.Application.Manage.Statistic;

public class StatisticAppService : ApplicationService, IStatisticAppService
{
    private readonly IRepository<User> _userRepository;
    private readonly IRepository<Integral> _integralRepository;
    private readonly IRepository<Fee> _feeRepository;
    private readonly IRepository<ExamineObject> _examineObjectRepository;

    /// <summary>
    /// 
    /// </summary>
    public StatisticAppService(IRepository<User> userRepository, IRepository<Integral> integralRepository, IRepository<Fee> feeRepository, IRepository<ExamineObject> examineObjectRepository)
    {
        _userRepository = userRepository;
        _integralRepository = integralRepository;
        _feeRepository = feeRepository;
        _examineObjectRepository = examineObjectRepository;
    }

    /// <summary>
    /// 用户统计
    /// </summary>
    /// <returns></returns>
    public async Task<UserCountDto> GetUsers()
    {
        var userDto = new UserCountDto()
        {
            Count0 = await _userRepository.GetQueryable().Where(p => p.UserType == UserType._0).CountAsync(),
            Count1 = await _userRepository.GetQueryable().Where(p => p.UserType == UserType._1).CountAsync(),
            Count2 = await _userRepository.GetQueryable().Where(p => p.UserType == UserType._2).CountAsync(),
            Count3 = await _userRepository.GetQueryable().Where(p => p.UserType == UserType._3).CountAsync(),
            Count4 = await _userRepository.GetQueryable().Where(p => p.UserType == UserType._4).CountAsync(),
        };

        return userDto;
    }

    /// <summary>
    /// 党费统计
    /// </summary>
    /// <returns></returns>
    public async Task<FeeCountDto> GetFee()
    {
        return new FeeCountDto()
        {
            PaidCount = await _feeRepository.GetQueryable().Where(p => p.PayStatus == PayStatus._1).CountAsync(),
            NotPaidCount = await _feeRepository.GetQueryable().Where(p => p.PayStatus == PayStatus._0).CountAsync(),
        };
    }

    /// <summary>
    /// 任务完成情况统计
    /// </summary>
    /// <returns></returns>
    public async Task<ExamineStatisticDto> GetExamineStatistic()
    {
        var examineStatisticDto = new ExamineStatisticDto();

        var now = DateTime.Now.Date;
        for (int i = 6; i >= 0; i--)
        {
            var monthDate = now.AddMonths(-i);
            var startDate = new DateTime(monthDate.Year, monthDate.Month, 1);
            var endDate = new DateTime(monthDate.Year, monthDate.Month, 1).AddMonths(1);

            examineStatisticDto.Months.Add($"{monthDate.Month}月");

            var completeCount = await _examineObjectRepository.GetQueryable()
                .Where(p => startDate <= p.CompleteDate && p.CompleteDate < endDate)
                .Where(p => p.Status == ExamineObjectStatus._5)
                .CountAsync();

            var notCompleteCount = await _examineObjectRepository.GetQueryable()
                .LeftJoin<Examine>((o, e) => o.ExamineId == e.ExamineId)
                .Where((o, e) => startDate <= e.EndDate && e.EndDate < endDate)
                .Where(o => o.Status != ExamineObjectStatus._5)
                .CountAsync();

            examineStatisticDto.CompletedCount.Add(completeCount);
            examineStatisticDto.NotCompletedCounts.Add(notCompleteCount);
            examineStatisticDto.AllCounts.Add(completeCount + notCompleteCount);
        }

        return examineStatisticDto;
    }

    /// <summary>
    /// 任务完成情况分析
    /// </summary>
    /// <returns></returns>
    public async Task<ExamineAnaDto> GetExamineAna()
    {
        var examineAnaDto = new ExamineAnaDto();

        var now = DateTime.Now.Date;
        for (int i = 6; i >= 0; i--)
        {
            var monthDate = now.AddMonths(-i);
            var startDate = new DateTime(monthDate.Year, monthDate.Month, 1);
            var endDate = new DateTime(monthDate.Year, monthDate.Month, 1).AddMonths(1);

            examineAnaDto.Months.Add($"{monthDate.Month}月");

            var userCompleteCount = await _examineObjectRepository.GetQueryable()
                .LeftJoin<Examine>((p, e) => p.ExamineId == e.ExamineId)
                .Where(p => startDate <= p.CompleteDate && p.CompleteDate < endDate)
                .Where((p, e) => e.ExamineType == ExamineType._1 && p.Status == ExamineObjectStatus._5)
                .CountAsync();

            var ouCompleteCount = await _examineObjectRepository.GetQueryable()
                .LeftJoin<Examine>((p, e) => p.ExamineId == e.ExamineId)
                .Where(p => startDate <= p.CompleteDate && p.CompleteDate < endDate)
                .Where((p, e) => e.ExamineType == ExamineType._1 && p.Status == ExamineObjectStatus._5)
                .CountAsync();

            examineAnaDto.UserCompletedCount.Add(userCompleteCount);
            examineAnaDto.OuCompletedCount.Add(ouCompleteCount);
        }

        return examineAnaDto;

    }
}