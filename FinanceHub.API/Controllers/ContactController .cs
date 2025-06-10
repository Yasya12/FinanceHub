using System.Security.Claims;
using FinanceGub.Application.DTOs;
using FinanceGub.Application.Features.UserFeatures.Queries.GetByEmailUserQuery;
using FinanceGub.Application.Interfaces.Serviсes;
using FinanceHub.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceHub.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactController(IEmailService emailService, IMediator mediator) : ControllerBase
{
    [HttpPost("send")]
    public async Task<IActionResult> SendContactForm([FromBody] ContactFormDto contactForm)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await emailService.SendContactFormEmailAsync(contactForm);

        return Ok(new { message = "Повідомлення надіслано успішно!" });
    }
    
    [Authorize] 
    [HttpPost("report")]
    public async Task<IActionResult> ReportPost([FromBody] ReportFormDto reportForm)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var user = await mediator.Send(new GetByEmailUserQuery(User.GetEmail()));

        if (user == null) return BadRequest("User not found");

        // Записуємо дані користувача в DTO
        reportForm.ReportingUserId = user.Id;
        reportForm.ReportingUsername = user.UserName;
        
        await emailService.SendPostReportEmailAsync(reportForm);

        return Ok(new { message = "Скарга успішно надіслана. Дякуємо за вашу допомогу!" });
    }
}