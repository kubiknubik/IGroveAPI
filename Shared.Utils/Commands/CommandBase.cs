using MediatR;
using Shared.Utils.Commands.Abstract;

namespace Shared.Utils.Commands
{
    public class CommandBase<T> : ICommand<T>
    {

    }

    public class CommandBase : CommandBase<Unit>
    {

    }
}
