using Autentication.Contexts;
using Autentication.Models;
using Autentication.Services;
using Business.Managers;
using Business.Services;
using Data.Contexts;
using Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Quick and dirty auth
builder.Services.AddDbContext<AuthContext>(x =>
    x.UseSqlServer(builder.Configuration.GetConnectionString("AuthSqlConnection")));
builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AuthContext>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITokenManager, TokenManager>();

//Alpha database
builder.Services.AddDbContext<DataContext>(x =>
    x.UseSqlServer(builder.Configuration.GetConnectionString("AlphaSqlConnection")));
//Registering the repositories
builder.Services.AddScoped<MemberRepository>();
builder.Services.AddScoped<ClientRepository>();
builder.Services.AddScoped<StatusRepository>();
builder.Services.AddScoped<ProjectRepository>();
//Services
builder.Services.AddScoped<MemberService>();
builder.Services.AddScoped<ClientService>();
builder.Services.AddScoped<StatusService>();
builder.Services.AddScoped<ProjectService>();

builder.Services.AddCors(x =>
{
    x.AddPolicy("Strict", x =>
    {
        x.WithOrigins("http://localhost:5174")
        .WithMethods("GET", "POST", "PUT", "DELETE")
        .WithHeaders("Content-Type", "Autorization")
        .AllowCredentials();
    });

    x.AddPolicy("AllowAll", x =>
    {
        x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});
builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

app.MapOpenApi();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.UseCors("AllowAll");

app.Run();
