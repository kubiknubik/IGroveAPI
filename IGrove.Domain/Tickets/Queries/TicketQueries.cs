using IGrove.Domain.Tickets.Dtos;
using Shared.Utils.Queries;
using System;
using System.Collections.Generic;

namespace IGrove.Domain.Tickets.Queries
{
    public class GetTicketsQuery : BaseQuery<IEnumerable<TicketDto>>
    {

    }

    public class GetTicketByIdQuery : BaseQuery<TicketDto>
    {
        public Guid Id { get; set; }
    }
}
