using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Aplicacao.Application.AutoMapperConfigs;
using Aplicacao.Application.Interfaces;
using Aplicacao.Application.Interfaces.Access;
using Aplicacao.Application.Security;
using Aplicacao.Application.Services;
using Aplicacao.Application.Services.Access;
using Aplicacao.Domain.Interfaces.Repositories;
using Aplicacao.Domain.Interfaces.Services;
using Aplicacao.Domain.Services;
using Aplicacao.Infra.DataAccess.Repositories.Redis;
using Aplicacao.Infra.DataAccess.Repositories.SQL;

namespace Aplicacao.Infra.CrossCutting
{
    public static class Injections
    {
        public static void AddRegisterServicesMITArq(this IServiceCollection services)
        {
            //AutoMapper
            services.AddSingleton<IConfigurationProvider>(AutoMapperConfig.RegisterMappings());

            //Applications
            services.AddScoped<IClienteApplication, ClienteApplication>();
            services.AddScoped<ILoginApplication, LoginApplication>();

            //Services
            services.AddScoped<IClienteService, ClienteService>();

            //Repositories
            services.AddScoped<IClienteSqlServerRepository, ClienteSQLRepository>();
            services.AddScoped<IClienteRedisRepository, ClienteRedisRepository>();
        }

        public static void SetSecurity(this IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            var tokenConfigurations = new TokenConfiguration();
            var signingConfigurations = new SigningConfigurations();

            new ConfigureFromConfigurationOptions<TokenConfiguration>(
                configuration.GetSection("TokenConfigurations")
            )
            .Configure(tokenConfigurations);

            services.AddSingleton(tokenConfigurations);

            services.AddSingleton(signingConfigurations);

            ///TODO Core
            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = signingConfigurations.SecurityKey;
                paramsValidation.ValidAudience = tokenConfigurations.Audience;
                paramsValidation.ValidIssuer = tokenConfigurations.Issuer;
                paramsValidation.ValidateIssuerSigningKey = true;
                paramsValidation.ValidateLifetime = true;
                paramsValidation.ClockSkew = System.TimeSpan.Zero;
            });

            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme‌​)
                    .RequireAuthenticatedUser()
                    .Build());
            });
        }
    }
}
