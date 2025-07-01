﻿using Application.Contracts.Services;
using Application.ViewModels.Qotd;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace UI.Blazor.Services;

public class QotdService(ILogger<QotdService> logger, IDbContextFactory<QotdContext> contextFactory) : IQotdService
{
    public async Task<QuoteOfTheDayViewModel> GetQuoteOfTheDayAsync()
    {
        logger.LogInformation($"{nameof(GetQuoteOfTheDayAsync)} wurde aufgerufen...");

        await using var context = await contextFactory.CreateDbContextAsync();

        var quotes = await context.Quotes.Include(c => c.Author).ToListAsync();
        var random = new Random();

        var randomQuote = quotes[random.Next(quotes.Count)];

        return new QuoteOfTheDayViewModel
        {
            Id = randomQuote.Id,
            QuoteText = randomQuote.QuoteText,
            AuthorBirthDate = randomQuote.Author?.BirthDate,
            AuthorName = randomQuote.Author?.Name ?? string.Empty,
            AuthorDescription = randomQuote.Author?.Description ?? string.Empty,
            AuthorPhoto = randomQuote.Author?.Photo,
            AuthorPhotoMimeType = randomQuote.Author?.PhotoMimeType
        };

    }
}