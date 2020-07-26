using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;

namespace Todo.Domain.Tests.EntityTests
{
  [TestClass]
  public class TodoItemTests
  {
    private readonly TodoItem _validTodo;

    public TodoItemTests()
    {
      _validTodo = new TodoItem("Titulo aqui", DateTime.Now, "guipaschoal");
    }

    [TestMethod]
    public void DadoUmNovoTodoOMesmoNaoPodeSerConcluido()
    {
      Assert.AreEqual(_validTodo.Done, false);
    }
  }
}