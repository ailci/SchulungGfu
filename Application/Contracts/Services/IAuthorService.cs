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
}