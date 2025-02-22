using FastX.AspNetCore;
using FastXTpl.Template.Application.Manage.Notis.Dtos;

namespace FastXTpl.Template.Application.Manage.Notis;

/// <summary>
/// 通知管理
/// </summary>
public interface INotiAppService : IApplicationService
{
    /// <summary>
    /// 发送通知
    /// </summary>
    /// <param name="notiId"></param>
    /// <returns></returns>
    Task<NotiDto> SendAsync(string notiId);
}