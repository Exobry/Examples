using BlazorState;

namespace Exobry.Examples.AD_GraphQl_EF.Components.Components.Todo.AddToDoList;

public class AddToDoListComponentState : State<AddToDoListComponentState>
{
    public override void Initialize()
    {
        // ignore
    }

    public string Name { get; set; } = string.Empty;
}