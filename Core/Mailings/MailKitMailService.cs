using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace Core.Mailings
{
    public class MailKitMailService : IMailService
    {
        private readonly IConfiguration _configuration;
        private readonly MailSettings settings;

        public MailKitMailService(IConfiguration configuration)
        {
            _configuration = configuration;
            this.settings = _configuration.GetSection("MailSettings").Get<MailSettings>();

        }

        public async Task SendMailAsync(Mail mail)
        {
            MimeMessage email = new();
            email.From.Add(new MailboxAddress(settings.SenderFullName, settings.SenderEmail));
            email.To.Add(new MailboxAddress(mail.ToFullName, mail.ToEmail));
            email.Subject = mail.Subject;
            BodyBuilder builder = new()
            {
                TextBody = mail.TextBody,
                HtmlBody = mail.HtmlBody,
            };
            if (mail.Attachments != null)
                foreach (MimeEntity? attachment in mail.Attachments)
                    builder.Attachments.Add(attachment);

            email.Body = builder.ToMessageBody();
            using SmtpClient smtp = new();
            await smtp.ConnectAsync(settings.Server, settings.Port, false);
            await smtp.AuthenticateAsync(settings.UserName, settings.Password);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(false);

        }
    }
}
