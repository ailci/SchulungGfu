using Application.ViewModels.Author;
using Microsoft.AspNetCore.Components;

namespace UI.Blazor.Components;
public partial class AuthorTable
{
    [Parameter, EditorRequired] 
    public IEnumerable<AuthorViewModel>? AuthorViewModels { get; set; }

    private Task ShowConfirmationDialog(AuthorViewModel authorVm)
    {
        
    }
}
