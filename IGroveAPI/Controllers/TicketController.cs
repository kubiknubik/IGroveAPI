using IGrove.Domain.Tickets.Dtos;
using IGrove.Domain.Tickets.Queries;
using IGroveAPI.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Shared.Utils.Commands.Abstract;
using Shared.Utils.Queries.Abstract;
using Shared.Utils.WebAPI.Security;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IGroveAPI.Controllers
{
    public class TicketController : IGroveBaseController
    {
        public TicketController(ICommandBus commandBus, IQueryBus queryBus, IJWTHandler jwtHandler) : base(commandBus, queryBus, jwtHandler)
        {

        }

        [HttpGet("get")]
        public async Task<IActionResult> Get(Guid guid, CancellationToken cancellationToken)
        {
            var query = new GetTicketByIdQuery
            {
                Id = guid
            };

            var result = await _queryBus.SendAsync<GetTicketByIdQuery, TicketDto>(query, cancellationToken);

            return Ok(result);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var query = new GetTicketsQuery();

            var result = await _queryBus.SendAsync<GetTicketsQuery, IEnumerable<TicketDto>>(query, cancellationToken);

            return Ok(result);
        }
    }
}