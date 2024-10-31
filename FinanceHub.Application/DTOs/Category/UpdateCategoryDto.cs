using System.ComponentModel.DataAnnotations;

namespace FinanceGub.Application.DTOs.Category;

public class UpdateCategoryDto
{
    [Required(ErrorMessage = "Name is required")]
    [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
    public string Name { get; set; }

    [StringLength(200, ErrorMessage = "Description cannot exceed 200 characters")]
    public string Description { get; set; }
}