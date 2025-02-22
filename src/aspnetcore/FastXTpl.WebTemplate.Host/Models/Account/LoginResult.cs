namespace FastXTpl.WebTemplate.Host.Models.Account;

public class LoginResult
{
    /// <summary>
    /// token
    /// </summary>
    public string AccessToken { get; set; }

    /// <summary>
    /// 过期时间
    /// </summary>
    public long ExpireIn { get; set; }
}