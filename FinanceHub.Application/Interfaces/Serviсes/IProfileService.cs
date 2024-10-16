using FinanceGub.Application.DTOs.Profile;
using FinanceHub.Core.Entities;

namespace FinanceGub.Application.Interfaces.Serviсes;

public interface IProfileService
{
    Task<Profile> CreateProfileAsync(CreateProfileDto createProfileDto);
}