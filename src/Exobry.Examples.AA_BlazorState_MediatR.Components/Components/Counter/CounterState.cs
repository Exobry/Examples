using BlazorState;
namespace Exobry.Examples.AA_BlazorState_MediatR.Components.Counter;

public partial class CounterState : State<CounterState>
{
    public override void Initialize()
    {}

    public int Value { get; set; } = 0;
}
