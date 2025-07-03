using Microsoft.AspNetCore.Components;

namespace UI.Blazor.ComponentsLibrary.Components;
public partial class ConfirmDialog
{
    private bool _showConfirm;
    private MarkupString _convertedConfirmMessage;

    [Parameter, EditorRequired] 
    public string ConfirmTitle { get; set; } = string.Empty;

    [Parameter] 
    public string ConfirmMessage { get; set; } = "Sind Sie sicher?";

    [Parameter] public EventCallback<bool> OnConfirmDialogClicked { get; set; }

    public void Show()
    {
        _showConfirm = true;
    }

    public void Show(string message)
    {
        _showConfirm = true;
        ConfirmMessage = message;
        //_convertedConfirmMessage = new MarkupString(message);
        //_convertedConfirmMessage = new MarkupString(Markdig.Markdown.ToHtml(ConfirmMessage));
        StateHasChanged();
    }

    private async Task OnConfirmChange(bool deleteConfirmed)
    {
        _showConfirm = false;

        await OnConfirmDialogClicked.InvokeAsync(deleteConfirmed);
    }
}
