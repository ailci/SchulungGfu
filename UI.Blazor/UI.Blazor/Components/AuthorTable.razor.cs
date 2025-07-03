using Application.ViewModels.Author;
using Domain.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.Build.Framework;
using Microsoft.JSInterop;
using UI.Blazor.ComponentsLibrary;
using UI.Blazor.ComponentsLibrary.Components;

namespace UI.Blazor.Components;
public partial class AuthorTable
{
    [Parameter, EditorRequired] public IEnumerable<AuthorViewModel>? AuthorViewModels { get; set; }
    [Parameter] public EventCallback<Guid> OnAuthorDelete { get; set; }
    [Inject] public IJSRuntime JsRuntime { get; set; } = null!;
    [Inject] public DialogService DialogService { get; set; } = null!;
    private ConfirmDialog? _confirmDialogComponent; //Referenz zur Componente
    private Guid _authorIdToDelete;

    private async Task ShowConfirmationDialog(AuthorViewModel authorVm)
    {
        _authorIdToDelete = authorVm.Id;

        //1. Version
        //if (await JsRuntime.InvokeAsync<bool>("myConfirm", $"Wolle Sie wirklich den Autor '{authorVm.Name}' löschen?"))
        //{
        //    await OnAuthorDelete.InvokeAsync(authorVm.Id); //auslösen des Events
        //}

        //2.Version
        //if (await DialogService.ConfirmAsync($"Wollen Sie wirklich den Autor '{authorVm.Name}' löschen?"))
        //{
        //    await OnAuthorDelete.InvokeAsync(authorVm.Id); //auslösen des Events
        //}

        //3.Version
        _confirmDialogComponent?.Show($"Wollen Sie wirklich den Autor <strong>'{authorVm.Name}'</strong> löschen (Component) <script>alert('Evil')</script> ?");
    }
    private async Task ConfirmDialogClicked(bool isConfirmed)
    {
        if (isConfirmed)
        {
            await OnAuthorDelete.InvokeAsync(_authorIdToDelete);
        }
    }
}
