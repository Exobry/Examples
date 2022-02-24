namespace Exobry.Examples.AD_GraphQL_EF.Domain.Interfaces;

public interface IEntity
{
    public Guid Id { get; init; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}

