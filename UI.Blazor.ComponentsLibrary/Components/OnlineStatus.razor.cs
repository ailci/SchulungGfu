using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace UI.Blazor.ComponentsLibrary.Components;
public partial class OnlineStatus
{
    [Inject] public IJSRuntime JsRuntime { get; set; } = null!;
    private IJSObjectReference _jsModule = null!;
    private bool _isOnline;
    private string _bgColor = string.Empty;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            var dotNetObjRef = DotNetObjectReference.Create(this); //Referenz zur Componente
            _jsModule = await JsRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/UI.Blazor.ComponentsLibrary/Components/OnlineStatus.razor.js");
            await _jsModule.InvokeVoidAsync("registerOnlineStatusHandler", dotNetObjRef);
        }
    }

    [JSInvokable]
    public void SetOnlineStatusColor(bool isOnline)
    {
        _isOnline = isOnline;
        _bgColor = _isOnline ? "bg-success" : "bg-danger";
        StateHasChanged();
    }
}
