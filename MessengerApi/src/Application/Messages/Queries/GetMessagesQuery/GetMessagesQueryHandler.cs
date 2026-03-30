using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessengerApi.Application.Common.Interfaces;
using MessengerApi.Application.Common.Mappings;
using MessengerApi.Application.Common.Models;
using MessengerApi.Application.Messages.Dto;
using Microsoft.EntityFrameworkCore;

namespace MessengerApi.Application.Messages.Queries.GetMessagesQuery;
public class GetMessagesQueryHandler : IRequestHandler<GetMessagesQuery, PaginatedList<MessageDto>>
{
    private readonly IApplicationDbContext _context;

    public GetMessagesQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PaginatedList<MessageDto>> Handle(GetMessagesQuery request, CancellationToken cancellationToken)
    {
        return await _context.Messages
         .Where(m => m.ChatId == request.ChatId)
         .OrderByDescending(m => m.SendAt) // Сначала новые
         .Select(m => new MessageDto
         {
             Id = m.Id,
             Content = m.Content,
             SenderName = m.Sender.Displayname,
             SendAt = m.SendAt,
             Attachments = m.Attachments.Select(a => a.FileName).ToList()
         })
         .PaginatedListAsync(request.Offset, request.Limit);
    }
}
