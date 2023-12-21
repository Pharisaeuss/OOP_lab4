using System;
using OOP_lab4.Service.Base;
using OOP_lab4.Command.Base;

namespace OOP_lab4.Command.PlayerCommand
{
    public class PutPlayer : ICommand
    {
        private IPlayerService _playerService;

        public PutPlayer(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public void Execute()
        {
            Console.WriteLine("Введіть ID гравця");
            var playerId = int.Parse(Console.ReadLine() ?? string.Empty);
            var player = _playerService.GetPlayerById(playerId);

            if (player == null)
            {
                Console.WriteLine("Гравець з таким ID не існує");
                return;
            }

            Console.WriteLine("Виберіть, що ви хочете змінити:");
            Console.WriteLine("1. Ім'я");
            Console.WriteLine("2. Рейтинг");
            Console.WriteLine("3. Кількість зіграних ігор");
            var editChoice = GetChoice(1, 3);

            switch (editChoice)
            {
                case 1:
                    Console.WriteLine("Введіть нове Ім'я");
                    var newName = Console.ReadLine();
                    player.UserName = newName;
                    break;
                case 2:
                    Console.WriteLine("Введіть новий рейтинг");
                    var newRating = int.Parse(Console.ReadLine() ?? string.Empty);
                    player.CurrentRating = newRating;
                    break;
                case 3:
                    Console.WriteLine("Введіть нову кількість зіграних ігор");
                    var newGamesCount = int.Parse(Console.ReadLine() ?? string.Empty);
                    player.GamesCount = newGamesCount;
                    break;
            }

            _playerService.UpdatePlayer(player);
            Console.WriteLine("Дані гравця було оновлено успішно");
        }

        public string GetCommandInfo()
        {
            return "Оновити дані гравця";
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
    }
}