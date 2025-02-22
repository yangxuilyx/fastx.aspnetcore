using FastXTpl.WebTemplate.Core.Identity.Users;

namespace FastXTpl.WebTemplate.Application.Identity.Users.Dtos;

public class UserDto
{
    /// <summary>
    /// 用户Id
    /// </summary>
    public string UserId { get; set; }

    /// <summary>
    /// 用户名
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// 姓名
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 手机号码
    /// </summary>
    public string PhoneNumber { get; set; }

    /// <summary>
    /// 身份证号
    /// </summary>
    public string IdNo { get; set; }

    /// <summary>
    /// 党员类型  
    /// </summary>
    public UserType UserType { get; set; }

    /// <summary>
    /// 党员类型
    /// </summary>
    public string UserTypeDesc => UserType.GetDescription();

    /// <summary>
    /// 组织Id
    /// </summary>
    public string? OuId { get; set; }

    /// <summary>
    /// 职务
    /// </summary>
    public string Position { get; set; }

    /// <summary>
    /// 职务
    /// </summary>
    public PositionType PositionType { get; set; }

    /// <summary>
    /// 职务
    /// </summary>
    public string PositionTypeDesc => PositionType.GetDescription();

    /// <summary>
    /// 角色
    /// </summary>
    public List<string> Roles { get; set; } = new();
}