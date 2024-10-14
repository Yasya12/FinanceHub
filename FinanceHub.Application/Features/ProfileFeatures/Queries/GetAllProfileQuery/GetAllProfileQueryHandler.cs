using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.ProfileFeatures.Queries.GetAllProfileQuery;

public class GetAllProfileQueryHandler : IRequestHandler<GetAllProfileQuery, IEnumerable<Profile>>
{
    private readonly IProfileRepository _profileRepository;

    public GetAllProfileQueryHandler(IProfileRepository profileRepository)
    {
        _profileRepository = profileRepository;
    }
    
    public async Task<IEnumerable<Profile>> Handle(GetAllProfileQuery request, CancellationToken cancellationToken)
    {
       return await _profileRepository.GetAllAsync(request.IncludeProperties);
    }
}