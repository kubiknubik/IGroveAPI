using IGroveAPI.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Shared.Utils.Commands.Abstract;
using Shared.Utils.Queries.Abstract;
using Shared.Utils.WebAPI.Security;
using System.Threading.Tasks;

namespace IGroveAPI.Controllers
{
    public class GameController : IGroveBaseController
    {
        public GameController(ICommandBus commandBus, IQueryBus queryBus, IJWTHandler jwtHandler) : base(commandBus, queryBus, jwtHandler)
        {

        }
    }
}
