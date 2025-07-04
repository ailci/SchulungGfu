using System.Net.Http.Json;
using Application.Contracts.Services;
using Application.ViewModels.Qotd;

namespace UI.Blazor.Client.Services;

public class QotdApiService(ILogger<QotdApiService> logger, IHttpClientFactory httpClientFactory) : IQotdService
{
    private const string QotdUri = "api/qotd";

    public async Task<QuoteOfTheDayViewModel> GetQuoteOfTheDayAsync()
    {
        logger.LogInformation($"{nameof(GetQuoteOfTheDayAsync)} aufgerufen...");

        var client = httpClientFactory.CreateClient("qotdapiservice");
        return await client.GetFromJsonAsync<QuoteOfTheDayViewModel>(QotdUri);
    }
}