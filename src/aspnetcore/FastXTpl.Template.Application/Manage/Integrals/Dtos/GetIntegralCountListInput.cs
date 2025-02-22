using FastXTpl.Template.Core.Manage.Integrals;

namespace FastXTpl.Template.Application.Manage.Integrals.Dtos;

/// <summary>
/// 获取积分统计输入
/// </summary>
public class GetIntegralCountListInput
{
    /// <summary>
    /// 操作类型
    /// </summary>
    public OperatorType OperatorType { get; set; }
}