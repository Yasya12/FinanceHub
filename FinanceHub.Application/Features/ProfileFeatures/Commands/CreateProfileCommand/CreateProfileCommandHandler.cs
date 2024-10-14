using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.ProfileFeatures.Commands.CreateProfileCommand;

public class CreateProfileCommandHandler : IRequestHandler<CreateProfileCommand, Profile>
{
    private readonly IProfileRepository _profileRepository;

    public CreateProfileCommandHandler(IProfileRepository profileRepository)
    {
        _profileRepository = profileRepository;
    }
    
    public async Task<Profile> Handle(CreateProfileCommand request, CancellationToken cancellationToken)
    {
        await _profileRepository.AddAsync(request.Profile);
        return request.Profile;
    }
}