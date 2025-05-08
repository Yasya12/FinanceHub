using AutoMapper;
using AutoMapper.QueryableExtensions;
using FinanceGub.Application.DTOs.Message;
using FinanceGub.Application.Helpers;
using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Entities;
using FinanceHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FinanceHub.Infrastructure.Repositories;

public class MessageRepository(FinHubDbContext context, IMapper mapper) : GenericRepository<Message>(context), IMessageRepository
{
    public async Task<PagedList<MessageDto>> GetMessagesForUser(MessageParams messageParams)
    {
        var query = _dbSet.OrderByDescending(x => x.MessageSent).AsQueryable();

        query = messageParams.Container switch
        {
            "Inbox" => query.Where(x => x.RecipientUserName == messageParams.Username && x.RecipientDeleted == false),
            "Outbox" => query.Where(x => x.SenderUserName == messageParams.Username && x.SenderDeleted == false),
            _ => query.Where(x => x.RecipientUserName == messageParams.Username && x.DateRead == null && x.RecipientDeleted == false)
        };

        var messages = query.ProjectTo<MessageDto>(mapper.ConfigurationProvider);

        return await PagedList<MessageDto>.CreateAsync(messages, messageParams.PageNumber, messageParams.PageSize);
    }

    public async Task<PagedList<MessageDto>> GetMessageThread(string currentUsername, string recipientUsername, MessageThreadParams messageThreadParams)
    {
        var query = _dbSet
            .Include(x => x.Sender)
            .Include(x => x.Recipient)
            .Where(x =>
                (x.RecipientUserName == currentUsername && !x.RecipientDeleted && x.SenderUserName == recipientUsername) ||
                (x.SenderUserName == currentUsername && !x.SenderDeleted && x.RecipientUserName == recipientUsername))
            .OrderByDescending(x => x.MessageSent)
            .AsQueryable();

        // Mark unread messages as read
        var unreadMessages = await query
            .Where(x => x.DateRead == null && x.RecipientUserName == currentUsername)
            .ToListAsync();

        if (unreadMessages.Any())
        {
            unreadMessages.ForEach(x => x.DateRead = DateTime.UtcNow);
            await context.SaveChangesAsync();
        }

        var projected = query.ProjectTo<MessageDto>(mapper.ConfigurationProvider);
        
        return await PagedList<MessageDto>.CreateAsync(projected, messageThreadParams.PageNumber, messageThreadParams.PageSize);
    }
}