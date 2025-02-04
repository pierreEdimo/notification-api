using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace notification_api.Email;

public class EmailRepository(DatabaseContext context) : IEmailRepository
{
    public async Task<ActionResult<EmailModel>> SaveMail(EmailModel email)
    {
        var createdEmail = context.Add(email).Entity;

        await context.SaveChangesAsync();

        return new CreatedResult("GetSingleEmail", createdEmail);
    }

    public async Task<List<EmailModel>> GetEmails(string userId)
    {
        return await context.Emails.ToListAsync();
    }
}