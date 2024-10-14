using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Entities;
using FinanceHub.Core.Exceptions;
using MediatR;

namespace FinanceGub.Application.Features.ProfileFeatures.Commands.UpdateProfileCommand;

public class UpdateProfileCommandHandler : IRequestHandler<UpdateProfileCommand, Profile>
{
    private readonly IProfileRepository _profileRepository;

    public UpdateProfileCommandHandler(IProfileRepository profileRepository)
    {
        _profileRepository = profileRepository;
    }
    
    public async Task<Profile> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
    {
        var profile = _profileRepository.GetByIdAsync(request.Profile.Id);

        if (profile == null)
        {
            throw new NotFoundException($"Profile with ID {request.Profile.Id} not found.");
        }
        
        await _profileRepository.UpdateAsync(request.Profile);
        return request.Profile;
    }
}