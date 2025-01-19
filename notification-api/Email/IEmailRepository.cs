using Microsoft.AspNetCore.Mvc;

namespace notification_api.Email;

public interface IEmailRepository
{
    Task<ActionResult<EmailModel>> SaveMail(EmailModel email);
    Task<List<EmailModel>> GetEmails(string userId);
}