using IGrove.Domain.Tickets.Dtos;
using IGrove.Domain.Tickets.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IGrove.Domain.Tickets.Repositories
{
    public interface ITicketReadRepository
    {
        Task<IEnumerable<Ticket>> GetAll(CancellationToken cancellationToken);

        Task<Ticket> GetById(Guid id, CancellationToken cancellationToken);
    }

    public interface ITicketWriteRepository
    {
        Task Add(Ticket ticket, CancellationToken cancellationToken);

        Task Update(Ticket ticket, CancellationToken cancellationToken);

        Task Remove(Ticket ticket, CancellationToken cancellationToken);
    }
}
