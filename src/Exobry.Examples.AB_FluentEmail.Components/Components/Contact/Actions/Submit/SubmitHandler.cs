using System.Net.Http.Json;

namespace Exobry.Examples.AB_FluentMail.Client.Components.Contact;

public partial class ContactComponentState
{
    public class SubmitHandler : ActionHandler<SubmitAction>
    {
        ContactComponentState ContactState => Store.GetState<ContactComponentState>();
        private readonly HttpClient _httpClient;
        public SubmitHandler(IStore aStore, HttpClient httpClient) : base(aStore)
        {
            _httpClient = httpClient;
        }

        public override async Task<Unit> Handle(SubmitAction aAction, CancellationToken aCancellationToken)
        {
            if (!ContactState.IsFormProcessing)
            {
                try
                {
                    ContactState.IsFormProcessing = true;

                    ImmutableMessage requestMessage = new(ContactState.Email, ContactState.Message);
                    HttpResponseMessage result = await _httpClient.PostAsJsonAsync("api/message", requestMessage);

                    ContactState.IsFormSuccessfullyProcessed = result.IsSuccessStatusCode;
                    ContactState.DisplayProcessedResult = true;
                }
                finally
                {
                    ContactState.IsFormProcessing = false;
                }
            }
            return await Unit.Task;
        }
    }
}
