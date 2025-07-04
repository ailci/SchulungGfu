using System.Net.Http.Json;
using Application.Contracts.Services;
using Application.ViewModels.Qotd;
using Microsoft.Extensions.Options;

namespace UI.Blazor.Client.Services;

public class QotdApiService(ILogger<QotdApiService> logger, HttpClient client, IOptions<QotdAppSettings> appSettings) : IQotdService
{
    private readonly QotdAppSettings _appSettings = appSettings.Value;
    private const string QotdUri = "api/qotd";

    public async Task<QuoteOfTheDayViewModel> GetQuoteOfTheDayAsync()
    {
        logger.LogInformation($"{nameof(GetQuoteOfTheDayAsync)} aufgerufen...");
        
        //var client = httpClientFactory.CreateClient("qotdapiservice");
        return await client.GetFromJsonAsync<QuoteOfTheDayViewModel>(QotdUri);
    }
}