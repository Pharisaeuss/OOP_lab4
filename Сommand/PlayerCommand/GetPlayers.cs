using System;
using OOP_lab4.Service.Base;
using OOP_lab4.Command.Base;

namespace OOP_lab4.Command.PlayerCommand
{
    public class GetPlayers : ICommand
    {
        private IPlayerService _playerService;

        public GetPlayers(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public void Execute()
        {
            foreach (var player in _playerService.GetAllPlayers())
            {
                Console.WriteLine($"ID гравця: {player.Id} | Ім'я: {player.UserName} | Рейтинг: {player.CurrentRating} | Кількість зіграних ігор: {player.GamesCount}");
            }
        }

        public string GetCommandInfo()
        {
            return "Список всіх гравців";
        }
    }
}