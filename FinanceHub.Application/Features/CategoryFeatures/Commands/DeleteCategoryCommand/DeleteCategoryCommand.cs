using MediatR;

namespace FinanceGub.Application.Features.CategoryFeatures.Commands.DeleteCategoryCommand;

public record DeleteCategoryCommand(Guid Id) : IRequest<string>;