using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.PostCategoryFeatures.Commands.AddRangePostCategoryCommand;

public record AddRangePostCategoryCommand(Post ExistingPost, IEnumerable<Category> Categories) : IRequest;