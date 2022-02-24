using Exobry.Examples.AD_GraphQL_EF.Application.Abstractions.Specifications;
using Exobry.Examples.AD_GraphQL_EF.Domain.Interfaces;

namespace Exobry.Examples.AD_GraphQL_EF.Application.Abstractions;

public interface IGenericRepository
{
    Task<T> GetById<T>(Guid id) where T : class;
    Task<T> Get<T>(ISpecification<T> spec) where T : class;
    Task<IEnumerable<T>> GetAll<T>(ISpecification<T>? spec = null) where T : class;
    Task<int> Count<T>(ISpecification<T>? spec = null) where T : class;
    Task<bool> IfExists<T>(ISpecification<T> spec) where T : class;

    Task<T> Insert<T>(T entity) where T : class;
    Task<int> Insert<T>(IEnumerable<T> entities) where T : class;
    Task<T> Update<T>(T entity) where T : class;
    Task Delete<T>(T entity) where T : class;
}
