using FastX.App.Core.Identity.Users;
using FastX.App.Host.Models.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FastX.Data.Repository;

namespace FastX.App.Host.Controllers;

/// <summary>
/// Account
/// </summary>
[Route("api/[controller]/[action]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly SignInManager _signInManager;
    private readonly IRepository<User> _userRepository;

    /// <summary>
    /// 
    /// </summary>
    public AccountController(IConfiguration configuration, SignInManager signInManager, IRepository<User> userRepository)
    {
        _configuration = configuration;
        _signInManager = signInManager;
        _userRepository = userRepository;
    }

    /// <summary>
    /// 登录
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    [HttpPost]
    public async Task<LoginResult> Login(LoginModel input)
    {
        var signInResult = await _signInManager.PasswordSignInAsync(input.UserName, input.Password, input.IsPersistent);
        if (signInResult.Succeeded)
        {
            var claims = new List<Claim>();

            return CreateToken(HttpContext.User, claims);
        }
        throw new Exception("登录失败");
    }

    private LoginResult CreateToken(ClaimsPrincipal principal, List<Claim> externalClaim)
    {
        // 1. 定义需要使用到的Claims

        // 2. 从 appsettings.json 中读取SecretKey
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));

        // 3. 选择加密算法
        var algorithm = SecurityAlgorithms.HmacSha256;

        // 4. 生成Credentials
        var signingCredentials = new SigningCredentials(secretKey, algorithm);

        var expires = new DateTimeOffset(DateTime.Now.AddYears(1));

        // 5. 根据以上，生成token
        var jwtSecurityToken = new JwtSecurityToken(
            _configuration["Jwt:Issuer"],     //Issuer
            _configuration["Jwt:Audience"],   //Audience
            principal.Claims,                          //Claims,
            DateTime.Now,                    //notBefore
            expires.DateTime,    //expires
            signingCredentials               //Credentials
        );

        // 6. 将token变为string
        var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

        return new LoginResult()
        {
            AccessToken = token,
            ExpireIn = expires.ToUnixTimeSeconds()
        };
    }
}