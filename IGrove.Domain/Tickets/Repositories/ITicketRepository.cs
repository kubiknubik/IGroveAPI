using IGrove.Domain.Tickets.Dtos;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IGrove.Domain.Tickets.Repositories
{
    public interface ITicketReadRepository
    {
        Task<IEnumerable<TicketDto>> GetAll(CancellationToken cancellationToken);

        Task<TicketDto> GetById(Guid id, CancellationToken cancellationToken);
    }

    public interface ITicketWriteRepository
    {
        Task Add(TicketDto ticket, CancellationToken cancellationToken);

        Task Update(TicketDto ticket, CancellationToken cancellationToken);

        Task Delete(TicketDto ticket, CancellationToken cancellationToken);
    }
}
