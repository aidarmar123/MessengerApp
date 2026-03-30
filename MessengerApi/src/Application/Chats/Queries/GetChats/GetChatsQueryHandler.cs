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
    private readonly IUser _user;

    public GetChatsQueryHandler(IApplicationDbContext context, IUser user)
    {
        _context = context;
        _user = user;
    }

    public async Task<PaginatedList<ChatDto>> Handle(GetChatsQuery request, CancellationToken cancellationToken)
    {
        var currentUserId = Guid.Parse(_user.Id!);
        return await _context.ChatMembers
         .Where(cm => cm.UserId == currentUserId)
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
