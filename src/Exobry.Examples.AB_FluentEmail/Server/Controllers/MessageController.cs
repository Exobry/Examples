using Exobry.Examples.AB_FluentMail.Server.Data;
using FluentEmail.Core;
using FluentEmail.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exobry.Examples.AB_FluentMail.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessageController : ControllerBase
{
    [HttpPost("")]
    public async Task<IActionResult> PostMessage([FromBody] MessageRequest request, [FromServices] IFluentEmailFactory emailFactory)
    {

        IFluentEmail email = emailFactory
            .Create()
            .To(request.Email)
            .Subject($"Email subject")
            .UsingTemplateFromFile($"{Directory.GetCurrentDirectory()}/Templates/Mail/Message.cshtml", request);

        SendResponse response = await email.SendAsync();
        if (response.Successful)
            return Ok(response);
        return BadRequest(response);
    }
}
