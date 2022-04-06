using MediatR;
using Shared.Utils.Commands.Abstract;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Shared.Utils.Commands
{
    public class CommandBus : ICommandBus
    {
        private readonly IMediator _mediatR;

        public CommandBus(IMediator mediatR)
        {
            _mediatR = mediatR ?? throw new ArgumentNullException(nameof(mediatR));
        }

        public Task<T> Send<T>(ICommand<T> command, CancellationToken cancellationToken)
        {
            return _mediatR.Send(command, cancellationToken);
        }

        public async Task<T> SendAsync<T>(ICommand<T> command, CancellationToken cancellationToken)
        {
            return await Send(command, cancellationToken);
        }
    }
}