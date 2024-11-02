using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.PostCategoryFeatures.Commands.RemoveRangePostCategoryCommand;

public record RemoveRangePostCategoryCommand(IEnumerable<PostCategory> postCategories) : IRequest<string>;