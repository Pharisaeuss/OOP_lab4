using System.Collections.Generic;
using OOP_lab4.Entities;

namespace OOP_lab4.Service.Base
{
    public interface IPlayerService
    {
        void CreatePlayer(string userName, int initialRating);
        List<PlayerEntity> GetAllPlayers();
        PlayerEntity GetPlayerById(int playerId);
        void UpdatePlayer(PlayerEntity player);
        void DeletePlayer(int playerId);
    }
}