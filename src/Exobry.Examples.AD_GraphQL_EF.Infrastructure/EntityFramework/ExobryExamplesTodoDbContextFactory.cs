using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Exobry.Examples.AD_GraphQL_EF.Infrastructure.EntityFramework
{
    // Used for Entity Framework Migrations
    // https://docs.microsoft.com/en-us/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli
    internal class ExobryExamplesTodoDbContextFactory : IDesignTimeDbContextFactory<ExobryExamplesTodoDbContext>
    {
        public ExobryExamplesTodoDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ExobryExamplesTodoDbContext>();
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=ExobryExamplesTodo");

            return new ExobryExamplesTodoDbContext(optionsBuilder.Options);
        }
    }
}
