using FastX.App.Core.Manage.Integrals;

namespace FastX.App.Application.Manage.Integrals.Dtos;

/// <summary>
/// 积分
/// </summary>
public class IntegralDto
{
    /// <summary>
    /// 积分Id
    /// </summary>
    public string IntegralId { get; set; }

    /// <summary>
    /// 积分
    /// </summary>
    public int IntegralValue { get; set; }

    /// <summary>
    /// 用户Id/组织Id
    /// </summary>
    public Ulid OperatorId { get; set; }

    /// <summary>
    /// 用户/组织
    /// </summary>
    public string OperatorName { get; set; }

    /// <summary>
    /// 操作类型
    /// </summary>
    public OperatorType OperatorType { get; set; }

    /// <summary>
    /// 操作类型
    /// </summary>
    public string OperatorTypeDesc => OperatorType.GetDescription();

    /// <summary>
    /// 积分时间
    /// </summary>
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// 得分原因
    /// </summary>
    public string Reason { get; set; }

    /// <summary>
    /// 积分类型
    /// </summary>
    public IntegralType Type { get; set; }

    /// <summary>
    /// 积分类型
    /// </summary>
    public string TypeDesc => Type.GetDescription();

}
