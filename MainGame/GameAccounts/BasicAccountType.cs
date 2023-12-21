using OOP_lab4.MainGame.GameBase;
namespace OOP_lab4.MainGame.GameAccounts
{
    public class BasicAccountType : GameAccount
    {
        public BasicAccountType(string userName, int initialRating) : base(userName, initialRating)
        {
        }

        protected override int CalculateRatingForWin(int gameRating)
        {
            return gameRating;
        }

        protected override int CalculateRatingForLoss(int gameRating)
        {
            return gameRating;
        }

        public override string GetAccountType()
        {
            return "Basic";
        }
    }
}