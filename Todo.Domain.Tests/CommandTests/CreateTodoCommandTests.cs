using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;

namespace Todo.Domain.Tests.CommandTests
{
  [TestClass]
  public class CreateTodoCommandTests
  {
    [TestMethod]
    public void DadoUmCommandInvalido()
    {
      var command = new CreateTodoCommand("", DateTime.Now, "");
      command.Validate();
      Assert.AreEqual(command.Valid, false);
    }

    [TestMethod]
    public void DadoUmCommandValido()
    {
      var command = new CreateTodoCommand("Titulo exemplo", DateTime.Now, "Guilherme");
      command.Validate();
      Assert.AreEqual(command.Valid, true);
    }
  }
}
