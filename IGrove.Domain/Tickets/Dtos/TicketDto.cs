using System;

namespace IGrove.Domain.Tickets.Dtos
{
    public class TicketDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int CompanyId { get; set; }

        public string CompanyName { get; set; }

        public int Count { get; set; }

        public string DueDate { get; set; }

        public string ImageUrl { get; set; }

        public int Version { get; set; }

        public bool IsActive { get; set; }
    }
}