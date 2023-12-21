using System.Collections.Generic;
using OOP_lab4.Repository.Base;
using OOP_lab4.Entities;
using OOP_lab4.Service.Base;

namespace OOP_lab4.Service
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public void CreateGame(int gameRating)
        {
            var game = new GameEntity { GameRating = gameRating };
            _gameRepository.Create(game);
        }

        public List<GameEntity> GetAllGames()
        {
            return _gameRepository.ReadAll();
        }

        public GameEntity GetGameById(int gameId)
        {
            return _gameRepository.ReadById(gameId);
        }

        public void UpdateGame(GameEntity game)
        {
            _gameRepository.Update(game);
        }

        public void DeleteGame(int gameId)
        {
            _gameRepository.Delete(gameId);
        }
    }
}