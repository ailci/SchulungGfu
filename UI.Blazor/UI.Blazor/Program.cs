using Application;
using Application.Contracts.Services;
using Logging;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence;
using UI.Blazor.Client.Pages;
using UI.Blazor.Components;
using UI.Blazor.Components.Account;
using UI.Blazor.Components.Pages;
using UI.Blazor.ComponentsLibrary;
using UI.Blazor.Configuration;
using UI.Blazor.Data;
using UI.Blazor.Middleware;
using UI.Blazor.Services;

var builder = WebApplication.CreateBuilder(args);

//Serilog
builder.AddLoggingConfig();

// Add services to the container.
builder.AddBlazorConfig()
    .AddAuthentificationConfig();

//QotdContext
builder.Services
    .AddPersistenceServices(builder.Configuration)
    .AddApplicationServices()
    .AddComponentLibrary();

//DI
//builder.Services.AddScoped<IQotdService, QotdService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IServiceManager, ServiceManager>();

var app = builder.Build();

// Configure the HTTP request pipeline. ########################################################################
//app.Use(async (context, next) =>
//{
//    var userAgent = context.Request.Headers["User-Agent"][0];
//    await context.Response.WriteAsync($"First middleware mit Agent {userAgent}\n");
//    await next();
//    await context.Response.WriteAsync("First Back middleware\n");
//});
//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync("Second middleware\n");
//    await next();
//    await context.Response.WriteAsync("Second Back middleware\n");
//});
//app.Run(async context =>
//{
//    await context.Response.WriteAsync("End middleware\n");
//});

//app.UseBrowserAllowed(Browser.Chrome, Browser.Firefox);

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseMigrationsEndPoint();

    //Db
    //await app.ApplyMigrationAsync();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(UI.Blazor.Client._Imports).Assembly);

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();
