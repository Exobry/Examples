using BlazorState;
using MediatR;

namespace Exobry.Examples.AA_BlazorState_MediatR.Components.Counter;

public partial class CounterState
{

    public class IncrementValueHandler : ActionHandler<IncrementValueAction>
    {
        CounterState CounterState => Store.GetState<CounterState>();

        public IncrementValueHandler(IStore store) 
            : base(store){}

        public override Task<Unit> Handle(IncrementValueAction aAction, CancellationToken aCancellationToken)
        {
            CounterState.Value += aAction.IncrementValue;
            return Unit.Task;
        }
    }
}
