using Microsoft.AspNetCore.Mvc;

namespace FastXTpl.WebTemplate.Host.Controllers;

/// <summary>
/// Index
/// </summary>
[ApiController]
[Route("api/[controller]/[action]")]
public class IndexController : ControllerBase
{
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
}