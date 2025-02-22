namespace FastX.App.Application.Manage.Integrals.Dtos;

/// <summary>
/// 积分汇总
/// </summary>
public class IntegralCountDto
{
    /// <summary>
    /// 操作对象名称
    /// </summary>
    public string OperationName { get; set; }

    /// <summary>
    /// 总积分
    /// </summary>
    public int Total { get; set; }
}