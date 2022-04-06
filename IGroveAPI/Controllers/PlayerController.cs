using IGrove.Domain.Players.Dtos;
using IGrove.Domain.Players.Queries;
using IGroveAPI.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Shared.Utils.Commands.Abstract;
using Shared.Utils.Queries.Abstract;
using Shared.Utils.WebAPI.Security;
using System.Threading;
using System.Threading.Tasks;

namespace IGroveAPI.Controllers
{
    public class PlayerController : IGroveBaseController
    {
        public PlayerController(ICommandBus commandBus, IQueryBus queryBus, IJWTHandler jwtHandler) : base(commandBus, queryBus, jwtHandler)
        {

        }

        [HttpGet("getInfo")]
        public async Task<IActionResult> GetInfo(CancellationToken cancellationToken)
        {
            var query = new GetPlayerByIdQuery
            {
                Id = CurrentUser.Id
            };

            var result = await _queryBus.SendAsync<GetPlayerByIdQuery, PlayerDto>(query, cancellationToken);

            return Ok(result);
        }
    }
}
