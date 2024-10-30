using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.PostFeatures.Commands.CreatePostCommand;

public record CreatePostCommand(Post Post) : IRequest<Post>;