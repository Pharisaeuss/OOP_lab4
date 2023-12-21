using System;
using OOP_lab4.Repository;
using OOP_lab4.MainGame.GameBase;
using OOP_lab4.Command;
using OOP_lab4.Command.PlayerCommand;
using OOP_lab4.Command.GameCommand;
using OOP_lab4.Service.Base;
using OOP_lab4.Service;

namespace OOP_lab4.MainGame
{
    public abstract class MainGame
    {
        private static DbContext.DbContext _dbContext = new DbContext.DbContext();
        private static PlayerRepository _playerRepository = new PlayerRepository(_dbContext);
        private static GameRepository _gameRepository = new GameRepository(_dbContext);
        private static GameFactory _gameFactory = new GameFactory();
        private static CommandManager _commandManager = new CommandManager();

        private static void Start()
        {
            while (true)
            {
                Console.WriteLine("Гра:");
                _commandManager.GetCommands();

                var startChoice = GetChoice(1, _commandManager.Commands.Count);
                _commandManager.ExecuteCommand(startChoice - 1);
            }
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

                Console.WriteLine("Неправильній ввід, спробуйте знову");
            }

            return choice;
        }

        private static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            IPlayerService playerService = new PlayerService(_playerRepository);
            IGameService gameService = new GameService(_gameRepository);

            _commandManager.AddCommand(new CreatePlayer(playerService));
            _commandManager.AddCommand(new GetPlayers(playerService));
            _commandManager.AddCommand(new DeletePlayer(playerService));
            _commandManager.AddCommand(new PutPlayer(playerService));
            _commandManager.AddCommand(new GetPlayersGamesByID(playerService, gameService));
            _commandManager.AddCommand(new GetAllGames(gameService));
            _commandManager.AddCommand(new PutGame(gameService));
            _commandManager.AddCommand(new DeleteGame(gameService));
            _commandManager.AddCommand(new StartGame(playerService, gameService, _gameFactory));

            Start();
        }
    }
}