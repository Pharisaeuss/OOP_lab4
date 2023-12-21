using OOP_lab4.MainGame.GameBase;
namespace OOP_lab4.MainGame.GameType
{
    public class SoloGame : Game
    {
        private int _playerRating;

        public SoloGame(int playerRating)
        {
            this._playerRating = playerRating;
        }

        public override int GetGameRating()
        {
            return _playerRating;
        }
        public override string GetGameType()
        {
            return "Solo game";
        }
    }
}