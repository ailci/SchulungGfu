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
    public IEnumerable<AuthorViewModel>? AuthorsVm { get; set; }
    
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

        //TODO: Autor löschen
    }
}
