using System;
using OOP_lab4.Entities;
using OOP_lab4.Service.Base;
using OOP_lab4.Command.Base;

namespace OOP_lab4.Command.PlayerCommand
{
    public class CreatePlayer : ICommand
    {
        private IPlayerService _playerService;

        public CreatePlayer(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public void Execute()
        {
            var newPlayer = new PlayerEntity();
            _playerService.CreatePlayer(newPlayer.UserName, newPlayer.CurrentRating);

            Console.WriteLine($"Гравець створений");
        }

        public string GetCommandInfo()
        {
            return "Створити гравця";
        }
    }
}