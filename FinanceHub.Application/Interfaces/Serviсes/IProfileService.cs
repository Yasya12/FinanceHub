using FinanceGub.Application.DTOs.Profile;
using FinanceHub.Core.Entities;

namespace FinanceGub.Application.Interfaces.Serviсes;

public interface IProfileService
{
    Task<IEnumerable<GetProfileDto>> GetAllProfile();
    Task<Profile> CreateProfileAsync(CreateProfileDto createProfileDto);
}