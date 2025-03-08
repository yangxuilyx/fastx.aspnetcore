using System.Text;
using FastX.CodeGenerate;
using FastX.Identity;
using FastX.Modularity;
using FastXTpl.WebTemplate.Application;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace FastXTpl.WebTemplate.Host;

/// <summary>
/// 
/// </summary>
[DependsOn(typeof(WebTemplateApplicationModule), typeof(XCodeGenerateModule),typeof(XIdentityModule))]
public class WebTemplateHostModule : XModule
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    public override void ConfigurationService(IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    ;
            });
        });

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1",new OpenApiInfo(){Title = "FastXTpl",Version = "v1"});

            //Bearer 的scheme定义
            var securityScheme = new OpenApiSecurityScheme()
            {
                Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                Name = "Authorization",
                //参数添加在头部
                In = ParameterLocation.Header,
                //使用Authorize头部
                Type = SecuritySchemeType.Http,
                //内容为以 bearer开头
                Scheme = "bearer",
                BearerFormat = "JWT"
            };

            //把所有方法配置为增加bearer头部信息
            var securityRequirement = new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "bearerAuth"
                        }
                    },
                    new string[] {}
                }
            };

            //注册到swagger中
            c.AddSecurityDefinition("bearerAuth", securityScheme);
            c.AddSecurityRequirement(securityRequirement);

            var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);//获取应用程序所在目录（绝对，不受工作目录影响，建议采用此方法获取路径）
            c.IncludeXmlComments(Path.Combine(basePath, "FastXTpl.WebTemplate.Application.xml"),true);
            c.IncludeXmlComments(Path.Combine(basePath, "FastXTpl.WebTemplate.Host.xml"),true);
            c.IncludeXmlComments(Path.Combine(basePath, "FastX.Identity.xml"), true);
            c.IncludeXmlComments(Path.Combine(basePath, "FastX.AspNetCore.xml"));
        });

        services.AddEndpointsApiExplorer();

        var configuration = services.GetConfiguration();

        services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true, //是否验证Issuer
                    ValidIssuer = configuration["Jwt:Issuer"], //发行人Issuer
                    ValidateAudience = true, //是否验证Audience
                    ValidAudience = configuration["Jwt:Audience"], //订阅人Audience
                    ValidateIssuerSigningKey = true, //是否验证SecurityKey
                    IssuerSigningKey =
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"])), //SecurityKey
                    ValidateLifetime = true, //是否验证失效时间
                    ClockSkew = TimeSpan.FromSeconds(30), //过期时间容错值，解决服务器端时间不同步问题（秒）
                    RequireExpirationTime = true,
                };
            });

        services.AddSpaStaticFiles(options =>
        {
            options.RootPath = "browser";
        });
    }
}