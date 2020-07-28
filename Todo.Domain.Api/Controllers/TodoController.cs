using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;

namespace Todo.Domain.Api.Controllers
{
  [ApiController]
  [Route("v1/todos")]
  public class TodoController : ControllerBase
  {
    [Route("")]
    [HttpGet]
    public IEnumerable<TodoItem> GetAll(
      [FromServices] ITodoRepository repository
    )
    {
      return repository.GetAll("gui");
    }

    [Route("done")]
    [HttpGet]
    public IEnumerable<TodoItem> GetAllDone(
      [FromServices] ITodoRepository repository
    )
    {
      return repository.GetAllDone("gui");
    }

    [Route("undone")]
    [HttpGet]
    public IEnumerable<TodoItem> GetAllUndone(
      [FromServices] ITodoRepository repository
    )
    {
      return repository.GetAllUndone("gui");
    }

    [Route("done/today")]
    [HttpGet]
    public IEnumerable<TodoItem> GetAllDoneForToday(
      [FromServices] ITodoRepository repository
    )
    {
      return repository.GetByPeriod("gui", DateTime.Now.Date, true);
    }

    [Route("undone/today")]
    [HttpGet]
    public IEnumerable<TodoItem> GetAllUndoneForToday(
      [FromServices] ITodoRepository repository
    )
    {
      return repository.GetByPeriod("gui", DateTime.Now.Date, false);
    }

    [Route("done/tomorrow")]
    [HttpGet]
    public IEnumerable<TodoItem> GetAllDoneForTomorrow(
      [FromServices] ITodoRepository repository
    )
    {
      return repository.GetByPeriod("gui", DateTime.Now.Date.AddDays(1), true);
    }

    [Route("undone/tomorrow")]
    [HttpGet]
    public IEnumerable<TodoItem> GetAllUndoneForTomorrow(
      [FromServices] ITodoRepository repository
    )
    {
      return repository.GetByPeriod("gui", DateTime.Now.Date.AddDays(1), false);
    }

    [Route("")]
    [HttpPost]
    public GenericCommandResult Create(
        [FromBody] CreateTodoCommand command,
        [FromServices] TodoHandler handler
    )
    {
      command.User = "Gui";
      return (GenericCommandResult)handler.Handlers(command);
    }

    [Route("")]
    [HttpPut]
    public GenericCommandResult Update(
        [FromBody] UpdateTodoCommand command,
        [FromServices] TodoHandler handler
    )
    {
      command.User = "Gui";
      return (GenericCommandResult)handler.Handlers(command);
    }

    [Route("mark-as-done")]
    [HttpPut]
    public GenericCommandResult MarkAsDone(
        [FromBody] MarkTodoAsDoneCommand command,
        [FromServices] TodoHandler handler
    )
    {
      command.User = "Gui";
      return (GenericCommandResult)handler.Handlers(command);
    }

    [Route("mark-as-undone")]
    [HttpPut]
    public GenericCommandResult MarkAsUnDone(
        [FromBody] MarkTodoAsUndoneCommand command,
        [FromServices] TodoHandler handler
    )
    {
      command.User = "Gui";
      return (GenericCommandResult)handler.Handlers(command);
    }
  }
}