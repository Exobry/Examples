namespace Exobry.Examples.AB_FluentMail.Client.Components.Contact;

public partial class ContactComponentState
{
    public class ResetHandler : ActionHandler<ResetAction>
    {
        ContactComponentState ContactState => Store.GetState<ContactComponentState>();
        public ResetHandler(IStore aStore) : base(aStore)
        {
        }

        public override Task<Unit> Handle(ResetAction aAction, CancellationToken aCancellationToken)
        {
            ContactState.Email = string.Empty;
            ContactState.Message = string.Empty;

            ContactState.IsFormSuccessfullyProcessed = false;
            ContactState.DisplayProcessedResult = false;
            ContactState.IsFormProcessing = false;
            return Unit.Task;
        }
    }
}
