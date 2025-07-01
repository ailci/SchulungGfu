using Application.Contracts.Services;
using Application.Utilities;
using Application.ViewModels.Qotd;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Persistence;
using UI.Blazor.Services;

namespace UI.Blazor.Components.Pages;

public partial class Home
{
    [Inject] private ILogger<Home> Logger { get; set; } = null!;
    [Inject] public IServiceManager ServiceManager { get; set; } = null!;

    //https://learn.microsoft.com/en-us/aspnet/core/blazor/components/prerender?view=aspnetcore-9.0
    [Inject] public PersistentComponentState ApplicationState { get; set; } = null!;
    private PersistingComponentStateSubscription _persistingComponentStateSubscription;
    public QuoteOfTheDayViewModel? QotdViewModel { get; set; }

    protected override async Task OnInitializedAsync()
    {
        _persistingComponentStateSubscription = ApplicationState.RegisterOnPersisting(PersistData);

        if (!ApplicationState.TryTakeFromJson<QuoteOfTheDayViewModel>(nameof(QotdViewModel), out var restoredData))
        {
            QotdViewModel = await ServiceManager.QotdService.GetQuoteOfTheDayAsync();
        }
        else
        {
            QotdViewModel = restoredData;
        }

        //Logger.LogInformation($"QotdViewmodel => {QotdViewModel?.LogAsJson()}");
    }

    private Task PersistData()
    {
        ApplicationState.PersistAsJson(nameof(QotdViewModel),QotdViewModel);
        return Task.CompletedTask;
    }

    // 2.Lösung via OnAfterRender
    //protected override async Task OnAfterRenderAsync(bool firstRender)
    //{
    //    if (firstRender)
    //    {
    //        QotdViewModel = await ServiceManager.QotdService.GetQuoteOfTheDayAsync();
    //        StateHasChanged();
    //    }
    //}
}
