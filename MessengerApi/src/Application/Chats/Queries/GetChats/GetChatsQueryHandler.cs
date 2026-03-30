using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessengerApi.Application.Chats.Dto;
using MessengerApi.Application.Common.Interfaces;
using MessengerApi.Application.Common.Mappings;
using MessengerApi.Application.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace MessengerApi.Application.Chats.Queries.GetChats;
public class GetChatsQueryHandler : IRequestHandler<GetChatsQuery, PaginatedList<ChatDto>>
{
    private readonly IApplicationDbContext _context;

    public GetChatsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PaginatedList<ChatDto>> Handle(GetChatsQuery request, CancellationToken cancellationToken)
    {
        return await _context.ChatMembers
        .Where(cm => cm.UserId == request.UserId)
        .Select(cm => new ChatDto
        {
            Id = cm.ChatId,
            Title = cm.Chat.Title,
            Type = cm.Chat.Type,
            LastMessageContent = cm.Chat.Messages
                .OrderByDescending(m => m.SendAt)
                .Select(m => m.Content)
                .FirstOrDefault(),
            LastMessageAt = cm.Chat.Messages
                .OrderByDescending(m => m.SendAt)
                .Select(m => m.SendAt)
                .FirstOrDefault()
            // UnreadCount можно добавить позже через агрегацию
        })
        .OrderByDescending(c => c.LastMessageAt)
        .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
