namespace FinanceGub.Application.DTOs.Category;

public class GetCategoryDto
{
    public string Name { get; set; }

    public string Description { get; set; }
    public IEnumerable<string> PostNames { get; set; }
}