using System.Collections.Generic;
using OOP_lab4.Entities;

namespace OOP_lab4.Service.Base
{
    public interface IGameService
    {
        void CreateGame(int gameRating);
        List<GameEntity> GetAllGames();
        GameEntity GetGameById(int gameId);
        void UpdateGame(GameEntity game);
        void DeleteGame(int gameId);
    }
}