/*
 *  Description: JWT 認證相關的擴展方法
 *               服務端必須要有 JwtSettings 的設定
 *       Author: Kevin
 *  Create Date: 2024.12.06
 */
using JwtAuth.Common.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace JwtAuth.Common.Extensions {
    /// <summary>
    /// JWT 認證相關的擴展方法
    /// </summary>
    public static class JwtAuthExtensions {
        /// <summary>
        /// 單一 JWT 認証設置
        /// </summary>
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration) {
            var jwtSettings = configuration.GetSection("JwtSettings").Get<JwtSettings>();  // 取得 JWT 設定(Service.A 或 Service.B 的 appsettings.json 中的 JwtSettings)
            if (jwtSettings == null) {
                throw new InvalidOperationException("JwtSettings 未設定");
            }

            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options => {
                options.TokenValidationParameters = new TokenValidationParameters {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.ValidIssuer,
                    ValidAudience = jwtSettings.ValidAudience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtSettings.SecurityKey)
                    )
                };
            });

            return services;
        }

        /// <summary>
        /// JWT 相關服務, 生命週期控制由 Service A 和 B 控制, 預設為 Scoped
        /// </summary>
        public static IServiceCollection AddJwtServices(this IServiceCollection services, IConfiguration configuration, ServiceLifetime lifetime = ServiceLifetime.Scoped) {
            // 註冊 JwtSettings
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

            // 依指定的生命周期註冊 JwtAuthService
            switch (lifetime) {
                case ServiceLifetime.Singleton:
                    services.AddSingleton<IJwtAuthService, JwtAuthService>();
                    break;
                case ServiceLifetime.Scoped:
                    services.AddScoped<IJwtAuthService, JwtAuthService>();
                    break;
                case ServiceLifetime.Transient:
                    services.AddTransient<IJwtAuthService, JwtAuthService>();
                    break;
                default:
                    throw new ArgumentException($"Unsupported lifetime: {lifetime}");
            }

            return services;
        }

        /// <summary>
        /// 多重JWT認證服務設置
        /// </summary>
        /// <param name="services">服務集合</param>
        /// <param name="serviceASettings">Service A 的JWT設定</param>
        /// <param name="serviceBSettings">Service B 的JWT設定</param>
        public static void AddMultipleJwtAuthentication(this IServiceCollection services, JwtSettings serviceASettings, JwtSettings serviceBSettings) {
            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer("ServiceAScheme", options => {
                options.TokenValidationParameters = new TokenValidationParameters {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = serviceASettings.ValidIssuer,
                    ValidAudience = serviceASettings.ValidAudience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(serviceASettings.SecurityKey)
                    )
                };
            })
            .AddJwtBearer("ServiceBScheme", options => {
                options.TokenValidationParameters = new TokenValidationParameters {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = serviceBSettings.ValidIssuer,
                    ValidAudience = serviceBSettings.ValidAudience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(serviceBSettings.SecurityKey)
                    )
                };
            });
        }
    }
}