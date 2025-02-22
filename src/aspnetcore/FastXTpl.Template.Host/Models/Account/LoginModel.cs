namespace FastXTpl.Template.Host.Models.Account;

/// <summary>
/// 登录模型
/// </summary>
public class LoginModel
{
    /// <summary>
    /// 用户名
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// 密码
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// 记住我
    /// </summary>
    public bool IsPersistent { get; set; }
}