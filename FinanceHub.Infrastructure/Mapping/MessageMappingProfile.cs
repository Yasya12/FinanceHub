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
                o => o.MapFrom(s => s.Sender.ProfilePictureUrl))
            .ForMember(d => d.RecipientUPhotoUrl, 
            o => o.MapFrom(s => s.Recipient.ProfilePictureUrl));

        CreateMap<Message, ChatUserDto>()
            .ForMember(dest => dest.Username, opt => opt.MapFrom((src, dest, destMember, context) =>
            {
                var currentUsername = context.Items["currentUsername"] as string;
                return src.SenderUserName == currentUsername ? src.Recipient.UserName : src.Sender.UserName;
            }))
            .ForMember(dest => dest.Email, opt => opt.MapFrom((src, dest, destMember, context) =>
            {
                var currentEmail = context.Items["currentEmail"] as string;

                var senderEmail = src.Sender?.Email;
                var recipientEmail = src.Recipient?.Email;

                if (senderEmail == null || recipientEmail == null)
                {
                    return null; // або throw, або логування, залежно від вимог
                }

                return senderEmail == currentEmail ? recipientEmail : senderEmail;
            }))
            .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom((src, dest, destMember, context) =>
            {
                var currentUsername = context.Items["currentUsername"] as string;
                return src.SenderUserName == currentUsername
                    ? src.Recipient.ProfilePictureUrl
                    : src.Sender.ProfilePictureUrl;
            }))
            .ForMember(dest => dest.LastMessage, opt => opt.MapFrom(src => src.Content))
            .ForMember(dest => dest.LastMessageSent, opt => opt.MapFrom(src => src.MessageSent))
            .ForMember(dest => dest.IsRead, opt => opt.MapFrom((src, dest, destMember, context) =>
            {
                var currentUsername = context.Items["currentUsername"] as string;

                // Якщо поточний користувач — відправник, то він точно читав це повідомлення
                if (src.SenderUserName == currentUsername)
                {
                    return true;
                }

                // Якщо поточний користувач — отримувач, то IsRead залежить від DateRead
                return src.DateRead != null;
            }));
    }
    
}