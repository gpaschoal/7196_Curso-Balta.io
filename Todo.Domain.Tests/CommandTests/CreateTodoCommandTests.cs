using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;

namespace Todo.Domain.Tests.CommandTests
{
  [TestClass]
  public class CreateTodoCommandTests
  {
    private readonly CreateTodoCommand _invalidCommand;
    private readonly CreateTodoCommand _validCommand;

    public CreateTodoCommandTests()
    {
      _invalidCommand = new CreateTodoCommand("", DateTime.Now, "");
      _invalidCommand.Validate();
      _validCommand = new CreateTodoCommand("Titulo exemplo", DateTime.Now, "Guilherme");
      _validCommand.Validate();
    }

    [TestMethod]
    public void DadoUmCommandInvalido()
    {
      Assert.AreEqual(_invalidCommand.Valid, false);
    }

    [TestMethod]
    public void DadoUmCommandValido()
    {
      Assert.AreEqual(_validCommand.Valid, true);
    }
  }
}
