using FastX;
using FastX.Application.Services;
using FastX.Data.Repository;
using FastXTpl.Template.Application.Manage.Notis.Dtos;
using FastXTpl.Template.Core.Manage;
using FastXTpl.Template.Core.Manage.Notis;
using Microsoft.AspNetCore.Authorization;
using SqlSugar;

namespace FastXTpl.Template.Application.Manage.Notis;

/// <summary>
/// 通知管理
/// </summary>
[Authorize]
public class NotiAppService : CrudAppService<Noti, string, NotiDto, GetNotiListInput>, INotiAppService
{
    private IRepository<NotiOu> _notiOuRepository;
    /// <summary>
    /// 
    /// </summary>
    public NotiAppService(IRepository<Noti> repository, IRepository<NotiOu> notiOuRepository) : base(repository)
    {
        _notiOuRepository = notiOuRepository;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    protected override ISugarQueryable<Noti> CreateFilteredQuery(GetNotiListInput input)
    {
        var queryable = base.CreateFilteredQuery(input)
                .Where(p => p.Type == input.NotiType)
                .WhereIF(!input.Title.IsNullOrEmpty(), p => p.Title.Contains(input.Title))
                .WhereIF(input.NotiStatus.HasValue, p => p.Status == input.NotiStatus)
        ;

        if (!input.OuId.IsNullOrEmptyUlid())
        {
            queryable = queryable.LeftJoinIF<NotiOu>(!input.OuId.IsNullOrEmptyUlid(), (noti, ou) => noti.NotiId == ou.NotiId)
                 .Where((noti, ou) => ou.OuId == input.OuId);
        }

        return queryable;

    }

    /// <summary>
    /// InsertAsync
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public override async Task<NotiDto> InsertOrUpdateAsync(NotiDto input)
    {
        var notiDto = await base.InsertOrUpdateAsync(input);

        var notiOus = await _notiOuRepository.GetListAsync(p => p.NotiId == input.NotiId);

        await Task.WhenAll(notiOus.Where(t => !input.NotiOus.Contains(t.NotiId)).Select(async t =>
        {
            await _notiOuRepository.DeleteAsync(t);
        }));

        await Task.WhenAll(input.NotiOus.Select(async t =>
        {
            await _notiOuRepository.InsertOrUpdateAsync(new NotiOu()
            {
                NotiId = notiDto.NotiId,
                OuId = t
            });
        }));

        return notiDto;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    protected override async Task<NotiDto> MapToEntityDto(Noti entity)
    {
        var entityDto = await base.MapToEntityDto(entity);

        var notiOus = await _notiOuRepository.GetListAsync(p => p.NotiId == entityDto.NotiId);

        entityDto.NotiOus = notiOus.ConvertAll(t => t.OuId.ToString());

        return entityDto;
    }

    /// <summary>
    /// 发送通知
    /// </summary>
    /// <param name="notiId"></param>
    /// <returns></returns>
    public async Task<NotiDto> SendAsync(string notiId)
    {
        var noti = await Repository.GetAsync(notiId);
        if (noti == null)
            throw new UserFriendlyException("通知不存在");

        noti.Status = NotiStatus._1;
        noti.CreateTime = DateTime.Now;
        await Repository.UpdateAsync(noti);

        return await MapToEntityDto(noti);
    }
}