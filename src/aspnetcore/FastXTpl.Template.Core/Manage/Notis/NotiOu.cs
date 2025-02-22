using System.ComponentModel.DataAnnotations;
using FastX.Data.Entities;
using FastX.Data.SqlSugar.DataAnnotations;

namespace FastXTpl.Template.Core.Manage.Notis;

/// <summary>
/// 通知部门
/// </summary>
[XSugarTable("Manage")]
public class NotiOu : Entity
{
    /// <summary>
    /// 通知Id
    /// </summary>
    [Key]
    public Ulid NotiId { get; set; }

    /// <summary>
    /// 部门Id
    /// </summary>
    [Key]
    public Ulid OuId { get; set; }
}