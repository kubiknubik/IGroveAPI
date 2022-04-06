using MediatR;

namespace Shared.Utils.Queries.Abstract
{
    public interface IQuery<TResponse> : IRequest<TResponse>
    {

    }
}