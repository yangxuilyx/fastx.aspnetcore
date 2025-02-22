using FastX.App.Application.Manage.Questions.Dtos;
using FastX.Application.Services;
using FastX.Data.Repository;
using SqlSugar;
using FastX.App.Core.Manage.Questions;

namespace FastX.App.Application.Manage.Questions;

/// <summary>
/// 题库
/// </summary>
public class QuestionAppService : CrudAppService<Question, string, QuestionDto, GetQuestionListInput, CreateQuestionDto, UpdateQuestionDto>, IQuestionAppService
{
    /// <summary>
    /// 
    /// </summary>
    public QuestionAppService(IRepository<Question> repository) : base(repository)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    protected override ISugarQueryable<Question> CreateFilteredQuery(GetQuestionListInput input)
    {
        return base.CreateFilteredQuery(input)
                .WhereIF(input.QuestionType.HasValue, p => p.QuestionType == input.QuestionType)
        ;
    }

    /// <summary>
    /// 获取所有
    /// </summary>
    /// <returns></returns>
    public async Task<List<QuestionDto>> GetAll(GetAllInput input)
    {
        var questions = await Repository.GetListAsync(p => p.QuestionType == input.QuestionType);

        return await MapToEntityDtoList(questions);
    }
}