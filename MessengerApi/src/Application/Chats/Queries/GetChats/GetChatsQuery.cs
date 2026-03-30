using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessengerApi.Application.Chats.Dto;
using MessengerApi.Application.Common.Models;

namespace MessengerApi.Application.Chats.Queries.GetChats;
record class GetChatsQuery : IRequest<PaginatedList<ChatDto>>
{
    public Guid UserId { get; set; } = Guid.Empty;
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}
