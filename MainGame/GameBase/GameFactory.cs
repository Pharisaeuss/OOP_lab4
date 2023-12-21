using OOP_lab4.MainGame.GameAccounts;

namespace OOP_lab4.MainGame.GameBase
{
    public class GameFactory
    {
        public static GameAccount CreateBasicAccountType(string userName, int initialRating)
        {
            return new BasicAccountType(userName, initialRating);
        }

        public static GameAccount CreateHalfLossAccountType(string userName, int initialRating)
        {
            return new HalfLossAccountType(userName, initialRating);
        }

        public static GameAccount CreateWinningStreakAccountType(string userName, int initialRating)
        {
            return new WinningStreakAccountType(userName, initialRating);
        }
    }
}