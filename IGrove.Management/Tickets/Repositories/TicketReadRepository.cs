using IGrove.Domain.Tickets.Entities;
using IGrove.Domain.Tickets.Repositories;
using Shared.Utils.Repositories;
using System;

namespace IGrove.Management.Tickets.Repositories
{
    public class TicketRepository : BaseListRepository<Ticket, Guid>, ITicketReadRepository, ITicketWriteRepository
    {
        public TicketRepository()
        {
            _data.Add(new Ticket
            {
                Id = Guid.NewGuid(),
                CompanyId = 1,
                CompanyName = "Glovo",
                Count = 1,
                Description = "Macdonalds-is sabavshvo menius vaucheri",
                Name = "Combo menu",
                DueDate = DateTime.Now.AddDays(10),
                CoverUrl = "ticket_image.png",
                IsActive = true,
                Version = 1
            });
        }
    }
}
