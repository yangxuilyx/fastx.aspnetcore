using FastX.App.Core.Manage.Examines;

namespace FastX.App.Application.Manage.Examines.Dtos;

/// <summary>
/// 在线考核
/// </summary>
public class CreateExamineDto
{
    /// <summary>
    /// 考核Id
    /// </summary>
    public string ExamineId { get; set; }
    
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

    /// <summary>
    /// 题库列表
    /// </summary>
    public List<string> ExamineQuestionIds { get; set; }

    /// <summary>
    /// 考核对象列表
    /// </summary>
    public List<string> ExamineObjectIds { get; set; }
}
