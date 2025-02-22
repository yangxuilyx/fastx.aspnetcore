using FastX.MultiTenancy;
using FastX.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FastXTpl.Template.Host.Controllers;

/// <summary>
/// XController
/// </summary>
[ApiController]
[Route("api/[controller]/[action]")]
[Authorize]
public abstract class XController : ControllerBase
{
    /// <summary>
    /// ServiceProvider
    /// </summary>
    public IServiceProvider ServiceProvider { get; set; } = default!;

    /// <summary>
    /// CurrentTenant
    /// </summary>
    protected ICurrentTenant CurrentTenant => ServiceProvider.GetRequiredService<ICurrentTenant>();

    /// <summary>
    /// CurrentUser
    /// </summary>
    protected ICurrentUser CurrentUser => ServiceProvider.GetRequiredService<ICurrentUser>();
}