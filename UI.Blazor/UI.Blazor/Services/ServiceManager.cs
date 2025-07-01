using Application.Contracts.Services;

namespace UI.Blazor.Services;

public class ServiceManager : IServiceManager
{
    public ServiceManager(IQotdService qotdService)
    {
        QotdService = qotdService;
    }


    public IQotdService QotdService { get; }
}