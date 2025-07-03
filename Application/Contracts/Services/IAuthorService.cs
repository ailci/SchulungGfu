using Application.ViewModels.Author;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Services;

public interface IAuthorService
{
    Task<IEnumerable<AuthorViewModel>> GetAuthorsAsync();
    Task<bool> DeleteAuthorAsync(Guid authorId);
    Task<AuthorViewModel> GetAuthorAsync(Guid authorId, bool includeQuotes = false);
    Task<AuthorViewModel> AddAuthorAsync(AuthorForCreateViewModel authorForCreateViewModel);
}