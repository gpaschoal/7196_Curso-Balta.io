using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
  public class TodoHandler :
      Notifiable,
      IHandler<CreateTodoCommand>,
      IHandler<UpdateTodoCommand>,
      IHandler<MarkTodoAsDoneCommand>,
      IHandler<MarkTodoAsUndoneCommand>
  {
    private readonly ITodoRepository _repository;

    public TodoHandler(ITodoRepository repository)
    {
      _repository = repository;
    }

    public ICommandResult Handlers(CreateTodoCommand command)
    {
      throw new System.NotImplementedException();
    }

    public ICommandResult Handlers(UpdateTodoCommand command)
    {
      throw new System.NotImplementedException();
    }

    public ICommandResult Handlers(MarkTodoAsDoneCommand command)
    {
      throw new System.NotImplementedException();
    }

    public ICommandResult Handlers(MarkTodoAsUndoneCommand command)
    {
      throw new System.NotImplementedException();
    }
  }
}