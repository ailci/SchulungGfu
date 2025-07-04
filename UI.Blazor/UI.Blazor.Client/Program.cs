using Application.Contracts.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Options;
using UI.Blazor.Client;
using UI.Blazor.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthenticationStateDeserialization();

//DI
builder.Services.AddScoped<IQotdService, QotdApiService>();
builder.Services.Configure<QotdAppSettings>(builder.Configuration.GetSection(nameof(QotdAppSettings)));

var qotdAppSettings = builder.Configuration.GetSection(nameof(QotdAppSettings)).Get<QotdAppSettings>();

//Named Client
//builder.Services.AddHttpClient("qotdapiservice", options =>
//{
//    options.BaseAddress = new Uri("https://localhost:7188");
//    options.DefaultRequestHeaders.Add("Accept","application/json");
//});

//Typed Client
builder.Services.AddHttpClient<IQotdService, QotdApiService>( (sp, options) =>
{
    //var apiConfiguration = sp.GetRequiredService<IOptions<QotdAppSettings>>();
    options.BaseAddress = new Uri(qotdAppSettings!.QotdServiceApiUri);
    options.DefaultRequestHeaders.Add("Accept","application/json");
});

await builder.Build().RunAsync();
