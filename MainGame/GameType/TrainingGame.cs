using OOP_lab4.MainGame.GameBase;
namespace OOP_lab4.MainGame.GameType
{
    public class TrainingGame : Game
    {
        public override int GetGameRating()
        {
            return 0;
        }
        public override string GetGameType()
        {
            return "Training game";
        }
    }
}