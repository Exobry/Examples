using Exobry.Examples.AD_GraphQL_EF.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Exobry.Examples.AD_GraphQL_EF.Infrastructure.EntityFramework;

public class AuditableExobryExamplesTodoDbContext<T> : DbContext
    where T : DbContext
{
    public AuditableExobryExamplesTodoDbContext(DbContextOptions<T> dbContextOptions)
        : base(dbContextOptions)
    {

    }

    public AuditableExobryExamplesTodoDbContext()
    {

    }

    public async Task<int> SaveChangesAsync()
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.State is EntityState.Added or EntityState.Modified);

        foreach (var entityEntry in entries)
        {
            DateTime dateTime = DateTime.Now;
            entityEntry.Property(nameof(IEntity.UpdatedDate)).CurrentValue = dateTime;

            if (entityEntry.State == EntityState.Added)
            {
                entityEntry.Property(nameof(IEntity.CreatedDate)).CurrentValue = dateTime;
            }
        }

        return await base.SaveChangesAsync();
    }
}

