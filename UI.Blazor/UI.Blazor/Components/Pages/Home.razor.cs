using Application.ViewModels.Qotd;
using Microsoft.AspNetCore.Components;
using Persistence;

namespace UI.Blazor.Components.Pages;
public partial class Home
{
    [Inject] public QotdContext QotdContext { get; set; } = null!;
    public QuoteOfTheDayViewModel? QotdViewModel { get; set; }

    protected override void OnInitialized()
    {
        var quotes = QotdContext.Quotes.ToList();


        QotdViewModel = new QuoteOfTheDayViewModel
        {
            AuthorName = "Ich",
            AuthorDescription = "Dozent",
            QuoteText = "Larum lierum Löffelstiel",
            AuthorBirthDate = new DateOnly(1978, 07, 13)
        };
    }
}
