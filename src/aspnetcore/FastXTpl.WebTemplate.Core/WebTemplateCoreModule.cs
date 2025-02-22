using FastX.Data;
using FastX.Modularity;
using FastXTpl.WebTemplate.Core.Identity.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SqlSugar;

namespace FastXTpl.WebTemplate.Core
{
    /// <summary>
    /// FastXAppCoreModule
    /// </summary>
    [DependsOn(typeof(FastXDataModule))]
    public class WebTemplateCoreModule : XModule
    {
        /// <summary>
        /// ConfigurationService
        /// </summary>
        /// <param name="services"></param>
        public override void ConfigurationService(IServiceCollection services)
        {
            var configuration = services.GetConfiguration();

            var sugarBuilder = services.AddXSqlSugar(options =>
                {
                    options.ConnectionString = configuration.GetConnectionString("Default");
                    options.DbType = DbType.PostgreSQL;
                });

            var redisConnectionString = configuration.GetConnectionString("Redis");
            if (!redisConnectionString.IsNullOrEmpty())
            {
                services.AddFastXStackExchangeRedisCache(redisConnectionString);
                sugarBuilder.UseDataCache();
            }

            services.TryAddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

        }

        /// <summary>
        /// PostConfigureServices
        /// </summary>
        /// <param name="services"></param>
        public override void PostConfigureServices(IServiceCollection services)
        {
            services.GetSingletonInstance<XSugarBuilder>().CodeFirstInitTables(typeof(WebTemplateCoreModule).Assembly);
        }
    }
}
