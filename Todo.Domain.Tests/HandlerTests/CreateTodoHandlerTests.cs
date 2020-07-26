using System;
using Todo.Domain.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Handlers;

namespace Todo.Domain.Tests.HandlerTests
{
  [TestClass]
  public class CreateTodoHandlerTests
  {
    private readonly CreateTodoCommand _invalidCommand;
    private readonly CreateTodoCommand _validCommand;

    public CreateTodoHandlerTests()
    {
      _invalidCommand = new CreateTodoCommand("", DateTime.Now, "");
      _invalidCommand.Validate();
      _validCommand = new CreateTodoCommand("Titulo exemplo", DateTime.Now, "Guilherme");
      _validCommand.Validate();
    }

    [TestMethod]
    public void DadoUmCommandInvalidoDeveInterromperAExecucao()
    {
      var handler = new TodoHandler(null);
      Assert.Fail();
    }

    [TestMethod]
    public void DadoUmCommandValidoDeveCriarATarefa()
    {
      Assert.Fail();
    }
  }
}