using System.Collections.Generic;
using OOP_lab4.Entities;


namespace OOP_lab4.Repository.Base
{
    public interface IGameRepository
    {
        void Create(GameEntity game);
        List<GameEntity> ReadAll();
        GameEntity ReadById(int gameId);
        void Update(GameEntity game);
        void Delete(int gameId);
    }
}