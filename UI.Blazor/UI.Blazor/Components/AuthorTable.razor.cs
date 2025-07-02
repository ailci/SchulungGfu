using Application.ViewModels.Author;
using Microsoft.AspNetCore.Components;
using Microsoft.Build.Framework;
using Microsoft.JSInterop;
using UI.Blazor.ComponentsLibrary;

namespace UI.Blazor.Components;
public partial class AuthorTable
{
    [Parameter, EditorRequired] public IEnumerable<AuthorViewModel>? AuthorViewModels { get; set; }
    [Parameter] public EventCallback<Guid> OnAuthorDelete { get; set; }
    [Inject] public IJSRuntime JsRuntime { get; set; } = null!;
    [Inject] public DialogService DialogService { get; set; } = null!;

    private async Task ShowConfirmationDialog(AuthorViewModel authorVm)
    {
        //1. Version
        //if (await JsRuntime.InvokeAsync<bool>("myConfirm", $"Wolle Sie wirklich den Autor '{authorVm.Name}' l�schen?"))
        //{
        //    await OnAuthorDelete.InvokeAsync(authorVm.Id); //ausl�sen des Events
        //}

        //2.Version
        if (await DialogService.ConfirmAsync($"Wollen Sie wirklich den Autor '{authorVm.Name}' l�schen?"))
        {
            await OnAuthorDelete.InvokeAsync(authorVm.Id); //ausl�sen des Events
        }
    }
}
