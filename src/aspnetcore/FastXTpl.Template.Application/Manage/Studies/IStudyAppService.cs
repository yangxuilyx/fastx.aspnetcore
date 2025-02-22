using FastX.AspNetCore;
using FastXTpl.Template.Application.Manage.Studies.Dtos;

namespace FastXTpl.Template.Application.Manage.Studies;

public interface IStudyAppService : IApplicationService
{
    /// <summary>
    /// 发布
    /// </summary>
    /// <param name="studyId"></param>
    /// <returns></returns>
    Task<StudyDto> SendAsync(string studyId);
}