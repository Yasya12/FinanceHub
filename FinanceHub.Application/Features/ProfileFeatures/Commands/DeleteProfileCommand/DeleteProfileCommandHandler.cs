using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Entities;
using FinanceHub.Core.Exceptions;
using MediatR;

namespace FinanceGub.Application.Features.ProfileFeatures.Commands.DeleteProfileCommand;

public class DeleteProfileCommandHandler : IRequestHandler<DeleteProfileCommand, string>
{
    private readonly IProfileRepository _profileRepository;

    public DeleteProfileCommandHandler(IProfileRepository profileRepository)
    {
        _profileRepository = profileRepository;
    }
    
    public async Task<string> Handle(DeleteProfileCommand request, CancellationToken cancellationToken)
    {
        var profile = await _profileRepository.GetByIdAsync(request.Id);

        if (profile == null)
        {
            throw new NotFoundException($"Profile with ID {request.Id} not found.");
        }
        
        var message = await _profileRepository.DeleteAsync(request.Id);
        return message;
    }
}