using FastXTpl.Template.Application.Manage.Integrals.Dtos;

namespace FastXTpl.Template.Application.Manage.Integrals;

/// <summary>
/// 积分
/// </summary>
public interface IIntegralAppService
{
    /// <summary>
    /// 创建积分
    /// </summary>
    /// <returns></returns>
    Task<IntegralDto> Create(CreateIntegralDto input);

    /// <summary>
    /// 获取积分统计
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<List<IntegralCountDto>> GetIntegralCountAsync(GetIntegralCountListInput input);
}