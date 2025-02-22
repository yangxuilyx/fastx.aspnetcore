using FastX;
using FastX.Application.Services;
using FastX.Data.Repository;
using FastXTpl.Template.Application.Manage.ExamineObjects.Dtos;
using FastXTpl.Template.Core.Identity.Users;
using FastXTpl.Template.Core.Manage.Examines;
using SqlSugar;

namespace FastXTpl.Template.Application.Manage.ExamineObjects;

public class ExamineObjectAppService:ReadOnlyAppService<ExamineObject,string,ExamineObjectDto,GetExamineObjectListInput>,IExamineObjectAppService
{
    private readonly IRepository<Examine> _examineRepository;
    private readonly IRepository<User> _userRepository;

    /// <summary>
    /// 
    /// </summary>
    public ExamineObjectAppService(IRepository<ExamineObject> repository, IRepository<Examine> examineRepository, IRepository<User> userRepository) : base(repository)
    {
        _examineRepository = examineRepository;
        _userRepository = userRepository;
    }

    protected override async Task<ExamineObjectDto> MapToEntityDto(ExamineObject entity)
    {
        var dto = await base.MapToEntityDto(entity);

        var examine = await _examineRepository.GetAsync(dto.ExamineId);
        if (examine == null)
        {
            throw new UserFriendlyException("考核不存在");
        }

        if (examine.ExamineType == ExamineType._0)
        {
            dto.OuId = dto.ObjectId;
        }
        else
        {
            var user = await _userRepository.GetAsync(dto.ObjectId);
            dto.OuId = user?.OuId;
        }

        return dto;
    }

    protected override ISugarQueryable<ExamineObject> CreateFilteredQuery(GetExamineObjectListInput input)
    {
        return base.CreateFilteredQuery(input)
                .Where(p=>p.ExamineId == input.ExamineId)
            ;
    }
}