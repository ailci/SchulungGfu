using Application.Contracts.Services;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace UI.Blazor.Services;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IQotdService> _qotdService;

    public ServiceManager(IAuthorService authorService, ILogger<QotdService> logger, IDbContextFactory<QotdContext> contextFactory, IMapper mapper)
    {
        _qotdService = new Lazy<IQotdService>(() => new QotdService(logger, contextFactory, mapper));
        AuthorService = authorService;
    }


    public IQotdService QotdService => _qotdService.Value;
    public IAuthorService AuthorService { get; }
}



//Old Version
//public class ServiceManager : IServiceManager
//{
//    public ServiceManager(IQotdService qotdService, IAuthorService authorService)
//    {
//        QotdService = qotdService;
//        AuthorService = authorService;
//    }


//    public IQotdService QotdService { get; }
//    public IAuthorService AuthorService { get; }
//}