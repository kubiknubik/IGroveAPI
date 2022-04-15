using IGrove.Domain.Tickets.Dtos;
using Shared.Utils.Queries;
using System;
using System.Collections.Generic;

namespace IGrove.Domain.Tickets.Queries
{
    public class GetTicketsQuery : QueryBase<IEnumerable<TicketDto>>
    {

    }

    public class GetTicketByIdQuery : QueryBase<TicketDto>
    {
        public Guid Id { get; set; }
    }
}
