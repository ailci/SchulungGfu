using Application.Contracts.Services;
using Application.ViewModels.Qotd;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace WebApi.Services;

public class QotdDbService(ILogger<QotdDbService> logger, 
    IDbContextFactory<QotdContext> contextFactory, 
    IMapper mapper) 
    : IQotdService
{
    public async Task<QuoteOfTheDayViewModel> GetQuoteOfTheDayAsync()
    {
        logger.LogInformation($"{nameof(GetQuoteOfTheDayAsync)} aufgerufen...");

        await using var context = await contextFactory.CreateDbContextAsync();

        var quotes = await context.Quotes.Include(c => c.Author).ToListAsync();
        var random = new Random();

        var randomQuote = quotes[random.Next(quotes.Count)];

        //Manuelles Mapping
        //return new QuoteOfTheDayViewModel
        //{
        //    Id = randomQuote.Id,
        //    QuoteText = randomQuote.QuoteText,
        //    AuthorBirthDate = randomQuote.Author?.BirthDate,
        //    AuthorName = randomQuote.Author?.Name ?? string.Empty,
        //    AuthorDescription = randomQuote.Author?.Description ?? string.Empty,
        //    AuthorPhoto = randomQuote.Author?.Photo,
        //    AuthorPhotoMimeType = randomQuote.Author?.PhotoMimeType
        //};

        //Automapper
        return mapper.Map<QuoteOfTheDayViewModel>(randomQuote);
    }
}