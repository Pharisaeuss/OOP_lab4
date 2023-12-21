using OOP_lab4.MainGame.GameBase;
namespace OOP_lab4.MainGame.GameType
{
    public class StandardGame : Game
    {
        private int _gameRating;

        public StandardGame(int rating)
        {
            _gameRating = rating;
        }

        public override int GetGameRating()
        {
            return _gameRating;
        }

        public override string GetGameType()
        {
            return "Basic game";
        }
    }
}