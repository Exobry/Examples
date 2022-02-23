using System.ComponentModel.DataAnnotations;

namespace Exobry.Examples.AB_FluentMail.Server.Data;

public class MessageRequest
{
    [Required]
    public string Message { get; set; } = string.Empty;
    [Required]
    public string Email { get; set; } = string.Empty;
}
