using FastX.App.Application.Identity.Ous.Dtos;
using FastX.App.Application.Identity.Users.Dtos;
using FastX.App.Application.Manage.Threes.Dtos;
using FastX.App.Core.Identity.Ous;
using FastX.App.Core.Identity.Users;
using FastX.App.Core.Manage.Threes;
using FastX.Application.Services;
using FastX.Data.Repository;
using Microsoft.AspNetCore.Authorization;
using SqlSugar;

namespace FastX.App.Application.Manage.Threes;

/// <summary>
/// 三会一课管理
/// </summary>
[Authorize]
public class ThreeAppService : CrudAppService<Three, string, ThreeDto, GetThreeListInput, CreateThreeDto>, IThreeAppService
{
    private readonly IRepository<User> _userRepository;
    private readonly IRepository<Ou> _ouRepository;

    /// <summary>
    /// 
    /// </summary>
    public ThreeAppService(IRepository<Three> repository, IRepository<User> userRepository, IRepository<Ou> ouRepository) : base(repository)
    {
        _userRepository = userRepository;
        _ouRepository = ouRepository;
    }

    /// <summary>
    /// MapToEntityDto
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    protected override async Task<ThreeDto> MapToEntityDto(Three entity)
    {
        var entityDto = await base.MapToEntityDto(entity);

        var userIds = entity.UserIds.Split(',');
        var ouIds = entity.OuIds.Split(",");

        var users = await _userRepository.GetListAsync(p => userIds.Contains(p.UserId.ToString()));
        entityDto.Users = users.ConvertAll(t => ObjectMapper.Map<UserDto>(t));

        var ous = await _ouRepository.GetListAsync(p => ouIds.Contains(p.OuId.ToString()));
        entityDto.Ous = ous.ConvertAll(t => ObjectMapper.Map<OuDto>(t));

        return entityDto;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="entityDto"></param>
    /// <returns></returns>
    protected override async Task<Three> MapCreateDtoToEntity(CreateThreeDto entityDto)
    {
        var entity = await base.MapCreateDtoToEntity(entityDto);
        entity.UserIds = entityDto.Users.JoinAsString(",");
        entity.OuIds = entityDto.Ous.JoinAsString(",");

        return entity;
    }

    /// <summary>
    /// CreateFilteredQuery
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    protected override ISugarQueryable<Three> CreateFilteredQuery(GetThreeListInput input)
    {
        return base.CreateFilteredQuery(input)
                .WhereIF(!input.Title.IsNullOrEmpty(), t => t.Title.Contains(input.Title))
                .WhereIF(!input.UserId.IsNullOrEmptyUlid(), t => t.UserIds.Contains(input.UserId))
                .WhereIF(!input.OuId.IsNullOrEmptyUlid(), t => t.OuIds.Contains(input.OuId))
            ;
    }
}