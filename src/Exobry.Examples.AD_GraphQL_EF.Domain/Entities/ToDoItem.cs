using Exobry.Examples.AD_GraphQL_EF.Domain.Interfaces;

namespace Exobry.Examples.AD_GraphQL_EF.Domain.Entities;

public class ToDoItem : IEntity
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }

    public bool IsDone { get; set; } = false;
    public string Description { get; set; } = string.Empty;

    public Guid ToDoListId { get; set; }
    public virtual ToDoList ToDoList { get; set; }
}

