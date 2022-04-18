using IGrove.Domain.Users.Queries;
using IGroveAPI.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Utils.Commands.Abstract;
using Shared.Utils.Queries.Abstract;
using Shared.Utils.WebAPI.Security;
using System.Threading;
using System.Threading.Tasks;

namespace IGroveAPI.Controllers
{
    public class AuthorizeController : IGroveBaseController
    {
        public AuthorizeController(ICommandBus commandBus, IQueryBus queryBus, IJWTHandler jwtHandler) : base(commandBus, queryBus, jwtHandler)
        {

        }

        [AllowAnonymous]
        [HttpPost("auth")]
        public async Task<IActionResult> Authorize(GetUserAuthenticationQuery query,CancellationToken cancellationToken)
        {
            var result = await _queryBus.SendAsync(query, cancellationToken);

            var token = GenerateToken(result);

            return Ok(new { token, result });
        }
    }
}
