using FinanceGub.Application.DTOs;

namespace FinanceGub.Application.Interfaces.Serviсes;

public interface IEmailService
{
    Task SendContactFormEmailAsync(ContactFormDto contactForm);
    Task SendPostReportEmailAsync(ReportFormDto reportForm);
}