using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
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
      // Fail Fast Validation
      command.Validate();
      if (command.Invalid)
        return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

      // Salvar um todo no banco
      var todoItem = new TodoItem(command.Title, command.Date, command.User);
      _repository.Create(todoItem);

      //Notificar o usuário
      return new GenericCommandResult(true, "Todo Inserido com sucesso", todoItem);
    }

    public ICommandResult Handlers(UpdateTodoCommand command)
    {
      // Fail Fast Validation
      command.Validate();
      if (command.Invalid)
        return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

      // Salvar um todo no banco
      var todoItem = _repository.GetById(command.Id, command.User);

      // Altera o título
      todoItem.UpdateTitle(command.Title);

      // Salvando no banco
      _repository.Update(todoItem);

      //Notificar o usuário
      return new GenericCommandResult(true, "Tarefa Salva", todoItem);
    }

    public ICommandResult Handlers(MarkTodoAsDoneCommand command)
    {
      // Fail Fast Validation
      command.Validate();
      if (command.Invalid)
        return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

      // Salvar um todo no banco
      var todoItem = _repository.GetById(command.Id, command.User);

      // Altera o estado
      todoItem.MarkAsDone();

      // Salvando no banco
      _repository.Update(todoItem);

      //Notificar o usuário
      return new GenericCommandResult(true, "Tarefa Salva", todoItem);
    }

    public ICommandResult Handlers(MarkTodoAsUndoneCommand command)
    {
      // Fail Fast Validation
      command.Validate();
      if (command.Invalid)
        return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

      // Salvar um todo no banco
      var todoItem = _repository.GetById(command.Id, command.User);

      // Altera o estado
      todoItem.MarkAsUnDone();

      // Salvando no banco
      _repository.Update(todoItem);

      //Notificar o usuário
      return new GenericCommandResult(true, "Tarefa Salva", todoItem);
    }
  }
}