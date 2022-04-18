using AutoMapper;
using IGrove.Domain.Users.Dtos;
using IGrove.Domain.Users.Queries;
using IGrove.Domain.Users.Repositories;
using Shared.Utils.Exceptions;
using Shared.Utils.Extensions;
using Shared.Utils.Queries.Abstract;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IGrove.Management.Users.QueryHandlers
{
    public class UserQueryHandler : IQueryHandler<GetUserAuthenticationQuery, UserDto>
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly IMapper _mapper;

        public UserQueryHandler(IUserReadRepository userReadRepository, IMapper mapper)
        {
            _userReadRepository = userReadRepository ?? throw new ArgumentNullException(nameof(userReadRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<UserDto> Handle(GetUserAuthenticationQuery request, CancellationToken cancellationToken)
        {
            var username = request.Username.ToLower();
            var result = await _userReadRepository.GetByName(username, cancellationToken);

            if (result == null || result.Passord != request.Password.HashPassword(username))
            {
                throw new BusinessRuleValidationException(InternalExceptionCode.IncorrectUsernameOrPassword);
            }

            return _mapper.Map<UserDto>(result);
        }
    }
}
