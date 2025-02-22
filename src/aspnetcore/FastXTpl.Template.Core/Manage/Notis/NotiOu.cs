using FastX.Data;
using FastX.Data.SqlSugar.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using FastX.Data.Entities;

namespace FastX.App.Core.Manage.Notis;

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