using FastX.App.Core.Identity.Users;

namespace FastX.App.Application.Manage.Statistic.Dtos;

public class UserCountDto
{
    /// <summary>
    /// 群众
    /// </summary>
    public int Count0 { get; set; }

    /// <summary>
    /// 正式党员
    /// </summary>
    public int Count1 { get; set; }

    /// <summary>
    /// 预备党员
    /// </summary>
    public int Count2 { get; set; }

    /// <summary>
    /// 发展对象
    /// </summary>
    public int Count3 { get; set; }

    /// <summary>
    /// 入党积极分子
    /// </summary>
    public int Count4 { get; set; }
}