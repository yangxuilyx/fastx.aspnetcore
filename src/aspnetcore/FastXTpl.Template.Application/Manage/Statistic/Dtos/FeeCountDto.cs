namespace FastX.App.Application.Manage.Statistic.Dtos;

public class FeeCountDto
{
    /// <summary>
    /// 已缴费
    /// </summary>
    public int PaidCount { get; set; }

    /// <summary>
    /// 未缴费
    /// </summary>
    public int NotPaidCount { get; set; }
}