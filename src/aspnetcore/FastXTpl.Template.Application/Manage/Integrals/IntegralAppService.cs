using FastX.App.Application.Manage.Integrals.Dtos;
using FastX.App.Core.Identity.Ous;
using FastX.App.Core.Identity.Users;
using FastX.Application.Services;
using FastX.Data.Repository;
using SqlSugar;
using FastX.App.Core.Manage.Integrals;
using Microsoft.AspNetCore.Authorization;
using FastX.Data.Entities;

namespace FastX.App.Application.Manage.Integrals;

/// <summary>
/// 积分
/// </summary>
[Authorize]
public class IntegralAppService : ReadOnlyAppService<Integral, string, IntegralDto, GetIntegralListInput>, IIntegralAppService
{
    private readonly IRepository<User> _userRepository;
    private readonly IRepository<Ou> _ouRepository;

    /// <summary>
    /// 
    /// </summary>
    public IntegralAppService(IRepository<Integral> repository, IRepository<User> userRepository, IRepository<Ou> ouRepository) : base(repository)
    {
        _userRepository = userRepository;
        _ouRepository = ouRepository;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    protected override ISugarQueryable<Integral> CreateFilteredQuery(GetIntegralListInput input)
    {
        return base.CreateFilteredQuery(input)
        .WhereIF(!input.OperatorId.IsNullOrEmpty(), p => p.OperatorId == input.OperatorId)
        .WhereIF(input.OperatorType.HasValue, p => p.OperatorType == input.OperatorType)
        .WhereIF(input.Type.HasValue, p => p.Type == input.Type)
        ;
    }

    protected override async Task<IntegralDto> MapToEntityDto(Integral entity)
    {
        var dto = await base.MapToEntityDto(entity);

        if (entity.OperatorType == OperatorType.User)
        {
            var user = await _userRepository.GetAsync(entity.OperatorId);
            dto.OperatorName = user?.Name;
        }
        else
        {
            var ou = await _ouRepository.GetAsync(entity.OperatorId);
            dto.OperatorName = ou?.Name;
        }

        return dto;
    }

    /// <summary>
    /// 创建积分
    /// </summary>
    /// <returns></returns>
    public async Task<IntegralDto> Create(CreateIntegralDto input)
    {
        if (input.IntegralValue == 0)
            return new IntegralDto();

        if (input.OperatorType == OperatorType.User)
        {
            var integral = await Repository.GetAsync(p => p.OperatorId == CurrentUser.UserId && p.SourceId == input.SourceId);
            if (integral != null)
                return await MapToEntityDto(integral);

            integral = await Repository.InsertAsync(new Integral()
            {
                IntegralValue = input.IntegralValue,
                OperatorId = CurrentUser.UserId,
                CreateDate = DateTime.Now,
                Reason = input.Reason,
                SourceId = input.SourceId,
                Type = input.Type
            });

            return await MapToEntityDto(integral);
        }
        else
        {
            var user = await _userRepository.GetAsync(CurrentUser.UserId);
            if (user == null)
                throw new UserFriendlyException("用户不存在");
            if (!user.OuId.HasValue)
                throw new UserFriendlyException("组织不存在");

            var integral = await Repository.GetAsync(p => p.OperatorId == user.OuId.Value && p.SourceId == input.SourceId);
            if (integral != null)
                return await MapToEntityDto(integral);

            integral = await Repository.InsertAsync(new Integral()
            {
                IntegralValue = input.IntegralValue,
                OperatorId = user.OuId.Value,
                CreateDate = DateTime.Now,
                Reason = input.Reason,
                SourceId = input.SourceId,
                Type = input.Type
            });

            return await MapToEntityDto(integral);
        }
    }

    /// <summary>
    /// 获取积分统计
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<List<IntegralCountDto>> GetIntegralCountAsync(GetIntegralCountListInput input)
    {
        var integrals = await Repository.GetListAsync(p => p.OperatorType == input.OperatorType);

        var integralCountDtos = await Task.WhenAll(integrals.GroupBy(p => p.OperatorId)
            .Select(async t =>
            {
                var operatorName = "";
                if (input.OperatorType == OperatorType.User)
                {
                    var user = await _userRepository.GetAsync(t.Key);
                    operatorName = user?.Name;
                }
                else
                {
                    var ou = await _ouRepository.GetAsync(t.Key);
                    operatorName = ou?.Name;
                }

                return new IntegralCountDto
                {
                    OperationName = operatorName,
                    Total = t.Sum(t => t.IntegralValue)
                };
            }));

        return integralCountDtos.OrderByDescending(p => p.Total).ToList();
    }
}