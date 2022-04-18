using IGrove.Domain.Tickets.Entities;
using Shared.Utils.Queries;
using System;
using System.Collections.Generic;

namespace IGrove.Domain.Tickets.Queries
{
    public class GetTicketsQuery : QueryBase<IEnumerable<Ticket>>
    {

    }

    public class GetTicketByIdQuery : QueryBase<Ticket>
    {
        public Guid Id { get; set; }
    }
}
