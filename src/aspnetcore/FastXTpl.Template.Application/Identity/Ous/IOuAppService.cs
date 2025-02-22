using FastX.AspNetCore;
using FastXTpl.Template.Application.Identity.Ous.Dtos;

namespace FastXTpl.Template.Application.Identity.Ous;

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