using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace bake.models.identiti;

public static class ValidParametrs
{
    public static IServiceCollection aut(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        var aut = configuration.GetSection(nameof(JWTModel))
            .Get<JWTModel>();
        serviceCollection.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(op =>
            {
                op.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = Opshen.Iuser,
                    ValidateAudience = true,
                    ValidAudience = Opshen.Audins,
                    ValidateLifetime = true,
                    IssuerSigningKey = Opshen.GetSymmetricSecurityKey(),
                    ValidateIssuerSigningKey = true,
                };
                op.Events = new JwtBearerEvents()
                {
                    OnMessageReceived = context =>
                    {
                        context.Token = context.Request.Cookies["berr"];
                        return Task.CompletedTask;
                    }
                };
            });
        return serviceCollection;
    }
    
}