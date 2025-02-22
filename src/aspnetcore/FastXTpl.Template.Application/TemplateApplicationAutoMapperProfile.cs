using AutoMapper;
using FastXTpl.Template.Application.Identity.Ous.Dtos;
using FastXTpl.Template.Application.Identity.Roles.Dtos;
using FastXTpl.Template.Application.Identity.Users.Dtos;
using FastXTpl.Template.Application.Manage.ExamineObjects.Dtos;
using FastXTpl.Template.Application.Manage.Examines.Dtos;
using FastXTpl.Template.Application.Manage.Fees.Dtos;
using FastXTpl.Template.Application.Manage.Integrals.Dtos;
using FastXTpl.Template.Application.Manage.Notis.Dtos;
using FastXTpl.Template.Application.Manage.Questions.Dtos;
using FastXTpl.Template.Application.Manage.Studies.Dtos;
using FastXTpl.Template.Application.Manage.Threes.Dtos;
using FastXTpl.Template.Core.Identity.Ous;
using FastXTpl.Template.Core.Identity.Roles;
using FastXTpl.Template.Core.Identity.Users;
using FastXTpl.Template.Core.Manage.Examines;
using FastXTpl.Template.Core.Manage.Fees;
using FastXTpl.Template.Core.Manage.Integrals;
using FastXTpl.Template.Core.Manage.Notis;
using FastXTpl.Template.Core.Manage.Questions;
using FastXTpl.Template.Core.Manage.Studies;
using FastXTpl.Template.Core.Manage.Threes;

namespace FastXTpl.Template.Application;

/// <summary>
/// XApplicationAutoMapperProfile
/// </summary>
public class TemplateApplicationAutoMapperProfile : Profile
{
    /// <summary>
    /// 
    /// </summary>
    public TemplateApplicationAutoMapperProfile()
    {
        CreateMap<UserDto, User>().ReverseMap();
        CreateMap<CreateUserDto, User>().ReverseMap();

        CreateMap<Ou, OuDto>().ReverseMap();
        CreateMap<Ou, CreateOuDto>().ReverseMap();

        CreateMap<Role, RoleDto>().ReverseMap();

        CreateMap<Fee, FeeDto>().ReverseMap();
        CreateMap<Fee, CreateFeeDto>().ReverseMap();

        CreateMap<Three, ThreeDto>().ReverseMap();
        CreateMap<Three, CreateThreeDto>().ReverseMap();

        CreateMap<Noti, NotiDto>().ReverseMap();

        CreateMap<Study, StudyDto>().ReverseMap();

        CreateMap<Integral, IntegralDto>().ReverseMap();

        CreateMap<Question, QuestionDto>().ReverseMap();
        CreateMap<Question, CreateQuestionDto>().ReverseMap();

        CreateMap<Examine, ExamineDto>().ReverseMap();
        CreateMap<Examine, CreateExamineDto>().ReverseMap();
        CreateMap<ExamineObject, ExamineObjectDto>().ReverseMap();
    }
}
