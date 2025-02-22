using FastX.AspNetCore;
using FastXTpl.Template.Application.Manage.ExamineObjectQuestions.Dtos;

namespace FastXTpl.Template.Application.Manage.ExamineObjectQuestions;

/// <summary>
/// 考核对象题库
/// </summary>
public interface IExamineObjectQuestionAppService : IApplicationService
{
    /// <summary>
    /// 获取全部
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<List<ExamineObjectQuestionDto>> GetAll(GetListExamineObjectQuestionInput input);

    /// <summary>
    /// 更新考核
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<ExamineObjectQuestionDto> UpdateContent(UpdateContentInput input);

    /// <summary>
    /// 部门审核
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<ExamineObjectQuestionDto> Pend1(Pend1Input input);

    /// <summary>
    /// 办公室审核
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<ExamineObjectQuestionDto> Pend2(Pend2Input input);
}