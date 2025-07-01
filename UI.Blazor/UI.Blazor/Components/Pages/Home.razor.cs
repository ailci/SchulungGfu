using Application.ViewModels.Qotd;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace UI.Blazor.Components.Pages;

public partial class Home
{
    [Inject] public QotdContext QotdContext { get; set; } = null!;
    public QuoteOfTheDayViewModel? QotdViewModel { get; set; }

    protected override void OnInitialized()
    {
        var quote = QotdContext.Quotes.Include(c => c.Author).ToList()[0];


        QotdViewModel = new QuoteOfTheDayViewModel
        {
            AuthorName = quote.Author?.Name,
            AuthorDescription = "Dozent",
            QuoteText = "Larum lierum Löffelstiel",
            AuthorBirthDate = new DateOnly(1978, 07, 13)
        };
    }
}
