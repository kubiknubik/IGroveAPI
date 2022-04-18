using AutoMapper;
using IGrove.Domain.Games.Dtos;
using IGrove.Domain.Games.Entities;
using IGrove.Domain.Players.Dtos;
using IGrove.Domain.Players.Entities;
using IGrove.Domain.Tickets.Dtos;
using IGrove.Domain.Tickets.Entities;
using IGrove.Domain.Users.Dtos;
using IGrove.Domain.Users.Entities;

namespace IGrove.Management.Mapper
{
    public class IGroveMapper : Profile
    {
        public IGroveMapper()
        {
            CreateMap<Player, PlayerDto>();
            CreateMap<Ticket, TicketDto>();
            CreateMap<Game, GameDto>();
            CreateMap<User, UserDto>();
        }
    }
}
