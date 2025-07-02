using Application.Contracts.Services;
using Application.Utilities;
using Application.ViewModels;
using Application.ViewModels.Author;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Hybrid;
using Persistence;

namespace UI.Blazor.Services;

public class AuthorService(ILogger<AuthorService> logger, IDbContextFactory<QotdContext> contextFactory, IMapper mapper) 
    : IAuthorService
{
    public async Task<IEnumerable<AuthorViewModel>> GetAuthorsAsync()
    {
        logger.LogInformation($"{nameof(GetAuthorsAsync)} aufgerufen...");

        await using var context = await contextFactory.CreateDbContextAsync();

        var authors = await context.Authors.AsNoTracking().ToListAsync();

        //var authorViewModels = authors.Select(author => new AuthorViewModel
        //{
        //    Name = author.Name,
        //    Description = author.Description
        //});


        //TDDO: Autoren holen und mappen
        return mapper.Map<IEnumerable<AuthorViewModel>>(authors);

    }
}