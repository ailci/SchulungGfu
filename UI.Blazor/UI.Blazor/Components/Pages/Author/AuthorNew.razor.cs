using Application.ViewModels.Author;
using Microsoft.AspNetCore.Components.Forms;

namespace UI.Blazor.Components.Pages.Author;
public partial class AuthorNew
{
    public AuthorForCreateViewModel? AuthorForCreateVm { get; set; }

    protected override void OnInitialized() => AuthorForCreateVm ??= new() { Name = "", Description = "" };

    private Task HandleValidSubmit(EditContext args)
    {
        //TODO: Speichern => IAuthorService erweitern, Validierung, 


        throw new NotImplementedException();
    }
}
