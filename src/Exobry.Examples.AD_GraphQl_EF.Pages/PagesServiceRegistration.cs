using System.Reflection;
using BlazorState;
using Exobry.Examples.AD_GraphQl_EF.Components;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Exobry.Examples.AD_GraphQl_EF.Pages;

public static class PagesServiceRegistration
{
    public static IServiceCollection ConfigurePagesServices(this IServiceCollection services, Type program)
    {
        services.AddBlazorState(
            (options) => options.Assemblies = new Assembly[]
            {
                program.Assembly,
                typeof(PagesServiceRegistration).Assembly,
                typeof(ComponentsServiceRegistration).Assembly
            }
        );

        services.AddMediatR(
            program,
            typeof(PagesServiceRegistration), 
            typeof(ComponentsServiceRegistration));

        return services;
    }
}
