using Microsoft.AspNetCore.Mvc;

namespace notification_api.Email;

[ApiController]
[Route("api/[controller]")]
public class EmailsController(IEmailRepository emailRepository,
                              IEmailService emailService  ): ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<EmailModel>> SendAndSaveEmail([FromBody] EmailModel email)
    {
        emailService.SendEmail(email);
        return await emailRepository.SaveMail(email);
    }

    [HttpGet("{userId}")]
    public async Task<ActionResult<List<EmailModel>>> GetEmails(string userId)
    {
        return await emailRepository.GetEmails(userId);
    }
}