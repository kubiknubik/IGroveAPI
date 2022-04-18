using IGrove.Domain.Users.Dtos;
using IGrove.Domain.Users.Entities;
using IGroveAPI.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Utils.Commands.Abstract;
using Shared.Utils.Queries.Abstract;
using Shared.Utils.WebAPI.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace IGroveAPI.Controllers.Base
{
    [ApiController]
    [Route("[controller]")]
    public class IGroveBaseController : ControllerBase
    {
        protected readonly ICommandBus _commandBus;
        protected readonly IQueryBus _queryBus;
        protected readonly IJWTHandler _jwtHandler;

        protected ActiveUser CurrentUser => GetActiveUser();

        public IGroveBaseController(ICommandBus commandBus, IQueryBus queryBus, IJWTHandler jwtHandler)
        {
            _commandBus = commandBus ?? throw new ArgumentNullException(nameof(commandBus));
            _queryBus = queryBus ?? throw new ArgumentNullException(nameof(queryBus));
            _jwtHandler = jwtHandler ?? throw new ArgumentNullException(nameof(jwtHandler));
        }

        private ActiveUser GetActiveUser()
        {
            var claims = Request.HttpContext.User.Claims.ToList();

            int.TryParse(claims.FirstOrDefault(e => e.Type == CustomClaims.Id).Value, out var id);
            var username = claims.FirstOrDefault(e => e.Type == CustomClaims.Username).Value;
            var firstname = claims.FirstOrDefault(e => e.Type == CustomClaims.FirstName).Value;
            var lastname = claims.FirstOrDefault(e => e.Type == CustomClaims.LastName).Value;

            return new ActiveUser()
            {
                Id = id,
                Username = username,
                FirstName = firstname,
                LastName = lastname
            };
        }

        protected string GenerateToken(UserDto user,string role ="User")
        {
            var claims = new List<Claim>() {
            new Claim(CustomClaims.Id,$"{user.Id}"),
            new Claim(CustomClaims.Username,user.Username),
            new Claim(CustomClaims.FirstName,user.FirstName),
            new Claim(CustomClaims.LastName,user.LastName),
            new Claim(ClaimTypes.Role,role)
          };

            return _jwtHandler.Create(claims);
        }
    }
}