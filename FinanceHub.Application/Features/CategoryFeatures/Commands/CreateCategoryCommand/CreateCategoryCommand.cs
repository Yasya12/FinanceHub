using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.CategoryFeatures.Commands.CreateCategoryCommand;

public record CreateCategoryCommand (Category Category) : IRequest<Category> { }