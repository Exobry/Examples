namespace Exobry.Examples.AB_FluentMail.Client.Components.Contact;

public partial class ContactComponentState : State<ContactComponentState>
{
    public override void Initialize()
    { }

    public string Email { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;

    public bool IsFormProcessing { get; set; } = false;
    public bool IsFormSuccessfullyProcessed { get; set; } = false;
    public bool DisplayProcessedResult { get; set; } = false;
}
