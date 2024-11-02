using FinanceGub.Application.Interfaces.Repositories;
using MediatR;

namespace FinanceGub.Application.Features.PostCategoryFeatures.Commands.RemoveRangePostCategoryCommand;

public class RemoveRangePostCategoryCommandHandler : IRequestHandler<RemoveRangePostCategoryCommand, string>
{
    private readonly IPostCategoryRepository _postCategoryRepository;

    public RemoveRangePostCategoryCommandHandler(IPostCategoryRepository postCategoryRepository)
    {
        _postCategoryRepository = postCategoryRepository;
    }
    
    public async Task<string> Handle(Commands.RemoveRangePostCategoryCommand.RemoveRangePostCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _postCategoryRepository.RemoveRangeAsync(request.postCategories);

            return "Categories deleted successfully.";
        }
        catch (Exception ex)
        {
            return $"Error deleting categories: {ex.Message}";
        }
    }
}