using System.Threading;
using System.Threading.Tasks;

namespace Shared.Utils.Queries.Abstract
{
    public interface IQueryBus
    {
        Task<TResponse> SendAsync<IQuery, TResponse>(IQuery<TResponse> request, CancellationToken cancellationToken);
      
        Task<TResponse> Send<IQuery, TResponse>(IQuery<TResponse> request, CancellationToken cancellationToken);
    }
}
