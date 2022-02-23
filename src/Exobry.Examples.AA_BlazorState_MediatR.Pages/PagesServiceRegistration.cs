﻿using BlazorState;
using Exobry.Examples.AA_BlazorState_MediatR.Components;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Exobry.Examples.AA_BlazorState_MediatR.Pages;

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
