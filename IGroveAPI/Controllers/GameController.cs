using IGrove.Domain.Games.Commands;
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

        [HttpPost("add")]
        public async Task<IActionResult> Add(AddGameCommand command, CancellationToken cancellationToken)
        {
            await _commandBus.SendAsync(command, cancellationToken);

            return Ok();
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete(DeleteGameCommand command, CancellationToken cancellationToken)
        {
            await _commandBus.SendAsync(command, cancellationToken);

            return Ok();
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(UpdateGameCommand command, CancellationToken cancellationToken)
        {
            await _commandBus.SendAsync(command, cancellationToken);

            return Ok();
        }
    }
}
