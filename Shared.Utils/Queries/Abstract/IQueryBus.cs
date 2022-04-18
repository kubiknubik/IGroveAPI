using System.Threading;
using System.Threading.Tasks;

namespace Shared.Utils.Queries.Abstract
{
    public interface IQueryBus
    {
        Task<TResponse> SendAsync<TResponse>(IQuery<TResponse> request, CancellationToken cancellationToken);
      
        Task<TResponse> Send<TResponse>(IQuery<TResponse> request, CancellationToken cancellationToken);
    }
}
