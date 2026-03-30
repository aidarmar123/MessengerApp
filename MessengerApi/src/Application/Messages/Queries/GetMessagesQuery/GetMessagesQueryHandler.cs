using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessengerApi.Application.Common.Models;
using MessengerApi.Application.Messages.Dto;

namespace MessengerApi.Application.Messages.Queries.GetMessagesQuery;
public class GetMessagesQueryHandler : IRequestHandler<GetMessagesQuery, PaginatedList<MessageDto>>
{
    public Task<PaginatedList<MessageDto>> Handle(GetMessagesQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
