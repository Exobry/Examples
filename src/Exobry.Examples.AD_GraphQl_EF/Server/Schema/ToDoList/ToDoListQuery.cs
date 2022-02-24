using Exobry.Examples.AD_GraphQL_EF.Application.Abstractions;

namespace Exobry.Examples.AD_GraphQl_EF.Server.Schema.ToDoList;

public class ToDoListQuery
{
    public async Task<IEnumerable<AD_GraphQL_EF.Domain.Entities.ToDoList>> GetToDoLists([Service] IGenericRepository genericRepository)
    {
        return await genericRepository.GetAll<AD_GraphQL_EF.Domain.Entities.ToDoList>();
    }
}

