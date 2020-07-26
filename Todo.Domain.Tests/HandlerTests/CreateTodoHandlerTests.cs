using System;
using Todo.Domain.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests.HandlerTests
{
  [TestClass]
  public class CreateTodoHandlerTests
  {
    private readonly CreateTodoCommand _invalidCommand;
    private readonly CreateTodoCommand _validCommand;
    private readonly TodoHandler _handler;
    private GenericCommandResult _result;

    public CreateTodoHandlerTests()
    {
      _invalidCommand = new CreateTodoCommand("", DateTime.Now, "");
      _validCommand = new CreateTodoCommand("Titulo exemplo", DateTime.Now, "Guilherme");
      _handler = new TodoHandler(new FakeTodoRepository());
    }

    [TestMethod]
    public void DadoUmCommandInvalidoDeveInterromperAExecucao()
    {
      _result = (GenericCommandResult)_handler.Handlers(_invalidCommand);
      Assert.AreEqual(_result.Sucess, false);
    }

    [TestMethod]
    public void DadoUmCommandValidoDeveCriarATarefa()
    {
      _result = (GenericCommandResult)_handler.Handlers(_validCommand);
      Assert.AreEqual(_result.Sucess, true);
    }
  }
}