using FinanceGub.Application.DTOs.Profile;
using FinanceHub.Core.Entities;

namespace FinanceGub.Application.Interfaces.Serviсes;

public interface IProfileService
{
    Task<IEnumerable<GetProfileDto>> GetAllProfileAsync();
    Task<GetProfileDto> GetProfileAsync(Guid id);
    Task<Profile> CreateProfileAsync(CreateProfileDto createProfileDto);
}