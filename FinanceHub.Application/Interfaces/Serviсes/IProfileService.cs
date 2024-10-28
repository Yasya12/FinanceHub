using FinanceGub.Application.DTOs.Profile;

namespace FinanceGub.Application.Interfaces.Serviсes;

public interface IProfileService
{
    Task<IEnumerable<GetProfileDto>> GetAllProfileAsync();
    Task<GetProfileDto> GetProfileAsync(Guid id);
    Task<CreateProfileDto> CreateProfileAsync(CreateProfileDto createProfileDto);
}