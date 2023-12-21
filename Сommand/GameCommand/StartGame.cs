using System;
using OOP_lab4.Entities;
using OOP_lab4.MainGame;
using OOP_lab4.MainGame.GameType;
using OOP_lab4.Service.Base;
using OOP_lab4.Command.Base;
using OOP_lab4.MainGame.GameBase;

namespace OOP_lab4.Command.GameCommand
{
    public class StartGame : ICommand
    {
        private IPlayerService _playerService;
        private IGameService _gameService;
        private GameFactory _gameFactory;

        public StartGame(IPlayerService playerService, IGameService gameService, GameFactory gameFactory)
        {
            _playerService = playerService;
            _gameService = gameService;
            _gameFactory = gameFactory;
        }

        public void Execute()
        {
            Console.WriteLine("Введіть ID першого гравця");
            var player1Id = int.Parse(Console.ReadLine() ?? string.Empty);
            var player1 = _playerService.GetPlayerById(player1Id);

            Console.WriteLine("Введіть ID другого гравця");
            var player2Id = int.Parse(Console.ReadLine() ?? string.Empty);
            var player2 = _playerService.GetPlayerById(player2Id);

            Console.WriteLine("Виберіть тип акаунту гравця:");
            Console.WriteLine("1. Стандартний");
            Console.WriteLine("2. Менша втрата рейтингу");
            Console.WriteLine("3. Серія перемог");
            var accountTypeChoice = GetChoice(1, 3);

            Console.WriteLine("Виберіть тип гри:");
            Console.WriteLine("1. Стандартна гра");
            Console.WriteLine("2. Тренувальна гра");
            Console.WriteLine("3. Однокористувацька гра");
            var gameTypeChoice = GetChoice(1, 3);

            var player1Account = CreatePlayer(_gameFactory, accountTypeChoice, player1.UserName, player1.CurrentRating);
            var player2Account = CreatePlayer(_gameFactory, accountTypeChoice, player2.UserName, player2.CurrentRating);

            Console.WriteLine("\nGame MainGame...");

            var gameRating = new Random().Next(1, 255);
            var game = CreateGame(gameTypeChoice, gameRating);

            player1Account.WinGame(player2Account, game.GetGameRating());
            player2Account.LoseGame(player1Account, game.GetGameRating());

            player1.CurrentRating = player1Account.CurrentRating;
            player1.GamesCount = player1Account.GamesCount;
            _playerService.UpdatePlayer(player1);

            player2.CurrentRating = player2Account.CurrentRating;
            player2.GamesCount = player2Account.GamesCount;
            _playerService.UpdatePlayer(player2);

            var gameEntity = new GameEntity
                {
                    GameRating = gameRating, PlayerId = player1Id, GameType = game.GetGameType(),
                    AccountType = player1Account.GetAccountType()
                };
            _gameService.CreateGame(gameEntity.GameRating);

            Console.WriteLine("\nСтатистика Гравця");
            Console.WriteLine();
            player1Account.GetStats();
            Console.WriteLine();
            player2Account.GetStats();

        }

        private int GetChoice(int minValue, int maxValue)
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

        public GameAccount CreatePlayer(GameFactory factory, int accountTypeChoice, string userName,
            int initialRating)
        {
            switch (accountTypeChoice)
            {
                case 1:
                    return GameFactory.CreateBasicAccountType(userName, initialRating);
                case 2:
                    return GameFactory.CreateHalfLossAccountType(userName, initialRating);
                case 3:
                    return GameFactory.CreateWinningStreakAccountType(userName, initialRating);
                default:
                    throw new ArgumentException("Неправильний тип акаунту");
            }
        }

        private Game CreateGame(int gameTypeChoice, int rating)
        {
            switch (gameTypeChoice)
            {
                case 1:
                    return new StandardGame(rating);
                case 2:
                    return new TrainingGame();
                case 3:
                    return new SoloGame(rating);
                default:
                    throw new ArgumentException("Неправильний тип гри");
            }
        }

        public string GetCommandInfo()
        {
            return "Почати нову гру";
        }
    }
}