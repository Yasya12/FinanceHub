using System.Net;
using System.Net.Mail;
using FinanceGub.Application.DTOs;
using FinanceGub.Application.Interfaces.Serviсes;
using Microsoft.Extensions.Configuration;

namespace FinanceHub.Infrastructure.Services;

public class EmailService : IEmailService
{
    private readonly IConfiguration _config;

    public EmailService(IConfiguration config)
    {
        _config = config;
    }

    public async Task SendContactFormEmailAsync(ContactFormDto contactForm)
    {
        var smtpClient = new SmtpClient(_config["Smtp:Host"])
        {
            Port = int.Parse(_config["Smtp:Port"]),
            Credentials = new NetworkCredential(_config["Smtp:Username"], _config["Smtp:Password"]),
            EnableSsl = true
        };

        var mailMessage = new MailMessage
        {
            From = new MailAddress(
                _config["Smtp:Username"]), 
            ReplyToList = { new MailAddress(contactForm.Email) }, 
            Subject = $"[FinHub] {contactForm.Subject}",
            Body = $@"
                <html>
                  <body style='font-family: Arial, sans-serif; color: #333;'>
                    <p><strong>Ви отримали нове повідомлення з сайту FinHub.ua</strong></p>
                    <p><strong>Ім'я:</strong> {contactForm.FirstName} {contactForm.LastName}<br/>
                       <strong>Email:</strong> <a href='mailto:{contactForm.Email}'>{contactForm.Email}</a><br/>
                       <strong>Повідомлення:</strong><br/>
                       {contactForm.Message}</p>
                    <hr/>
                    <p style='font-size: 0.9em;'>Відправлено з сайту <a href='https://finhub.ua'>finhub.ua</a></p>
                  </body>
                </html>",
            IsBodyHtml = true,
        };

        mailMessage.To.Add(_config["Smtp:ToEmail"]);

        await smtpClient.SendMailAsync(mailMessage);
    }
    
    public async Task SendPostReportEmailAsync(ReportFormDto reportForm)
    {
        var smtpClient = new SmtpClient(_config["Smtp:Host"])
        {
            Port = int.Parse(_config["Smtp:Port"]),
            Credentials = new NetworkCredential(_config["Smtp:Username"], _config["Smtp:Password"]),
            EnableSsl = true
        };

        var postUrl = $"https://finhub/post/{reportForm.PostId}"; // Припускаємо структуру URL вашого сайту

        var mailMessage = new MailMessage
        {
            From = new MailAddress(_config["Smtp:Username"]),
            Subject = $"[FinHub Report] Нова скарга на пост",
            Body = $@"
                <html>
                  <body style='font-family: Arial, sans-serif; color: #333;'>
                    <h2>Нова скарга на контент</h2>
                    <p>Ви отримали нову скаргу на пост на сайті FinHub.ua.</p>
                    <hr/>
                    <p><strong>ID Поста:</strong> {reportForm.PostId}</p>
                    <p><strong>Посилання на пост:</strong> <a href='{postUrl}'>{postUrl}</a></p>
                    <p><strong>Причина скарги:</strong> {reportForm.Reason}</p>
                    <hr/>
                    <p><strong>Користувач, що надіслав скаргу:</strong></p>
                    <p><strong>ID:</strong> {reportForm.ReportingUserId}<br/>
                       <strong>Username:</strong> {reportForm.ReportingUsername}</p>
                    <p style='font-size: 0.9em; color: #777;'>Будь ласка, перевірте цей контент якомога швидше.</p>
                  </body>
                </html>",
            IsBodyHtml = true,
        };

        // Відправляємо лист на вашу пошту для модерації
        mailMessage.To.Add(_config["Smtp:ToEmail"]);

        await smtpClient.SendMailAsync(mailMessage);
    }
}