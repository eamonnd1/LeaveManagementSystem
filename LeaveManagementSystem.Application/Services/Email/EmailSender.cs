using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Azure.Communication.Email;
using Azure;

namespace LeaveManagementSystem.Application.Services.Email;

public class EmailSender(IConfiguration _configuration) : IEmailSender
{
    
    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        var connectionString = _configuration["EmailSettings:ConnectionString"];
        var emailClient = new EmailClient(connectionString);
        var fromAddress = _configuration["EmailSettings:DefaultEmailAddress"];
        var emailMessage = new EmailMessage(
            senderAddress: fromAddress,
            content: new EmailContent(subject)
                {
                    Html = htmlMessage
                },
                recipients: new EmailRecipients(new List<EmailAddress> { new EmailAddress(email) }));

        EmailSendOperation emailSendOperation = await emailClient
            .SendAsync(WaitUntil.Completed, emailMessage);
    }
}
