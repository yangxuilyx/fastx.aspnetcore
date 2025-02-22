using FastX.App.Core.Manage.Examines;
using System.ComponentModel.DataAnnotations;

namespace FastX.App.Application.Manage.ExamineObjects.Dtos;

public class ExamineObjectDto
{
    /// <summary>
    /// 考核Id
    /// </summary>
    public string ExamineId { get; set; }

    /// <summary>
    /// 对象Id
    /// </summary>
    public string ObjectId { get; set; }

    /// <summary>
    /// 组织Id
    /// </summary>
    public string OuId { get; set; }

    /// <summary>
    /// 考核对象名称
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// 考核完成状态
    /// </summary>
    public ExamineObjectStatus Status { get; set; }

    /// <summary>
    /// 状态
    /// </summary>
    public string StatusDesc => Status.GetDescription();

    /// <summary>
    /// 最终得分
    /// </summary>
    public int Integral { get; set; }
}