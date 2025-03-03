using FastX;
using FastX.Modularity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SqlSugar;

namespace FastXTpl.WebTemplate.Core
{
    /// <summary>
    /// FastXAppCoreModule
    /// </summary>
    [DependsOn(typeof(XCoreModule))]
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
        }

        /// <summary>
        /// PostConfigureServices
        /// </summary>
        /// <param name="services"></param>
        public override void PostConfigureServices(IServiceCollection services)
        {
            services.GetSingletonInstance<XSugarBuilder>().InitTables(typeof(WebTemplateCoreModule).Assembly);
        }
    }
}
