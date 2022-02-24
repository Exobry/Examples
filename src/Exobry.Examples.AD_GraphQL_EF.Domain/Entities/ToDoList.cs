using Exobry.Examples.AD_GraphQL_EF.Domain.Interfaces;

namespace Exobry.Examples.AD_GraphQL_EF.Domain.Entities;

public class ToDoList : IEntity
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }

    public string Name { get; set; } = string.Empty;
    public virtual ICollection<ToDoItem> Items { get; set; } = new HashSet<ToDoItem>();
}