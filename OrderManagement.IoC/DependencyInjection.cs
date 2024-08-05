using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OrderManagement.Infrastructure.Context;
using OrderManagement.Domain.Core.Helpers;
using Microsoft.Extensions.Configuration;
using OrderManagement.Application.Interfaces;
using OrderManagement.Application.Services;
using OrderManagement.Domain.Interfaces;
using OrderManagement.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

namespace OrderManagement.IoC
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            StringHelpers.OrderManagementeCnn = configuration.GetConnectionString("OrderManagementeCnn")!;
            StringHelpers.TokenKey = configuration.GetSection("TokenKey").Value!;
            StringHelpers.MapsKey = configuration.GetSection("MapsKey").Value!;

            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(StringHelpers.OrderManagementeCnn));

            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IPedidoRepository, PedidoRepository>();

            services.AddTransient<IClienteService, ClienteService>();
            services.AddTransient<IPedidoService, PedidoService>();
            services.AddTransient<ITokenService, TokenService>();
        }

        public static void AddInfrastructureJwtSwagger(this IServiceCollection services)
        {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(StringHelpers.TokenKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Json Web Token (JWT), type Bearer before placing the token!"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {{
            new OpenApiSecurityScheme()
            {
                Reference = new OpenApiReference()
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
                Array.Empty<string>()
            }});
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "", Version = "v1" });
            });
        }
    }
}
