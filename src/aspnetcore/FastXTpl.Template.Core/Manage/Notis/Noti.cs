using FastX.Data.Entities.AuditEntities;
using FastX.Data.SqlSugar.DataAnnotations;
using SqlSugar;

namespace FastXTpl.Template.Core.Manage.Notis;

/// <summary>
/// 通知
/// </summary>
[XSugarTable("Manage")]
public class Noti : AuditEntity
{
    /// <summary>
    /// 通知Id
    /// </summary>
    public Ulid NotiId { get; set; }

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
    [SugarColumn(ColumnDataType = "text")]
    public string Content { get; set; }
}

/// <summary>
/// 通知类型
/// </summary>
public enum NotiType
{
    /// <summary>
    /// 党建动态
    /// </summary>
    _0,

    /// <summary>
    /// 组织活动
    /// </summary>
    _1
}
