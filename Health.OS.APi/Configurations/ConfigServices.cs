using Health.OS.APi._UnitOfWork;
using Health.OS.APi.Repositories.PatientRepo;
using Health.OS.APi.Security;
using HealthOS.Models.Extensions;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Health.OS.APi.Configurations
{
    public static class ConfigServices
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Configure AutoMapper
            services.AddAutoMapper(typeof(PatientProfile).Assembly);
            // Configure JWT Config
            //services.Configure<JwtConfig>(configuration.GetSection("JwtConfig"));

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie(options =>
            {
                options.LoginPath = "/healthos/api/v1/UserAuthentication/login";
            }); 
            /*services.AddScoped<AccessTokenResponse>();
            services.AddScoped<VodafoneTransactionService>();
            services.AddScoped<VodafoneStatusService>();*/
        }
    }
}
