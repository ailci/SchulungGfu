using Application.Contracts.Services;

namespace UI.Blazor.Services;

public class ServiceManager : IServiceManager
{
    public ServiceManager(IQotdService qotdService, IAuthorService authorService)
    {
        QotdService = qotdService;
        AuthorService = authorService;
    }


    public IQotdService QotdService { get; }
    public IAuthorService AuthorService { get; }
}