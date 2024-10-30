using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.PostFeatures.Commands.UpdatePostCommand;

public record UpdatePostCommand(Post Post) : IRequest<Post> { }