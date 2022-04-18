using MediatR;
using Shared.Utils.Queries.Abstract;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Shared.Utils.Queries
{
    public class QueryBus : IQueryBus
    {
        private readonly IMediator _mediatR;

        public QueryBus(IMediator mediatR)
        {
            _mediatR = mediatR ?? throw new ArgumentNullException(nameof(mediatR));
        }

        public async Task<TResponse> SendAsync<TResponse>(IQuery<TResponse> request, CancellationToken cancellationToken)
        {
            return await Send<TResponse>(request, cancellationToken);
        }

        public Task<TResponse> Send<TResponse>(IQuery<TResponse> request, CancellationToken cancellationToken)
        {
            return  _mediatR.Send(request, cancellationToken);
        }
    }
}