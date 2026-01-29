using Mehr.SharedKernel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json;

namespace Mehr.Infarstructure.Identity;

public static class JwtConfiguration
{
    public static AuthenticationBuilder AddJwtAuthentication(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        return services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = JwtTokenValidation(configuration);
                options.Events = JwtEvents();
            });
    }

    private static TokenValidationParameters JwtTokenValidation(
        IConfiguration configuration)
    {
        return new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = "Jwt:Issuer",
            ValidAudience = "Jwt:Audience",
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("c0d0cd85-f64e-4fcd-8625-c8c37c5bdd85")
            )
        };
    }

    private static JwtBearerEvents JwtEvents()
    {
        return new JwtBearerEvents
        {
            OnChallenge = context =>
            {
                context.HandleResponse();

                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                context.Response.ContentType = "application/json";

                var result = Result.Failure(Error.Problem("401", "Unauthorized"));

                var json = JsonSerializer.Serialize(result);
                return context.Response.WriteAsync(json);
            },

            OnForbidden = context =>
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                context.Response.ContentType = "application/json";

                var result = Result.Failure(
                    Error.Problem("403", "Access denied"));

                var json = JsonSerializer.Serialize(result);
                return context.Response.WriteAsync(json);
            }
        };
    }
}
