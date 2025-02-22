using FastX.App.Core.Manage;
using FastX.App.Core.Manage.Notis;

namespace FastX.App.Application.Manage.Notis.Dtos;

public class NotiDto
{
    /// <summary>
    /// 通知Id
    /// </summary>
    public string NotiId { get; set; }

    /// <summary>
    /// 类型
    /// </summary>
    public NotiType Type { get; set; }

    /// <summary>
    /// 标题
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// 标题图
    /// </summary>
    public string? Pic { get; set; }

    /// <summary>
    /// 积分
    /// </summary>
    public int Integral { get; set; }

    /// <summary>
    /// 状态
    /// </summary>
    public NotiStatus Status { get; set; }

    /// <summary>
    /// 状态
    /// </summary>
    public string StatusDesc => Status.GetDescription();

    /// <summary>
    /// 排序值
    /// </summary>
    public int Sort { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreateTime { get; set; }

    /// <summary>
    /// 内容
    /// </summary>
    public string Content { get; set; }

    /// <summary>
    /// 通知部门列表
    /// </summary>
    public List<string> NotiOus { get; set; }
}