using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.ProfileFeatures.Queries.GetProfileQuery;

public class GetProfileQueryHandler: IRequestHandler<GetProfileQuery, Profile>
{
    private readonly IProfileRepository _profileRepository;

    public GetProfileQueryHandler(IProfileRepository profileRepository)
    {
        _profileRepository = profileRepository;
    }
    public async Task<Profile> Handle(GetProfileQuery request, CancellationToken cancellationToken)
    {
        return await _profileRepository.GetByIdAsync(request.Id, request.IncludeProperties);
    }
}