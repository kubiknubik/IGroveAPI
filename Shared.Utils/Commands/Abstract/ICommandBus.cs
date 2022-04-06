using System.Threading;
using System.Threading.Tasks;

namespace Shared.Utils.Commands.Abstract
{
    public interface ICommandBus
    {
        Task<T> Send<T>(ICommand<T> command, CancellationToken cancellationToken);

        Task<T> SendAsync<T>(ICommand<T> command, CancellationToken cancellationToken);
    }
}
