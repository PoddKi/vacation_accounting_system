using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using VacationAccountingSystem.Components;
using VacationAccountingSystem.Data;
using VacationAccountingSystem.Models;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Настройка подключения к БД
builder.Services.AddDbContext<VacationDbContext>(x =>
    {
        var connectionString = builder.Configuration.GetConnectionString("PostgreSqlConnection");
        x.UseSqlServer(connectionString);
    });

builder.Services.AddBlazorBootstrap();
builder.Services.AddMudServices();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
