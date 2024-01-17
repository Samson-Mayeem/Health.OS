using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Health.OS.APi.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Health.OS.APi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
/*builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));
*/
// Configure the DbContext
builder.Services.AddDbContext<ApplicationDbContext>
                (options => options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version())));
builder
    .Services
    .AddIdentity<IdentityUser, IdentityRole>(options => options
        .SignIn
        .RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder
    .Services
    .AddAuthentication
    (
        options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults
                .AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults
                .AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults
                .AuthenticationScheme;
        })
    .AddJwtBearer
        (
            jwt =>
            {
                var _jwtConfig = builder.Configuration.GetSection("JwtConfig").Get<JwtConfig>();
                var jwtConfigSecret = _jwtConfig.Secret;
                Console.WriteLine($"JWT Secret Key: {jwtConfigSecret}");
                if (_jwtConfig != null)
                {
                    var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);
                     
                    jwt.SaveToken = true;

                    jwt
                        .TokenValidationParameters = new TokenValidationParameters()
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(key),
                            ValidateIssuer = false,
                            ValidateAudience = false,
                            RequireExpirationTime = false,
                            ValidateLifetime = false
                        };
                }
                else
                {
                    Console.WriteLine("JWT configuration (JwtConfig) is missing or invalid.");
                }
            }
        );

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
