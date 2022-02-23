using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BlazorState;
using Exobry.Examples.AB_FluentEmail.Components;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Exobry.Examples.AB_FluentEmail.Pages;

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

