namespace FastXTpl.WebTemplate.Application.Identity.Users.Dtos;

/// <summary>
/// CreateUserDto
/// </summary>
public class CreateUserDto : UserDto
{
    /// <summary>
    /// 密码
    /// </summary>
    public string Password { get; set; }
}