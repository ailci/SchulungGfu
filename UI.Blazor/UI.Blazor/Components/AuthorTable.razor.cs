using Application.ViewModels.Author;
using Microsoft.AspNetCore.Components;
using Microsoft.Build.Framework;

namespace UI.Blazor.Components;
public partial class AuthorTable
{
    [Parameter, EditorRequired] 
    public IEnumerable<AuthorViewModel>? AuthorViewModels { get; set; }

    [Parameter] public EventCallback<Guid> OnAuthorDelete { get; set; }

    private async Task ShowConfirmationDialog(AuthorViewModel authorVm)
    {
        await OnAuthorDelete.InvokeAsync(authorVm.Id); //auslösen des Events
    }
}
