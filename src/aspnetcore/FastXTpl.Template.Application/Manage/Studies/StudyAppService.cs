using FastX;
using FastX.Application.Services;
using FastX.Data.Repository;
using FastXTpl.Template.Application.Manage.Studies.Dtos;
using FastXTpl.Template.Core.Manage;
using FastXTpl.Template.Core.Manage.Integrals;
using FastXTpl.Template.Core.Manage.Studies;
using Microsoft.AspNetCore.Authorization;
using SqlSugar;

namespace FastXTpl.Template.Application.Manage.Studies;

[Authorize()]
public class StudyAppService : CrudAppService<Study, string, StudyDto, GetStudyListInput>, IStudyAppService
{
    private readonly IRepository<Integral> _integralRepository;

    /// <summary>
    /// 
    /// </summary>
    public StudyAppService(IRepository<Study> repository, IRepository<Integral> integralRepository) : base(repository)
    {
        _integralRepository = integralRepository;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    protected override ISugarQueryable<Study> CreateFilteredQuery(GetStudyListInput input)
    {
        return base.CreateFilteredQuery(input)
                .WhereIF(!input.Title.IsNullOrEmpty(), p => p.Title.Contains(input.Title))
                .WhereIF(input.Status.HasValue, p => p.Status == input.Status)
            ;
    }

    protected override async Task<StudyDto> MapToEntityDto(Study entity)
    {
        var studyDto = await base.MapToEntityDto(entity);

        var integral = await _integralRepository.GetAsync(p => p.OperatorType == OperatorType.User && p.OperatorId == CurrentUser.UserId && p.SourceId == studyDto.StudyId);

        studyDto.IsWatch = integral != null;

        return studyDto;
    }

    /// <summary>
    /// 发布
    /// </summary>
    /// <param name="studyId"></param>
    /// <returns></returns>
    public async Task<StudyDto> SendAsync(string studyId)
    {
        var study = await Repository.GetAsync(studyId);
        if (study == null)
            throw new UserFriendlyException("课程不存在");

        study.Status = NotiStatus._1;
        await Repository.UpdateAsync(study);

        return await MapToEntityDto(study);
    }
}