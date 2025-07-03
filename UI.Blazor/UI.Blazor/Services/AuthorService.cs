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

    public async Task<AuthorViewModel> GetAuthorAsync(Guid authorId, bool includeQuotes = false)
    {
        logger.LogInformation($"{nameof(GetAuthorAsync)} mit AuthorId: {authorId} aufgerufen...");

        await using var context = await contextFactory.CreateDbContextAsync();

        var author = !includeQuotes
            ? await context.Authors.FindAsync(authorId)
            : await context.Authors.Include(c => c.Quotes).SingleOrDefaultAsync(c => c.Id.Equals(authorId));

        return mapper.Map<AuthorViewModel>(author);
    }

    public async Task<AuthorViewModel> AddAuthorAsync(AuthorForCreateViewModel authorForCreateViewModel)
    {
        logger.LogInformation($"{nameof(AddAuthorAsync)} mit AuthorForCreateVm: {authorForCreateViewModel.LogAsJson()} aufgerufen...");

        await using var context = await contextFactory.CreateDbContextAsync();

        var authorEntity = mapper.Map<Author>(authorForCreateViewModel);

        //Falls Bild ausgewählt
        if (authorForCreateViewModel.Photo is not null)
        {
            (authorEntity.Photo, authorEntity.PhotoMimeType) = await authorForCreateViewModel.Photo.GetFile();
        }

        logger.LogInformation($"AuthorEntity: {authorEntity.LogAsJson()} umgewandelt...");

        await context.Authors.AddAsync(authorEntity);
        await context.SaveChangesAsync();

        return mapper.Map<AuthorViewModel>(authorEntity);
    }
}