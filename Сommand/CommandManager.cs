using System;
using System.Collections.Generic;
using OOP_lab4.Command.Base;

namespace OOP_lab4.Command
{
    public class CommandManager
    {
        public void AddCommand(ICommand command)
        {
            Commands.Add(command);
        }

        public void GetCommands()
        {
            for (var i = 0; i < Commands.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Commands[i].GetCommandInfo()}");
            }
        }

        public void ExecuteCommand(int index)
        {
            if (index >= 0 && index < Commands.Count)
            {
                Commands[index].Execute();
            }
            else
            {
                Console.WriteLine("Неправильна команда");
            }
        }

        public List<ICommand> Commands { get; } = new List<ICommand>();
    }
}