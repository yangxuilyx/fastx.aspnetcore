using FastX.AspNetCore;
using FastXTpl.Template.Application.Identity.Users.Dtos;

namespace FastXTpl.Template.Application.Identity.Users;

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