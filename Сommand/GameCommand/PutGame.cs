using System;
using OOP_lab4.Service.Base;
using OOP_lab4.Command.Base;

namespace OOP_lab4.Command.GameCommand
{
    public class PutGame : ICommand
    {
        private IGameService _gameService;

        public PutGame(IGameService gameService)
        {
            _gameService = gameService;
        }

        public void Execute()
        {
            Console.WriteLine("Введіть ID гри");
            var gameId = int.Parse(Console.ReadLine());
            var selectedGame = _gameService.GetGameById(gameId);

            if (selectedGame == null)
            {
                Console.WriteLine("Гра з таким ID не існує");
                return;
            }

            Console.WriteLine("Виберіть, що ви хочете змінити:");
            Console.WriteLine("1. Рейтинг гри");
            Console.WriteLine("2. ID гравця");

            var PutChoice = GetChoice(1, 2);

            switch (PutChoice)
            {
                case 1:
                    Console.WriteLine("Введіть новий рейтинг гри");
                    var newRating = int.Parse(Console.ReadLine());
                    selectedGame.GameRating = newRating;
                    break;
                case 2:
                    Console.WriteLine("Введіть новий ID гравця");
                    var newPlayerId = int.Parse(Console.ReadLine());
                    selectedGame.PlayerId = newPlayerId;
                    break;
            }

            _gameService.UpdateGame(selectedGame);
            Console.WriteLine("Дані гри було оновлено");
            return;
        }

        private static int GetChoice(int minValue, int maxValue)
        {
            int choice;
            while (true)
            {
                Console.Write($"Введіть число від {minValue} до {maxValue}: ");
                if (int.TryParse(Console.ReadLine(), out choice) && choice >= minValue && choice <= maxValue)
                {
                    break;
                }

                Console.WriteLine("Спробуйте знову");
            }

            return choice;
        }

        public string GetCommandInfo()
        {
            return "Оновити дані гри";
        }
    }
}