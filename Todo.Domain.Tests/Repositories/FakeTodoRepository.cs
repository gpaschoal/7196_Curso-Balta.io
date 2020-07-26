using System;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Tests.Repositories
{
  public class FakeTodoRepository : ITodoRepository
  {
    public void Create(TodoItem todo) { }

    public TodoItem GetById(Guid id, string user)
    {
      throw new NotImplementedException();
    }

    public void Update(TodoItem todo) { }
  }
}