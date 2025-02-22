using FastX.AspNetCore;
using FastXTpl.WebTemplate.Application.Identity.Users.Dtos;

namespace FastXTpl.WebTemplate.Application.Identity.Users;

/// <summary>
/// 用户管理
/// </summary>
public interface IUserAppService : IApplicationService
{
    /// <summary>
    /// 获取所有组织
    /// </summary>
    /// <returns></returns>
    Task<List<UserDto>> GetAllAsync();
}