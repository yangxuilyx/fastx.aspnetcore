using System.ComponentModel.DataAnnotations;
using FastX.Data.SqlSugar.DataAnnotations;

namespace FastXTpl.Template.Core.Manage.Notis;

/// <summary>
/// 通知用户
/// </summary>
[XSugarTable("Manage")]
public class NotiUser
{
    /// <summary>
    /// 通知Id
    /// </summary>
    [Key]
    public Ulid NotiId { get; set; }

    /// <summary>
    /// 用户Id
    /// </summary>
    [Key]
    public Ulid UserId { get; set; }

    /// <summary>
    /// 是否阅读
    /// </summary>
    public bool IsRead { get; set; }

    /// <summary>
    /// 阅读时间
    /// </summary>
    public DateTime? ReadTime { get; set; }
}