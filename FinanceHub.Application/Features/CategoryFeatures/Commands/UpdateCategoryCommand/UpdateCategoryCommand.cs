using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.CategoryFeatures.Commands.UpdateCategoryCommand;

public record UpdateCategoryCommand(Category Category) : IRequest<Category>;