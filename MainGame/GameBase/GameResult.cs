namespace OOP_lab4.MainGame.GameBase
{
    public class GameResult
    {
        public string OpponentName { get; set; }
        public bool Victory { get; set; }
        public int RatingChange { get; set; }

        public GameResult(string opponentName, bool victory, int ratingChange)
        {
            OpponentName = opponentName;
            Victory = victory;
            RatingChange = ratingChange;
        }
    }
}