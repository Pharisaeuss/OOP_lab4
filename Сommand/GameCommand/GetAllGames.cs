using System;
using OOP_lab4.Command.Base;
using OOP_lab4.Service.Base;

namespace OOP_lab4.Command.GameCommand
{
    public class GetAllGames : ICommand
    {
        private IGameService _gameService;

        public GetAllGames(IGameService gameService)
        {
            _gameService = gameService;
        }

        public void Execute()
        {
            Console.WriteLine("Список всіх ігор:");

            foreach (var gameEntity in _gameService.GetAllGames())
            {
                Console.WriteLine(
                    $"ID Гри: {gameEntity.Id} | Рейтинг гри: {gameEntity.GameRating} | Тип гри: {gameEntity.GameType} | Результат: {gameEntity.IsWin}");
            }
        }

        public string GetCommandInfo()
        {
            return "Список всіх ігор";
        }
    }
}