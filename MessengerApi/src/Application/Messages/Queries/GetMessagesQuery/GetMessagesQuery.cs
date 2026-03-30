using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessengerApi.Application.Common.Models;
using MessengerApi.Application.Messages.Dto;

namespace MessengerApi.Application.Messages.Queries.GetMessagesQuery;
public record class GetMessagesQuery : IRequest<PaginatedList<MessageDto>>
{
    public Guid ChatId { get; set; }
    public int Offset { get; set; } = 0;
    public int Limit { get; set; } = 50;
}
