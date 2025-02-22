using FastX.App.Core;
using FastX.AspNetCore;
using FastX.Modularity;
using FastXTpl.Template.Core;
using Microsoft.Extensions.DependencyInjection;

namespace FastXTpl.Template.Application;

[DependsOn(
    typeof(XAspNetCoreModule),
    typeof(TemplateCoreModule))]
public class TemplateApplicationModule : XModule
{
    /// <summary>
    /// ConfigurationService
    /// </summary>
    /// <param name="services"></param>
    public override void ConfigurationService(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(TemplateApplicationModule).Assembly);
    }
}
