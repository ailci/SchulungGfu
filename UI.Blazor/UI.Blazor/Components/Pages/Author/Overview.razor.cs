using Application.Contracts.Services;
using Application.Utilities;
using Application.ViewModels.Author;
using Microsoft.AspNetCore.Components;

namespace UI.Blazor.Components.Pages.Author;
public partial class Overview
{
    #region Members/Constructors
    
    [Inject] public ILogger<Overview> Logger { get; set; } = null!;
    [Inject] public IServiceManager ServiceManager { get; set; } = null!;
    [Inject] public NavigationManager NavManager { get; set; } = null!;
    public IEnumerable<AuthorViewModel>? AuthorsVm { get; set; }
    private string? _errorMessage;
    
    #endregion

    protected override async Task OnInitializedAsync()
    {
        await GetAuthors();
    }

    private async Task GetAuthors()
    {
        AuthorsVm = (await ServiceManager.AuthorService.GetAuthorsAsync()).OrderBy(c => c.Name);
        //Logger.LogInformation(AuthorsVm?.LogAsJson());
    }

    private async Task DeleteAuthor(Guid authorId)
    {
        Logger.LogInformation($"Author mit Id: {authorId} zum Löschen ausgewählt...");
        _errorMessage = string.Empty;

        var isDeleted = await ServiceManager.AuthorService.DeleteAuthorAsync(authorId);

        if (isDeleted)
        {
            await GetAuthors();
        }
        else
        {
            _errorMessage = "Autor konnte nicht gelöscht werden";
        }
    }
    private void NavigateToAuthorNew()
    {
        NavManager.NavigateTo("/authors/new");
    }
}
