using Microsoft.AspNetCore.Components;

namespace UI.Blazor.ComponentsLibrary.Components;
public partial class ConfirmDialog
{
    private bool _showConfirm;

    [Parameter, EditorRequired] 
    public string ConfirmTitle { get; set; } = string.Empty;

    [Parameter] 
    public string ConfirmMessage { get; set; } = "Sind Sie sicher?";

    private Task OnConfirmChange(bool deleteConfirmed)
    {
        throw new NotImplementedException();
    }
}
