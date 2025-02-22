using AutoMapper;
using FastXTpl.Template.Application.Identity.Ous.Dtos;
using FastXTpl.Template.Application.Identity.Roles.Dtos;
using FastXTpl.Template.Application.Identity.Users.Dtos;
using FastXTpl.Template.Core.Identity.Ous;
using FastXTpl.Template.Core.Identity.Roles;
using FastXTpl.Template.Core.Identity.Users;

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
    }
}
