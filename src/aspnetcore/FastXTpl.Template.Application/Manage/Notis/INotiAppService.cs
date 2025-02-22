using FastX.App.Application.Manage.Notis.Dtos;
using FastX.App.Core.Manage.Notis;
using FastX.AspNetCore;

namespace FastX.App.Application.Manage.Notis;

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