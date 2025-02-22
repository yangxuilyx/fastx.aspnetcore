using FastX.App.Application.Identity.Users.Dtos;
using FastX.App.Application.Manage.Fees.Dtos;
using FastX.App.Core.Identity.Users;
using FastX.App.Core.Manage.Fees;
using FastX.Application.Services;
using FastX.Data.Repository;
using Microsoft.AspNetCore.Authorization;
using SqlSugar;

namespace FastX.App.Application.Manage.Fees;

/// <summary>
/// 党费管理
/// </summary>
[Authorize]
public class FeeAppService : CrudAppService<Fee, string, FeeDto, GetFeeListInput, CreateFeeDto>, IFeeAppService
{
    private readonly IRepository<User> _userRepository;

    /// <summary>
    /// 
    /// </summary>
    public FeeAppService(IRepository<Fee> repository, IRepository<User> userRepository) : base(repository)
    {
        _userRepository = userRepository;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    protected override ISugarQueryable<Fee> CreateFilteredQuery(GetFeeListInput input)
    {
        return base.CreateFilteredQuery(input)
                .WhereIF(!input.UserId.IsNullOrEmptyUlid(), p => p.UserId == input.UserId)
                .WhereIF(!input.OuId.IsNullOrEmptyUlid(), p => p.OuId == input.OuId)
                .WhereIF(input.PayStatus.HasValue, p => p.PayStatus == input.PayStatus)
            ;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="entityDto"></param>
    /// <returns></returns>
    /// <exception cref="UserFriendlyException"></exception>
    protected override async Task<Fee> MapCreateDtoToEntity(CreateFeeDto entityDto)
    {
        var entity = await base.MapCreateDtoToEntity(entityDto);
        var user = await _userRepository.GetAsync(p => p.UserId == entity.UserId);
        if (user == null)
            throw new UserFriendlyException("党员信息不存在");

        entity.OuId = user.OuId;
        entity.PaidTime = DateTime.Now;
        return entity;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    protected override async Task<FeeDto> MapToEntityDto(Fee entity)
    {
        var dto = await base.MapToEntityDto(entity);

        var user = await _userRepository.GetAsync(dto.UserId);
        if (user != null)
            dto.User = ObjectMapper.Map<UserDto>(user);

        return dto;
    }
}