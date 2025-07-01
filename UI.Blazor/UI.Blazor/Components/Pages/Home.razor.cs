using Application.Contracts.Services;
using Application.ViewModels.Qotd;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Persistence;
using UI.Blazor.Services;

namespace UI.Blazor.Components.Pages;

public partial class Home
{
    [Inject] public IServiceManager ServiceManager { get; set; } = null!;
    public QuoteOfTheDayViewModel? QotdViewModel { get; set; }

    protected override async Task OnInitializedAsync()
    {
        QotdViewModel = await ServiceManager.QotdService.GetQuoteOfTheDayAsync();
    }
}
