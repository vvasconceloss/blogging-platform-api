using FluentValidation;
using bloggin_plataform_api.Data;
using Microsoft.EntityFrameworkCore;
using bloggin_plataform_api.Services;
using bloggin_plataform_api.DTOs.User;
using bloggin_plataform_api.Validators;
using bloggin_plataform_api.Interfaces;
using bloggin_plataform_api.Middlewares;
using bloggin_plataform_api.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BlogDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version())
    )
);

builder.Services.AddOpenApi();
builder.Services.AddControllers();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IValidator<UserDTO>, UserValidator>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();
app.Run();