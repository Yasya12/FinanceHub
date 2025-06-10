using System.ComponentModel.DataAnnotations;

namespace FinanceGub.Application.DTOs;

public class ReportFormDto
{
    [Required]
    public string PostId { get; set; }

    [Required]
    public string Reason { get; set; }
    
    // Ці поля ми заповнимо на бекенді, щоб користувач не міг їх підробити
    public Guid? ReportingUserId { get; set; }
    public string? ReportingUsername { get; set; }
}