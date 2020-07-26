using System;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
  public class CreateTodoCommand : ICommand
  {
    public CreateTodoCommand() { }
    public CreateTodoCommand(string title, DateTime date, string user)
    {
      this.Title = title;
      this.Date = date;
      this.User = user;
    }
    public string Title { get; set; }
    public DateTime Date { get; set; }
    public string User { get; set; }

    public void Validate()
    {
      if (Title.Length < 4)
        throw new Exception("Titulo inválido");

      if (User.Length < 4)
        throw new Exception("Usuário inválido");
    }
  }
}