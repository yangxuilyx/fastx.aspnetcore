using FastX.Application.Services;
using FastX.Data.Repository;
using FastXTpl.Template.Application.Manage.Examines.Dtos;
using FastXTpl.Template.Core.Identity.Ous;
using FastXTpl.Template.Core.Identity.Users;
using FastXTpl.Template.Core.Manage.Examines;
using FastXTpl.Template.Core.Manage.Questions;
using Microsoft.AspNetCore.Authorization;
using SqlSugar;

namespace FastXTpl.Template.Application.Manage.Examines;

/// <summary>
/// 在线考核
/// </summary>
[Authorize]
public class ExamineAppService : CrudAppService<Examine, string, ExamineDto, GetExamineListInput, CreateExamineDto, UpdateExamineDto>, IExamineAppService
{
    private readonly IRepository<User> _userRepository;
    private readonly IRepository<Ou> _ouRepository;
    private readonly IRepository<Question> _questionRepository;
    private readonly IRepository<ExamineObject> _examineObjectRepository;
    private readonly IRepository<ExamineQuestion> _examineQuestionRepository;

    /// <summary>
    /// 
    /// </summary>
    public ExamineAppService(IRepository<Examine> repository, IRepository<User> userRepository, IRepository<Ou> ouRepository, IRepository<Question> questionRepository, IRepository<ExamineObject> examineObjectRepository, IRepository<ExamineQuestion> examineQuestionRepository) : base(repository)
    {
        _userRepository = userRepository;
        _ouRepository = ouRepository;
        _questionRepository = questionRepository;
        _examineObjectRepository = examineObjectRepository;
        _examineQuestionRepository = examineQuestionRepository;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    protected override ISugarQueryable<Examine> CreateFilteredQuery(GetExamineListInput input)
    {
        var queryable = base.CreateFilteredQuery(input)
            .Where(p => p.ExamineType == input.ExamineType);

        if (!input.ExamineObjectId.IsNullOrEmptyUlid())
        {
            queryable = queryable
                  .LeftJoin<ExamineObject>((examine, o) => examine.ExamineId == o.ExamineId)
                  .Where((examine, o) => o.ObjectId == input.ExamineObjectId);
        }

        return queryable;
    }

    public override async Task<ExamineDto> InsertOrUpdateAsync(CreateExamineDto input)
    {
        var dto = await base.InsertOrUpdateAsync(input);

        var examineQuestions = await _examineQuestionRepository.GetListAsync(p => p.ExamineId == dto.ExamineId);
        await Task.WhenAll(examineQuestions.Where(p => !input.ExamineQuestionIds.Contains(p.QuestionId)).Select(
            async t =>
            {
                await _examineQuestionRepository.DeleteAsync(t);
            }));

        foreach (var questionId in input.ExamineQuestionIds)
        {
            if (examineQuestions.All(p => p.QuestionId != questionId))
                await _examineQuestionRepository.InsertAsync(new ExamineQuestion()
                { ExamineId = dto.ExamineId, QuestionId = questionId });
        }

        var examineObjects = await _examineObjectRepository.GetListAsync(p => p.ExamineId == dto.ExamineId);
        await Task.WhenAll(examineObjects.Where(p => !input.ExamineObjectIds.Contains(p.ObjectId)).Select(
            async t =>
            {
                await _examineObjectRepository.DeleteAsync(t);
            }));

        foreach (var objectId in input.ExamineObjectIds)
        {
            var name = string.Empty;
            if (dto.ExamineType == ExamineType._0)
            {
                name = (await _ouRepository.GetAsync(objectId))?.Name;
            }
            else
            {
                name = (await _userRepository.GetAsync(objectId))?.Name;
            }
            await _examineObjectRepository.InsertOrUpdateAsync(new ExamineObject()
            { ExamineId = dto.ExamineId, 
                ObjectId = objectId,
                Name = name,
                Status = ExamineObjectStatus._0

            });
        }

        return dto;
    }

    protected override async Task<ExamineDto> MapToEntityDto(Examine entity)
    {
        var dto = await base.MapToEntityDto(entity);

        dto.DepartmentPendUserName = (await _userRepository.GetAsync(dto.DepartmentPendUserId))?.Name;
        dto.OfficePendUserName = (await _userRepository.GetAsync(dto.OfficePendUserId))?.Name;

        var examineQuestions = await _examineQuestionRepository.GetListAsync(p => p.ExamineId == dto.ExamineId);
        //var questions = (await Task.WhenAll(examineQuestions.Select(async t => await _questionRepository.GetAsync(t.QuestionId))));
        dto.ExamineQuestionIds = examineQuestions.Select(t => t.QuestionId.ToString()).ToList();

        //if (dto.ExamineType == ExamineType._0)
        //{

        //}
        var examineObjects = await _examineObjectRepository.GetListAsync(p => p.ExamineId == dto.ExamineId);
        dto.ExamineObjectIds = examineObjects.Select(t => t.ObjectId.ToString()).ToList();

        var user = await _userRepository.GetAsync(CurrentUser.UserId);
        if (user == null)
            return dto;

        if (dto.ExamineType == ExamineType._0 && user.OuId.HasValue)
        {
            var examineObject = await _examineObjectRepository.GetAsync(p => p.ExamineId == dto.ExamineId && p.ObjectId == user.OuId.Value);

            if (examineObject != null)
            {
                dto.Status = examineObject.Status;
                dto.Integral = examineObject.Integral;
            }
        }
        else
        {
            var examineObject = await _examineObjectRepository.GetAsync(p => p.ExamineId == dto.ExamineId && p.ObjectId == user.UserId);

            if (examineObject != null)
            {
                dto.Status = examineObject.Status;
                dto.Integral = examineObject.Integral;
            }
        }

        return dto;
    }
}