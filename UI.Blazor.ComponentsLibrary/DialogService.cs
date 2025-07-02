using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace UI.Blazor.ComponentsLibrary;

public class DialogService
{
    private readonly Lazy<Task<IJSObjectReference>> _moduleTask;

    public DialogService(IJSRuntime jsRuntime)
    {
        _moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
            "import", "./_content/UI.Blazor.ComponentsLibrary/dialog.js").AsTask());
    }

    public async Task<bool> ConfirmAsync(string message)
    {
        var module = await _moduleTask.Value;
        return await module.InvokeAsync<bool>("myConfirm", message);
    }
}