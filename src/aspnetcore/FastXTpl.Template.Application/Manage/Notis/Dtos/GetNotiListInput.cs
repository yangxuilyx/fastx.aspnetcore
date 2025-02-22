using FastX.Application.Dtos;
using FastX.Data.PagedResult;
using FastXTpl.Template.Core.Manage;
using FastXTpl.Template.Core.Manage.Notis;

namespace FastXTpl.Template.Application.Manage.Notis.Dtos;

/// <summary>
/// 获取通知输入
/// </summary>
public class GetNotiListInput : IPagedResultRequest, ISortedResultRequest
{
    /// <summary>
    /// 类型
    /// </summary>
    public NotiType NotiType { get; set; }

    /// <summary>
    /// 标题
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// 分页信息
    /// </summary>
    public PageInfo Page { get; set; }

    /// <summary>
    /// 发布状态
    /// </summary>
    public NotiStatus? NotiStatus { get; set; }

    /// <summary>
    /// 组织Id
    /// </summary>
    public string? OuId { get; set; }

    /// <summary>
    /// 分页
    /// </summary>
    public string? Sorting { get; set; } = "NotiId DESC";
}