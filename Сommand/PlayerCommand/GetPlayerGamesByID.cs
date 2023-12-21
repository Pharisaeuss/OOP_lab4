using System;
using System.Linq;
using OOP_lab4.Service.Base;
using OOP_lab4.Command.Base;

namespace OOP_lab4.Command.PlayerCommand
{
    public class GetPlayersGamesByID : ICommand
    {
        private IPlayerService _playerService;
        private IGameService _gameService;

        public GetPlayersGamesByID(IPlayerService playerService, IGameService gameService)
        {
            _playerService = playerService;
            _gameService = gameService;
        }

        public void Execute()
        {
            Console.WriteLine("Введіть ID гравця");
            var playerId = int.Parse(Console.ReadLine() ?? string.Empty);
            var selectedPlayer = _playerService.GetPlayerById(playerId);

            if (selectedPlayer == null)
            {
                Console.WriteLine("Гравець з таким ID не існує");
                return;
            }

            Console.WriteLine($"Список ігор гравця {selectedPlayer.UserName}:");

            var games = _gameService.GetAllGames().Where(game => game.PlayerId == playerId);
            foreach (var game in games)
            {
                Console.WriteLine(
                    $"ID Гри: {game.Id} | Рейтинг гри: {game.GameRating} | Тип гри: {game.GameType} | Тип гравця: {game.AccountType} | Результат: {game.IsWin}");
            }
        }

        public string GetCommandInfo()
        {
            return "Список ігор гравця";
        }
    }
}