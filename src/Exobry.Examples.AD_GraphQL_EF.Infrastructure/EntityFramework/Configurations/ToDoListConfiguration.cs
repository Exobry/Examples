using Exobry.Examples.AD_GraphQL_EF.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exobry.Examples.AD_GraphQL_EF.Infrastructure.EntityFramework.Configurations
{
    internal class ToDoListConfiguration : IEntityTypeConfiguration<ToDoList>
    {
        public void Configure(EntityTypeBuilder<ToDoList> builder)
        {
            builder.HasMany(x => x.Items)
                .WithOne(x => x.ToDoList)
                .HasForeignKey(x => x.ToDoListId);
        }
    }
}
