using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.ProfileFeatures.Queries.GetByUserIdProfileQuery;

public class GetByUserIdProfileQueryHandler : IRequestHandler<GetByUserIdProfileQuery, Profile>
{
    private readonly IProfileRepository _profileRepository;

    public GetByUserIdProfileQueryHandler(IProfileRepository profileRepository)
    {
        _profileRepository = profileRepository;
    }
    
    public async Task<Profile> Handle(GetByUserIdProfileQuery request, CancellationToken cancellationToken)
    {
        return await _profileRepository.GetByUserIdAsync(request.UserId);
    }
}