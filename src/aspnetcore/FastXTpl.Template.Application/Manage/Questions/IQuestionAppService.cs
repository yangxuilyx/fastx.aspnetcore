using FastXTpl.Template.Application.Manage.Questions.Dtos;

namespace FastXTpl.Template.Application.Manage.Questions;

/// <summary>
/// 题库
/// </summary>
public interface IQuestionAppService
{
    /// <summary>
    /// 获取所有
    /// </summary>
    /// <returns></returns>
    Task<List<QuestionDto>> GetAll(GetAllInput input);
}