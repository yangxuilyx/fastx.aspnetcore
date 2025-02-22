using FastX.AspNetCore;
using FastX.Modularity;
using FastXTpl.WebTemplate.Core;
using Microsoft.Extensions.DependencyInjection;

namespace FastXTpl.WebTemplate.Application;

[DependsOn(
    typeof(XAspNetCoreModule),
    typeof(WebTemplateCoreModule))]
public class WebTemplateApplicationModule : XModule
{
    /// <summary>
    /// ConfigurationService
    /// </summary>
    /// <param name="services"></param>
    public override void ConfigurationService(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(WebTemplateApplicationModule).Assembly);
    }
}
