using FastX.App.Application.Manage.ExamineObjectQuestions.Dtos;
using FastX.App.Application.Manage.Questions.Dtos;
using FastX.App.Core.Identity.Users;
using FastX.App.Core.Manage.Examines;
using FastX.App.Core.Manage.Integrals;
using FastX.App.Core.Manage.Questions;
using FastX.Application.Services;
using FastX.Data.Repository;
using Microsoft.AspNetCore.Authorization;

namespace FastX.App.Application.Manage.ExamineObjectQuestions;

/// <summary>
/// 考核对象题库
/// </summary>
[Authorize]
public class ExamineObjectQuestionAppService : ApplicationService, IExamineObjectQuestionAppService
{
    private readonly IRepository<Examine> _examineRepository;
    private readonly IRepository<Question> _questionRepository;
    private readonly IRepository<ExamineObject> _examineObjectRepository;
    private readonly IRepository<ExamineQuestion> _examineQuestionRepository;
    private readonly IRepository<ExamineObjectQuestion> _examineObjectQuestionRepository;
    private readonly IRepository<User> _userRepository;
    private readonly IRepository<Integral> _integralRepository;

    /// <summary>
    /// 
    /// </summary>
    public ExamineObjectQuestionAppService(IRepository<Examine> examineRepository, IRepository<ExamineQuestion> examineQuestionRepository, IRepository<ExamineObjectQuestion> examineObjectQuestionRepository, IRepository<User> userRepository, IRepository<Question> questionRepository, IRepository<ExamineObject> examineObjectRepository, IRepository<Integral> integralRepository)
    {
        _examineRepository = examineRepository;
        _examineQuestionRepository = examineQuestionRepository;
        _examineObjectQuestionRepository = examineObjectQuestionRepository;
        _userRepository = userRepository;
        _questionRepository = questionRepository;
        _examineObjectRepository = examineObjectRepository;
        _integralRepository = integralRepository;
    }

    /// <summary>
    /// 获取全部
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<List<ExamineObjectQuestionDto>> GetAll(GetListExamineObjectQuestionInput input)
    {
        var examine = await _examineRepository.GetAsync(input.ExamineId);
        if (examine == null)
            throw new UserFriendlyException("考核不存在");

        var objectId = input.ObjectId;
        if (objectId.IsNullOrEmpty())
        {
            objectId = CurrentUser.UserId;
            if (examine.ExamineType == ExamineType._0)
            {
                var user = await _userRepository.GetAsync(CurrentUser.UserId);
                objectId = user?.OuId;
            }
        }

        if (objectId == null)
            throw new UserFriendlyException("考核对象不存在");

        var examineQuestions = await _examineQuestionRepository.GetListAsync(p => p.ExamineId == examine.ExamineId);

        var examineObjectQuestionDtos = await Task.WhenAll(examineQuestions.Select(async examineQuestion =>
        {
            var question = await _questionRepository.GetAsync(examineQuestion.QuestionId);
            var examineObjectQuestion = await _examineObjectQuestionRepository.GetAsync(p => p.ExamineId == examine.ExamineId && p.ObjectId == objectId && p.QuestionId == examineQuestion.QuestionId);

            return new ExamineObjectQuestionDto
            {
                ExamineId = examine.ExamineId,
                QuestionId = examineQuestion.QuestionId,
                Content = examineObjectQuestion?.Content,
                FileUrl = examineObjectQuestion?.FileUrl,
                Question = ObjectMapper.Map<QuestionDto>(question)
            };
        }));

        return examineObjectQuestionDtos.ToList();
    }

    /// <summary>
    /// 更新考核
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<ExamineObjectQuestionDto> UpdateContent(UpdateContentInput input)
    {
        var examine = await _examineRepository.GetAsync(input.ExamineId);
        if (examine == null)
            throw new UserFriendlyException("考核不存在");

        var objectId = CurrentUser.UserId;
        if (examine.ExamineType == ExamineType._0)
        {
            var user = await _userRepository.GetAsync(CurrentUser.UserId);
            objectId = user.OuId;
        }
        if (objectId == null)
            throw new UserFriendlyException("考核对象不存在");

        var examineObject = await _examineObjectRepository.GetAsync(p => p.ExamineId == input.ExamineId && p.ObjectId == objectId);
        if (examineObject == null)
            throw new UserFriendlyException("考核对象不存在");
        if (examineObject.Status != ExamineObjectStatus._0)
            return new ExamineObjectQuestionDto();

        var examineObjectQuestion = await _examineObjectQuestionRepository.GetAsync(p => p.ExamineId == examine.ExamineId && p.ObjectId == objectId && p.QuestionId == input.QuestionId);
        if (examineObjectQuestion == null)
        {
            examineObjectQuestion = new ExamineObjectQuestion()
            {
                ExamineId = examine.ExamineId,
                ObjectId = objectId,
                QuestionId = input.QuestionId,
                Content = input.Content,
                FileUrl = input.FileUrl ?? string.Empty,
            };
            await _examineObjectQuestionRepository.InsertAsync(examineObjectQuestion);
        }
        else
        {
            examineObjectQuestion.Content = input.Content;
            examineObjectQuestion.FileUrl = input.FileUrl ?? string.Empty;

            await _examineObjectQuestionRepository.UpdateAsync(examineObjectQuestion);
        }

        if (input.IsComplete)
        {
            if (examineObject != null)
            {
                examineObject.Status = ExamineObjectStatus._1;
                examineObject.CompleteDate = DateTime.Now;

                await _examineObjectRepository.UpdateAsync(examineObject);
            }
        }

        return new ExamineObjectQuestionDto();
    }

    /// <summary>
    /// 部门审核
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<ExamineObjectQuestionDto> Pend1(Pend1Input input)
    {
        var examine = await _examineRepository.GetAsync(input.ExamineId);
        if (examine == null)
            throw new UserFriendlyException("考核不存在");

        var examineObject = await _examineObjectRepository.GetAsync(p => p.ExamineId == input.ExamineId && p.ObjectId == input.ObjectId);
        if (examineObject == null)
            throw new UserFriendlyException("未找到考核对象");

        var examineObjectQuestions = await Task.WhenAll(input.Items.Select(async t =>
        {
            var examineObjectQuestion = await _examineObjectQuestionRepository.GetAsync(p =>
                p.ExamineId == input.ExamineId && p.ObjectId == input.ObjectId && p.QuestionId == t.QuestionId);
            if (examineObjectQuestion == null)
                return new ExamineObjectQuestion();

            examineObjectQuestion.AddIntegral = t.AddIntegral;
            examineObjectQuestion.SubIntegral = t.SubIntegral;
            examineObjectQuestion.Integral = t.Integral + t.AddIntegral - t.SubIntegral;

            await _examineObjectQuestionRepository.UpdateAsync(examineObjectQuestion);

            return examineObjectQuestion;
        }));

        examineObject.Integral = examineObjectQuestions.Sum(t => t.Integral);
        if (examine.ExamineType == ExamineType._0)
        {
            examineObject.Status = ExamineObjectStatus._3;
        }
        else
        {
            examineObject.Status = ExamineObjectStatus._5;
            await CreateIntegralAsync(examineObject, examine);
        }

        await _examineObjectRepository.UpdateAsync(examineObject);

        return new ExamineObjectQuestionDto();
    }

    /// <summary>
    /// 办公室审核
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<ExamineObjectQuestionDto> Pend2(Pend2Input input)
    {
        var examineObject = await _examineObjectRepository.GetAsync(p => p.ExamineId == input.ExamineId && p.ObjectId == input.ObjectId);
        if (examineObject == null)
            throw new UserFriendlyException("未找到考核对象");

        var examine = await _examineRepository.GetAsync(input.ExamineId);
        if (examine == null)
            throw new UserFriendlyException("考核不存在");

        examineObject.Status = !input.Allow ? ExamineObjectStatus._4 : ExamineObjectStatus._5;
        await _examineObjectRepository.UpdateAsync(examineObject);

        if (examineObject.Status == ExamineObjectStatus._5)
        {
            await CreateIntegralAsync(examineObject, examine);
        }

        return new ExamineObjectQuestionDto();
    }

    private async Task CreateIntegralAsync(ExamineObject examineObject, Examine examine)
    {
        await _integralRepository.InsertAsync(new Integral()
        {
            IntegralValue = examineObject.Integral,
            OperatorId = examineObject.ObjectId,
            OperatorType = examine.ExamineType == ExamineType._0 ? OperatorType.Ou : OperatorType.User,
            CreateDate = DateTime.Now,
            Reason = $"完成考核:{examine.Title}",
            SourceId = examine.ExamineId,
            Type = IntegralType._2
        });
    }
}