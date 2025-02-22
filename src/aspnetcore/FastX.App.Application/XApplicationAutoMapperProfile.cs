using AutoMapper;
using FastX.App.Application.Identity.Ous.Dtos;
using FastX.App.Application.Identity.Roles.Dtos;
using FastX.App.Application.Identity.Users.Dtos;
using FastX.App.Application.Manage.ExamineObjects.Dtos;
using FastX.App.Application.Manage.Examines.Dtos;
using FastX.App.Application.Manage.Fees.Dtos;
using FastX.App.Application.Manage.Integrals.Dtos;
using FastX.App.Application.Manage.Notis.Dtos;
using FastX.App.Application.Manage.Questions.Dtos;
using FastX.App.Application.Manage.Studies.Dtos;
using FastX.App.Application.Manage.Threes.Dtos;
using FastX.App.Core.Identity.Ous;
using FastX.App.Core.Identity.Roles;
using FastX.App.Core.Identity.Users;
using FastX.App.Core.Manage.Examines;
using FastX.App.Core.Manage.Fees;
using FastX.App.Core.Manage.Integrals;
using FastX.App.Core.Manage.Notis;
using FastX.App.Core.Manage.Questions;
using FastX.App.Core.Manage.Studies;
using FastX.App.Core.Manage.Threes;

namespace FastX.App.Application;

/// <summary>
/// XApplicationAutoMapperProfile
/// </summary>
public class XApplicationAutoMapperProfile : Profile
{
    /// <summary>
    /// 
    /// </summary>
    public XApplicationAutoMapperProfile()
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
