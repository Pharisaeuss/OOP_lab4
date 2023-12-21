using OOP_lab4.MainGame.GameBase;
namespace OOP_lab4.MainGame.GameAccounts
{
    public class HalfLossAccountType : GameAccount
    {
        public HalfLossAccountType(string userName, int initialRating) : base(userName, initialRating)
        {
        }

        protected override int CalculateRatingForWin(int gameRating)
        {
            return gameRating;
        }

        protected override int CalculateRatingForLoss(int gameRating)
        {
            return gameRating / 2;
        }

        public override string GetAccountType()
        {
            return "Reduced penalty";
        }
    }
}