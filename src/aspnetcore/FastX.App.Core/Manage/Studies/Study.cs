using FastX.Data;
using FastX.Data.SqlSugar.DataAnnotations;

namespace FastX.App.Core.Manage.Studies;

/// <summary>
/// 课程
/// </summary>
[XSugarTable("Manage")]
public class Study : AuditEntity
{
    /// <summary>
    /// 课程Id
    /// </summary>
    public Ulid StudyId { get; set; }

    /// <summary>
    /// 课程名称
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// 课程说明
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// 章节名称
    /// </summary>
    public string ChapterTitle { get; set; }

    /// <summary>
    /// 章节时长
    /// </summary>
    public int ChapterLength { get; set; }

    /// <summary>
    /// 封面图片
    /// </summary>
    public string PicUrl { get; set; }

    /// <summary>
    /// 视频链接
    /// </summary>
    public string VideoUrl { get; set; }

    /// <summary>
    /// 积分
    /// </summary>
    public int Integral { get; set; }

    /// <summary>
    /// 发布状态
    /// </summary>
    public NotiStatus Status { get; set; }
}