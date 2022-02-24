using Exobry.Examples.AD_GraphQL_EF.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exobry.Examples.AD_GraphQL_EF.Infrastructure.EntityFramework.Configurations;

public class ToDoItemConfiguration : IEntityTypeConfiguration<ToDoItem>
{
    public void Configure(EntityTypeBuilder<ToDoItem> builder)
    {
        builder.HasOne(x => x.ToDoList)
            .WithMany(x => x.Items)
            .HasForeignKey(x => x.ToDoListId);
    }
}

