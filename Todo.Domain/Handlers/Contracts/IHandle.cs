using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Handlers.Contracts
{
  public interface IHandle<T> where T : ICommand
  {
    ICommandResult Handlers(T command);
  }
}