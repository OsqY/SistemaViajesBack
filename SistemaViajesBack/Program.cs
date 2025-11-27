using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Services;
using Domain.Entities;
using Infrastructure.Database;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(
    opts =>
    {
        opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
            x => x.MigrationsAssembly("Infrastructure"));
    }
);

builder.Services.AddAuthorization();

builder.Services.AddIdentityApiEndpoints<Usuario>(
    options =>
    {
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = true;
        options.Password.RequiredLength = 12;
    }
).AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddScoped<IUsuarioViajeRepository, UsuarioViajeRepository>();
builder.Services.AddScoped<IUsuarioViajeService, UsuarioViajeService>();
builder.Services.AddScoped<IViajeRepository, ViajeRepository>();
builder.Services.AddScoped<IViajeService, ViajeService>();
//builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
//builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<ITransportistaRepository, TransportistaRepository>();
builder.Services.AddScoped<ITransportistaService, TransportistaService>();
builder.Services.AddScoped<ISucursalUsuarioRepository, SucursalUsuarioRepository>();
builder.Services.AddScoped<ISucursalUsuarioService, SucursalUsuarioService>();
builder.Services.AddScoped<ISucursalRepository, SucursalRepository>();
builder.Services.AddScoped<ISucursalService, SucursalService>();

var DefaultCors = "_defaultCors";

builder.Services.AddCors(
    opts =>
    {
        opts.AddPolicy(name: DefaultCors,
            policy =>
            {
                policy.WithOrigins("http://localhost:4200")
                      .AllowAnyHeader()
                      .AllowAnyMethod()
                      .AllowCredentials();
            }
        );
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(DefaultCors);

app.MapIdentityApi<Usuario>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
