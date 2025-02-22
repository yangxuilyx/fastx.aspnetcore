namespace FastX.App.Application.Manage.Integrals.Dtos;

/// <summary>
/// 积分
/// </summary>
public class UpdateIntegralDto
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
    /// 用户Id
    /// </summary>
    public string UserId { get; set; }
    
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
    public int Type { get; set; }
    
}
