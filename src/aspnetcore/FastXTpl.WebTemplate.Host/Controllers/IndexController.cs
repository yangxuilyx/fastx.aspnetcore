using FastX.Identity.Core.Identity.Users;
using Microsoft.AspNetCore.Mvc;

namespace FastXTpl.WebTemplate.Host.Controllers;

/// <summary>
/// Index
/// </summary>
[ApiController]
[Route("api/[controller]/[action]")]
public class IndexController : ControllerBase
{
    private readonly UserManager _userManager;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userManager"></param>
    public IndexController(UserManager userManager)
    {
        _userManager = userManager;
    }

    /// <summary>
    /// Index
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("/")]
    public ActionResult Index()
    {
        return Redirect("/index.html");
    }

    /// <summary>
    /// 安装系统
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<string> Setup([FromForm] string userName, [FromForm] string password)
    {
        var user = await _userManager.FindByNameAsync("admin");
        if (user != null)
            throw new Exception("请勿重复安装");

        await _userManager.CreateUserAsync(new User()
        {
            UserName = userName,
            Password = password,
            Name = "管理员",
            IsSpecial = true
        });

        return "安装成功";
    }
}