using Application.Contracts.Services;
using Application.ViewModels.Author;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace UI.Blazor.Components.Pages.Author;
public partial class AuthorNew
{
    [Inject] public ILogger<Overview> Logger { get; set; } = null!;
    [Inject] public IServiceManager ServiceManager { get; set; } = null!;
    [Inject] public NavigationManager NavManager { get; set; } = null!;
    public AuthorForCreateViewModel? AuthorForCreateVm { get; set; }

    protected override void OnInitialized() => AuthorForCreateVm ??= new() { Name = "", Description = "" };

    private async Task HandleValidSubmit(EditContext args)
    {
        var newAuthorVm = await ServiceManager.AuthorService.AddAuthorAsync(AuthorForCreateVm);

        if (newAuthorVm is not null)
        {
            NavManager.NavigateTo("/authors/overview");
        }
    }

    private void OnInputFileChange(InputFileChangeEventArgs args)
    {
        AuthorForCreateVm!.Photo = args.File;
    }
}
