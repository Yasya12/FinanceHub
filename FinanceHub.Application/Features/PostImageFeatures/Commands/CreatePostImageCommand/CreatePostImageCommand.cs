using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.PostImageFeatures.Commands.CreatePostImageCommand;

public record CreatePostImageCommand(PostImage PostImage) : IRequest<PostImage>;