using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Domain.Queries;
using Todo.Domain.Entities;

namespace Todo.Domain.Tests.QueryTests
{
  [TestClass]
  public class TodoQueryTests
  {
    private List<TodoItem> _items;
    public TodoQueryTests()
    {
      _items = new List<TodoItem>
      {
          new TodoItem("Tarefa 01", DateTime.Now.Date, "gui"),
          new TodoItem("Tarefa 02", DateTime.Now.Date, "derydfg"),
          new TodoItem("Tarefa 03", DateTime.Now.Date, "gui"),
          new TodoItem("Tarefa 04", DateTime.Now.Date, "35ret"),
          new TodoItem("Tarefa 05", DateTime.Now.Date, "gui"),
      };
    }

    [TestMethod]
    public void DadaAConsultaDeveRetornarTarefasApenasDoUsuario()
    {
      var result = _items.AsQueryable().Where(TodoQueries.GetAll("gui"));
      Assert.AreEqual(3, result.Count());
    }
  }
}