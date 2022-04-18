using IGrove.Domain.Games.Queries;
using IGroveAPI.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Shared.Utils.Commands.Abstract;
using Shared.Utils.Queries.Abstract;
using Shared.Utils.WebAPI.Security;
using System.Threading;
using System.Threading.Tasks;

namespace IGroveAPI.Controllers
{
    public class GameController : IGroveBaseController
    {
        public GameController(ICommandBus commandBus, IQueryBus queryBus, IJWTHandler jwtHandler) : base(commandBus, queryBus, jwtHandler)
        {

        }

        [HttpGet("get")]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            var query = new GetGameByIdQuery()
            {
                Id = id
            };

            var result = await _queryBus.SendAsync(query, cancellationToken);

            return Ok(result);
        }

        
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var query = new GetAllGameQuery();    

            var result = await _queryBus.SendAsync(query, cancellationToken);

            return Ok(result);
        }
    }
}
