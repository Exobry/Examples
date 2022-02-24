using Exobry.Examples.AD_GraphQL_EF.Application.Abstractions;
using Exobry.Examples.AD_GraphQL_EF.Infrastructure.EntityFramework;
using Exobry.Examples.AD_GraphQL_EF.Infrastructure.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Exobry.Examples.AD_GraphQL_EF.Infrastructure;

public static class InfrastructureServiceRegistration
{

    public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddMediatR(typeof(InfrastructureServiceRegistration));
        services.AddPooledDbContextFactory<ExobryExamplesTodoDbContext>(options =>
        {
            options.UseSqlServer(
                configuration.GetSection("ConnectionStrings")["Exobry_Examples_Todo"]
            );

            #if DEBUG
            options
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
                .EnableSensitiveDataLogging();
            #endif
        });

        services.AddTransient(typeof(IGenericRepository), typeof(GenericRepository));

        return services;
    }
}

