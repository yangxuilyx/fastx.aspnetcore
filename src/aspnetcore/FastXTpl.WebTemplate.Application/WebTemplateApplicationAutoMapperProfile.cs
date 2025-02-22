using AutoMapper;
using FastXTpl.WebTemplate.Application.Identity.Ous.Dtos;
using FastXTpl.WebTemplate.Application.Identity.Roles.Dtos;
using FastXTpl.WebTemplate.Application.Identity.Users.Dtos;
using FastXTpl.WebTemplate.Core.Identity.Ous;
using FastXTpl.WebTemplate.Core.Identity.Roles;
using FastXTpl.WebTemplate.Core.Identity.Users;

namespace FastXTpl.WebTemplate.Application;

/// <summary>
/// XApplicationAutoMapperProfile
/// </summary>
public class WebTemplateApplicationAutoMapperProfile : Profile
{
    /// <summary>
    /// 
    /// </summary>
    public WebTemplateApplicationAutoMapperProfile()
    {
        CreateMap<UserDto, User>().ReverseMap();
        CreateMap<CreateUserDto, User>().ReverseMap();

        CreateMap<Ou, OuDto>().ReverseMap();
        CreateMap<Ou, CreateOuDto>().ReverseMap();

        CreateMap<Role, RoleDto>().ReverseMap();
    }
}
