using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using FastX.Data.Entities;
using FastX.Data.SqlSugar.DataAnnotations;

namespace FastXTpl.Template.Core.Manage.Examines;

/// <summary>
/// 考核对象
/// </summary>
[XSugarTable("Manage")]
public class ExamineObject : Entity
{
    /// <summary>
    /// 考核Id
    /// </summary>
    [Key]
    public Ulid ExamineId { get; set; }

    /// <summary>
    /// 对象Id
    /// </summary>
    [Key]
    public Ulid ObjectId { get; set; }

    /// <summary>
    /// 考核对象名称
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// 考核完成状态
    /// </summary>
    public ExamineObjectStatus Status { get; set; }

    /// <summary>
    /// 完成时间
    /// </summary>
    public DateTime? CompleteDate { get; set; }

    /// <summary>
    /// 最终得分
    /// </summary>
    public int Integral { get; set; }
}

public enum ExamineObjectStatus
{
    /// <summary>
    /// 待考核
    /// </summary>
    [Description("待考核")]
    _0,

    [Description("待部门审核")]
    _1,

    [Description("部门审核不通过")]
    _2,

    [Description("待办公室审核")]
    _3,

    [Description("办公室审核不通过")]
    _4,

    /// <summary>
    /// 已完成
    /// </summary>
    [Description("已完成")]
    _5
}
