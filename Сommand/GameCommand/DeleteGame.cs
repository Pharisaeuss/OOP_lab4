using System;
using OOP_lab4.Service.Base;
using OOP_lab4.Command.Base;

namespace OOP_lab4.Command.GameCommand
{
    public class DeleteGame : ICommand
    {
        private IGameService _gameService;

        public DeleteGame(IGameService gameService)
        {
            _gameService = gameService;
        }

        public void Execute()
        {
            Console.WriteLine("Введіть ID гри");
            var gameId = int.Parse(Console.ReadLine());
            _gameService.DeleteGame(gameId);
            Console.WriteLine("Гру було видалено");
        }

        public string GetCommandInfo()
        {
            return "Видалення гри";
        }
    }
}