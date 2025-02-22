using FastX.App.Core;
using FastX.AspNetCore;
using FastX.Authorization;
using FastX.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace FastX.App.Application;

[DependsOn(
    typeof(XAspNetCoreModule),
    typeof(FastXAppCoreModule))]
public class FastXAppApplicationModule : XModule
{
    /// <summary>
    /// ConfigurationService
    /// </summary>
    /// <param name="services"></param>
    public override void ConfigurationService(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(FastXAppApplicationModule).Assembly);
    }
}
