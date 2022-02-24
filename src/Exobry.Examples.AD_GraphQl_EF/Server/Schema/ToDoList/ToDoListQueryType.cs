using Microsoft.EntityFrameworkCore;

namespace Exobry.Examples.AD_GraphQl_EF.Server.Schema.ToDoList;

public class ToDoListQueryType: ObjectType<ToDoListQuery>
{
    protected override void Configure(IObjectTypeDescriptor<ToDoListQuery> descriptor)
    {
        descriptor
            .Field(f => f.GetToDoLists(default!));
    }
}
