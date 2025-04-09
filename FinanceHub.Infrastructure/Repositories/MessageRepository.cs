using AutoMapper;
using AutoMapper.QueryableExtensions;
using FinanceGub.Application.DTOs.Message;
using FinanceGub.Application.Helpers;
using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Entities;
using FinanceHub.Infrastructure.Data;

namespace FinanceHub.Infrastructure.Repositories;

public class MessageRepository(FinHubDbContext context, IMapper mapper) : GenericRepository<Message>(context), IMessageRepository
{
    public async Task<PagedList<MessageDto>> GetMessagesForUser(MessageParams messageParams)
    {
        var query = _dbSet.OrderByDescending(x => x.MessageSent).AsQueryable();

        query = messageParams.Container switch
        {
            "Inbox" => query.Where(x => x.RecipientUserName == messageParams.Username),
            "Outbox" => query.Where(x => x.SenderUserName == messageParams.Username),
            _ => query.Where(x => x.RecipientUserName == messageParams.Username && x.DateRead == null)
        };

        var messages = query.ProjectTo<MessageDto>(mapper.ConfigurationProvider);

        return await PagedList<MessageDto>.CreateAsync(messages, messageParams.PageNumber, messageParams.PageSize);
    }

    public Task<IEnumerable<MessageDto>> GetMessageThread(string currentUsername, string recipientUsername)
    {
        return null;
    }
}