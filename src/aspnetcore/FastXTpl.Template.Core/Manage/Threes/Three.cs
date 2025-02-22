using FastX.Data;
using FastX.Data.Entities;
using FastX.Data.Entities.AuditEntities;
using FastX.Data.SqlSugar.DataAnnotations;
using SqlSugar;

namespace FastX.App.Core.Manage.Threes;

/// <summary>
/// 三会一课
/// </summary>
[XSugarTable("Manage")]
public class Three : AuditEntity
{
    /// <summary>
    /// 三会一课Id
    /// </summary>
    public Ulid ThreeId { get; set; }

    /// <summary>
    /// 标题
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// 开始时间
    /// </summary>
    public DateTime StartTime { get; set; }

    /// <summary>
    /// 结束时间
    /// </summary>
    public DateTime EndTime { get; set; }

    /// <summary>
    /// 会议图片
    /// </summary>
    public string? Pic { get; set; }

    /// <summary>
    /// 内容
    /// </summary>
    [SugarColumn(ColumnDataType = "text")]
    public string Content { get; set; }

    /// <summary>
    /// 用户列表
    /// </summary>
    public string UserIds { get; set; }

    /// <summary>
    /// 组织列表
    /// </summary>
    public string OuIds { get; set; }
}