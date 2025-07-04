using System.Text.Json;
using Application.ViewModels.Qotd;
using Microsoft.AspNetCore.Components;

namespace UI.Blazor.Client.Pages;
public partial class HomeWasm
{
    [Inject] public ILogger<HomeWasm> Logger { get; set; } = null!;
    [Inject] public IHttpClientFactory HttpClientFactory { get; set; } = null!;
    public QuoteOfTheDayViewModel? QotdViewModel { get; set; }

    protected override async Task OnInitializedAsync()
    {
        //1. Version
        var client = HttpClientFactory.CreateClient("qotdapiservice");
        var response = await client.GetAsync("api/qotd");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        QotdViewModel = JsonSerializer.Deserialize<QuoteOfTheDayViewModel>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true});
    }
}
