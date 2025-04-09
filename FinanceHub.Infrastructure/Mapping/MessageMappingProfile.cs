using FinanceGub.Application.DTOs.Message;
using FinanceHub.Core.Entities;
using Profile = AutoMapper.Profile;

namespace FinanceHub.Infrastructure.Mapping;

public class MessageMappingProfile : Profile
{
    public MessageMappingProfile()
    {
        CreateMap<Message, MessageDto>()
            .ForMember(d => d.SenderUPhotoUrl, 
                o => o.MapFrom(s => s.Sender.Profile!.ProfilePictureUrl))
            .ForMember(d => d.RecipientUPhotoUrl, 
            o => o.MapFrom(s => s.Recipient.Profile!.ProfilePictureUrl));
    }
}