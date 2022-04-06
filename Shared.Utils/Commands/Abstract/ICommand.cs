using MediatR;

namespace Shared.Utils.Commands.Abstract
{
    public interface ICommand<T> : IRequest<T>
    {

    }
}
