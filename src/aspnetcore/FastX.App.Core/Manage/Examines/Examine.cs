using System.ComponentModel;
using FastX.Data;
using FastX.Data.DataFilters;
using FastX.Data.Entities;
using FastX.Data.SqlSugar.DataAnnotations;

namespace FastX.App.Core.Manage.Examines;

/// <summary>
/// 在线考核
/// </summary>
[XSugarTable("Manage")]
public class Examine : AuditEntity
{
    /// <summary>
    /// 考核Id
    /// </summary>
    public Ulid ExamineId { get; set; }

    /// <summary>
    /// 考核类型
    /// </summary>
    public ExamineType ExamineType { get; set; }

    /// <summary>
    /// 考核周期
    /// </summary>
    public TimeType TimeType { get; set; }

    /// <summary>
    /// 开始日期
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>
    /// 结束日期
    /// </summary>
    public DateTime EndDate { get; set; }

    /// <summary>
    /// 考核标题
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// 封面图
    /// </summary>
    public string Pic { get; set; }

    /// <summary>
    /// 部门审核人员
    /// </summary>
    public string DepartmentPendUserId { get; set; }

    /// <summary>
    /// 办公室审核人员
    /// </summary>
    public string OfficePendUserId { get; set; }

}

public enum ExamineType
{
    /// <summary>
    /// 部门考核
    /// </summary>
    [Description("部门考核")]
    _0,

    /// <summary>
    /// 用户考核
    /// </summary>
    [Description("工作")]
    _1
}

public enum TimeType
{
    [Description("周")]
    Week,

    [Description("月")]
    Month,

    [Description("季度")]
    Session,

    [Description("年")]
    Year
}