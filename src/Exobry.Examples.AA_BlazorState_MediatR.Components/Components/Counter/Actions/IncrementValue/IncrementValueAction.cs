using BlazorState;
namespace Exobry.Examples.AA_BlazorState_MediatR.Components.Counter;

public partial class CounterState
{
    public record IncrementValueAction(int IncrementValue): IAction;
}
