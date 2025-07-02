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

    public async Task<bool> DeleteAuthorAsync(Guid authorId)
    {
        logger.LogInformation($"{nameof(DeleteAuthorAsync)} mit AuthorId: {authorId} aufgerufen...");

        await using var context = await contextFactory.CreateDbContextAsync();

        //var author = await context.Authors.Where(c => c.Id == authorId);
        //var author = await context.Authors.FirstOrDefaultAsync(c => c.Id == authorId);
        //var author = await context.Authors.SingleOrDefaultAsync(c => c.Id == authorId);

        var authorEntity = await context.Authors.FindAsync(authorId);

        if (authorEntity is null) return false;

        context.Authors.Remove(authorEntity);
        
        return await context.SaveChangesAsync() > 0;
    }
}