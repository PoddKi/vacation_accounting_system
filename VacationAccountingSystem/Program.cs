using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using VacationAccountingSystem.Components;
using VacationAccountingSystem.Data;
using VacationAccountingSystem.Models;
using MudBlazor.Services;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddBlazorBootstrap();
builder.Services.AddMudServices();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "auth_token";
        options.LoginPath = "/login";
        options.Cookie.MaxAge = TimeSpan.FromHours(10);
        options.AccessDeniedPath = "/access-denied";
    });
builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();

builder.Services.AddDbContext<VacationDbContext>(x =>
    {
        var connectionString = builder.Configuration.GetConnectionString("PostgreSqlConnection"); 
        x.UseNpgsql(connectionString);
    });

builder.Services.AddHttpClient();

var app = builder.Build();

//app.MapGet("/time", () => DateTime.Now.ToShortTimeString());

//app.MapControllerRoute("default", "{controller=Department}/{action=Index}/{id?}");

//app.MapPost("/api/department", () =>
//{
//    return await _vacationDbContext.Departments.ToListAsync();
//    return Results.Json(user);
//});

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
