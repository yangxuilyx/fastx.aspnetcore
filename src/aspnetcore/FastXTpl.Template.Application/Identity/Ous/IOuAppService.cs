using FastX.App.Application.Identity.Ous.Dtos;
using FastX.AspNetCore;

namespace FastX.App.Application.Identity.Ous;

/// <summary>
/// 组织管理
/// </summary>
public interface IOuAppService : IApplicationService
{
    /// <summary>
    /// 获取所有组织
    /// </summary>
    /// <returns></returns>
    Task<List<OuDto>> GetAllAsync();
}