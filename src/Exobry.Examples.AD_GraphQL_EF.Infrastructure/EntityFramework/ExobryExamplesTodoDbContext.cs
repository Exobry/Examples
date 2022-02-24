using Exobry.Examples.AD_GraphQL_EF.Domain.Entities;
using Exobry.Examples.AD_GraphQL_EF.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Exobry.Examples.AD_GraphQL_EF.Infrastructure.EntityFramework;

// https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli
public class ExobryExamplesTodoDbContext : AuditableExobryExamplesTodoDbContext<ExobryExamplesTodoDbContext>
{
    public DbSet<ToDoItem> TodoItems { get; set; }
    public DbSet<ToDoList> ToDoLists { get; set; }

    public ExobryExamplesTodoDbContext(DbContextOptions<ExobryExamplesTodoDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var allEntities = modelBuilder.Model.GetEntityTypes();

        foreach (var entity in allEntities)
        {
            // Add datetime entries to relationship tables
            if (entity.FindProperty(nameof(IEntity.CreatedDate)) == null)
            {
                entity.AddProperty(nameof(IEntity.CreatedDate), typeof(DateTime));
            }

            if (entity.FindProperty(nameof(IEntity.UpdatedDate)) == null)
            {
                entity.AddProperty(nameof(IEntity.UpdatedDate), typeof(DateTime));
            }
        }

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ExobryExamplesTodoDbContext).Assembly);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<string>().HaveMaxLength(50);
    }
}

