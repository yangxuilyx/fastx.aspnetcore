using FastX.App.Application.Manage.Notis.Dtos;
using FastX.App.Application.Manage.Studies.Dtos;
using FastX.AspNetCore;

namespace FastX.App.Application.Manage.Studies;

public interface IStudyAppService : IApplicationService
{
    /// <summary>
    /// 发布
    /// </summary>
    /// <param name="studyId"></param>
    /// <returns></returns>
    Task<StudyDto> SendAsync(string studyId);
}