using System;
using System.Collections.Generic;

namespace OOP_lab4.MainGame.GameBase
{
    public abstract class GameAccount
    {
        private string _userName;
        public int CurrentRating;
        public int GamesCount;
        private List<GameResult> History { get; set; }

        protected GameAccount(string userName, int initialRating)
        {
            SetUserName(userName);
            if (initialRating < 1)
            {
                throw new ArgumentException("Рейтинг має бути >= 1");
            }

            CurrentRating = initialRating;
            GamesCount = 0;
            History = new List<GameResult>();
        }

        protected abstract int CalculateRatingForWin(int gameRating);

        protected abstract int CalculateRatingForLoss(int gameRating);

        public void WinGame(GameAccount opponent, int gameRating)
        {
            int ratingChange = CalculateRatingForWin(gameRating);
            CurrentRating += ratingChange;
            GamesCount++;
            History.Add(new GameResult(opponent.GetUserName(), true, ratingChange));
        }

        public void LoseGame(GameAccount opponent, int gameRating)
        {
            var ratingChange = CalculateRatingForLoss(gameRating);
            CurrentRating -= ratingChange;
            if (CurrentRating < 1)
            {
                CurrentRating = 1;
            }

            GamesCount++;
            History.Add(new GameResult(opponent.GetUserName(), false, ratingChange));
        }

        public void GetStats()
        {
            Console.WriteLine($"Статистика гравця {_userName} ({GetAccountType()}):");
            for (var i = 0; i < History.Count; i++)
            {
                var GameResult = History[i];
                var output = GameResult.Victory ? "Перемога" : "Програш";
                Console.WriteLine(
                    $"Гра №{i + 1}: Опонент: {GameResult.OpponentName} | Результат гри: {output} | Рейтинг гри: {GameResult.RatingChange}");
            }

            Console.WriteLine($"Рейтинг гравця: {CurrentRating}");
        }

        private string GetUserName()
        {
            return _userName;
        }

        public virtual string GetAccountType()
        {
            return "Стандартний";
        }

        private void SetUserName(string value)
        {
            _userName = value;
        }
    }
}