using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace UI.Blazor.ComponentsLibrary;

public static class LibraryServiceRegistration
{
    public static IServiceCollection AddComponentLibrary(this IServiceCollection services)
    {
        //Dialog
        services.AddScoped<DialogService>();

        return services;
    }
}