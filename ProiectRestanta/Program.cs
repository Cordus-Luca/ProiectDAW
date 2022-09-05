using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProiectRestanta.Helpers;
using ProiectRestanta.Data;
using ProiectRestanta.Entities;
using ProiectRestanta.Models.Constants;
using ProiectRestanta.Repositories;
using ProiectRestanta.Repositories.ShopRepository;
using ProiectRestanta.Services.UserServices;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProiectContext>(options => options.UseSqlServer("Data Source=(localdb)\\ProjectModels;Initial Catalog=ProiectDAW;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(UserRoleType.Admin, policy => policy.RequireRole(UserRoleType.Admin));
    options.AddPolicy(UserRoleType.User, policy => policy.RequireRole(UserRoleType.User));
});

builder.Services.AddAuthentication(auth =>
{
    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Custom Key For Auth")),
        ValidateIssuerSigningKey = true
    };
    options.Events = new JwtBearerEvents()
    {
        OnTokenValidated = SessionTokenValidator.ValidateSessionToken
    };
});

builder.Services.AddTransient<IShopRepository, ShopRepository>();

builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<ProiectContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

// TESTING