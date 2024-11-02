using FinanceGub.Application.Interfaces.Repositories;
using MediatR;

namespace FinanceGub.Application.Features.PostCategoryFeatures.Commands.AddRangePostCategoryCommand;

public class AddRangePostCategoryCommandHandler : IRequestHandler<AddRangePostCategoryCommand>
{
    private readonly IPostCategoryRepository _postCategoryRepository;

    public AddRangePostCategoryCommandHandler(IPostCategoryRepository postCategoryRepository)
    {
        _postCategoryRepository = postCategoryRepository;
    }
    
    public async Task Handle(AddRangePostCategoryCommand request, CancellationToken cancellationToken)
    {
        await _postCategoryRepository.AddRangeAsync(request.ExistingPost, request.Categories);
    }
}