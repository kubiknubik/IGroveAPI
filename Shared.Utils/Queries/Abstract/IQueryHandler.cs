using MediatR;

namespace Shared.Utils.Queries.Abstract
{
    public interface IQueryHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IQuery<TResponse>
    {

    }
}