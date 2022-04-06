using IGrove.Domain.Tickets.Dtos;
using IGrove.Domain.Tickets.Queries;
using IGrove.Domain.Tickets.Repositories;
using Shared.Utils.Queries.Abstract;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IGrove.Management.Tickets.QueryHandlers
{
    public class TicketQueryHandlers : IQueryHandler<GetTicketsQuery, IEnumerable<TicketDto>>,
         IQueryHandler<GetTicketByIdQuery, TicketDto>
    {
        private readonly ITicketReadRepository _ticketReadRepository;

        public TicketQueryHandlers(ITicketReadRepository ticketReadRepository)
        {
            _ticketReadRepository = ticketReadRepository ?? throw new ArgumentNullException(nameof(ticketReadRepository));
        }

        public Task<IEnumerable<TicketDto>> Handle(GetTicketsQuery request, CancellationToken cancellationToken)
        {
            return _ticketReadRepository.GetAll(cancellationToken);
        }

        public Task<TicketDto> Handle(GetTicketByIdQuery request, CancellationToken cancellationToken)
        {
            return _ticketReadRepository.GetById(request.Id, cancellationToken);
        }
    }
}
