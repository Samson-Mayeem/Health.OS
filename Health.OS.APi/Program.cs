using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Pomelo.EntityFrameworkCore.MySql;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Health.OS.APi.Data;

using Health.OS.APi._UnitOfWork;
using Health.OS.APi.Repositories.PatientRepo;
using HealthOS.Models.Extensions;
using Health.OS.APi.Configurations;
using HealthOS.Models.Users;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
/*builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));*/

// Configure the DbContext
builder.Services.AddDbContext<ApplicationDbContext>
                (options => options.UseMySql(builder.Configuration.GetConnectionString("conc"), new MySqlServerVersion(new Version())));
/*builder
    .Services
    .AddIdentity<IdentityUser, IdentityRole>(options => options
        .SignIn
        .RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>(); */

/*builder
    .Services
    .AddIdentity<User, Role>(options => options
        .SignIn
        .RequireConfirmedAccount = false)
    .AddUserStore<ApplicationDbContext>();*/

// Add services to the container.
/*builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(jwt =>
{
    var jwtConfig = builder.Configuration.GetSection("JwtConfig").Get<>();
    if (jwtConfig == null || string.IsNullOrEmpty(jwtConfig.Secret))
    {
        Console.WriteLine("JWT configuration (JwtConfig) is missing or invalid.");
    }
    else
    {
        var key = Encoding.ASCII.GetBytes(jwtConfig.Secret);

        jwt.SaveToken = true;

        jwt.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
            RequireExpirationTime = false,
            ValidateLifetime = false
        };
    }
});*/

// Configure services using the extension method
builder.Services.ConfigureServices(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.Use(async (context, next) =>
{
    // Check if the request is for localhost
    if (context.Request.Host.Host.Equals("localhost", StringComparison.OrdinalIgnoreCase))
    {
        // Redirect to aoholdings.net
        context.Response.Redirect("https://aoholding.net" + context.Request.Path);
        return;
    }

    await next();
});
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
