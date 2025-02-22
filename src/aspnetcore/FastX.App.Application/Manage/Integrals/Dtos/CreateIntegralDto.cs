using FastX.App.Core.Manage.Integrals;

namespace FastX.App.Application.Manage.Integrals.Dtos;

/// <summary>
/// 积分
/// </summary>
public class CreateIntegralDto
{
    /// <summary>
    /// 积分
    /// </summary>
    public int IntegralValue { get; set; }

    /// <summary>
    /// 得分原因
    /// </summary>
    public string Reason { get; set; }

    /// <summary>
    /// SourceId
    /// </summary>
    public string SourceId { get; set; }

    /// <summary>
    /// 积分类型
    /// </summary>
    public IntegralType Type { get; set; }

    /// <summary>
    /// 操作类型
    /// </summary>
    public OperatorType OperatorType { get; set; }
}
