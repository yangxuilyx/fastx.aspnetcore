using FastX.App.Application.Identity.Ous.Dtos;
using FastX.App.Core.Identity.Ous;
using FastX.Application.Dtos;
using FastX.Application.Services;
using FastX.Data.Repository;
using Microsoft.AspNetCore.Authorization;
using SqlSugar;

namespace FastX.App.Application.Identity.Ous;

/// <summary>
/// 组织管理
/// </summary>
[Authorize]
public class OuAppService : CrudAppService<Ou, string, OuDto, GetOuListInput, CreateOuDto>, IOuAppService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="repository"></param>
    public OuAppService(IRepository<Ou> repository) : base(repository)
    {
    }

    /// <summary>
    /// 获取所有组织
    /// </summary>
    /// <returns></returns>
    public async Task<List<OuDto>> GetAllAsync()
    {
        var ous = await Repository.GetListAsync();

        var ouDtos = await MapToEntityDtoList(ous);

        return ouDtos;
    }

    /// <summary>
    /// 获取列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public override async Task<PagedResultDto<OuDto>> ListAsync(GetOuListInput input)
    {
        var pagedResultDto = await base.ListAsync(input);

        await GetChildren(pagedResultDto.Items);

        return pagedResultDto;
    }

    private async Task GetChildren(List<OuDto> ouDtos)
    {
        foreach (var dto in ouDtos)
        {
            var ous = await Repository.GetListAsync(p => p.ParentId == dto.OuId);
            var children = await MapToEntityDtoList(ous);

            if (children.Count > 0)
            {
                dto.Children = children;
                await GetChildren(children);
            }
        }
    }

    /// <summary>
    /// ApplySorting
    /// </summary>
    /// <param name="query"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    protected override ISugarQueryable<Ou> ApplySorting(ISugarQueryable<Ou> query, GetOuListInput input)
    {
        return query.OrderByDescending(p => p.OuId);
    }

    /// <summary>
    /// CreateFilteredQuery
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    protected override ISugarQueryable<Ou> CreateFilteredQuery(GetOuListInput input)
    {
        return base.CreateFilteredQuery(input).Where(t => t.ParentId == input.ParentId);
    }
}