using Application.ViewModels.Qotd;

namespace UI.Blazor.Components.Pages;
public partial class Home
{
    public QuoteOfTheDayViewModel? QotdViewModel { get; set; }

    protected override void OnInitialized()
    {
        QotdViewModel = new QuoteOfTheDayViewModel
        {
            AuthorName = "Ich",
            AuthorDescription = "Dozent",
            QuoteText = "Larum lierum L�ffelstiel",
            AuthorBirthDate = new DateOnly(1978, 07, 13)
        };
    }
}
