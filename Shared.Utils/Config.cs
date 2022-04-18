using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Shared.Utils.Commands;
using Shared.Utils.Commands.Abstract;
using Shared.Utils.Queries;
using Shared.Utils.Queries.Abstract;
using Shared.Utils.WebAPI.Security;
using System.Collections.Generic;
using System.Text;

namespace Shared.Utils
{
    public static class Config
    {
        public static IServiceCollection AddMessageBusses(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                 .AddSingleton<IQueryBus, QueryBus>()
                 .AddSingleton<ICommandBus, CommandBus>();
        }

        public static IServiceCollection AddJwt<TStartup>(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JWTSettings>(configuration.GetSection("jwt"))
                   .AddSingleton<IJWTHandler, JWTHandler>()
                   .AddAuthentication(ConfigureAuthentication)
                   .AddJwtBearer(options => ConfigureJwt(options, configuration));

            return services;
        }

        public static IServiceCollection AddSwaggerAuthorize(this IServiceCollection services)
        {
            return services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                   {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,

                        },
                        new List<string>()
                      }
                     });
            });
        }

        private static void ConfigureAuthentication(AuthenticationOptions options)
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }

        private static void ConfigureJwt(JwtBearerOptions options, IConfiguration configuration)
        {
            var hmacSecretKey = configuration["Jwt:HmacSecretKey"];
            var secretBytes = Encoding.ASCII.GetBytes(hmacSecretKey);

            options.RequireHttpsMetadata = false;
            options.SaveToken = true;

            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(secretBytes),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = false
            };
        }
    }
}