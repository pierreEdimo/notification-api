namespace notification_api.Email
{
    public interface IEmailService
    {
        void SendEmail(EmailModel email);
    }
}