namespace Tennis
{
    public class Game
    {
        private int _player1Points;

        private int _player2Points;

        public void ScorePoint(int playerIndex)
        {
            if (playerIndex == 0)
            {
                _player1Points++;
            }
            else
            {
                _player2Points++;
            }
        }

        public string GetScore()
        {
            if (Player1Won())
            {
                return "Player 1 won.";
            }

            if (Player2Won())
            {
                return "Player 2 won.";
            }

            if (PlayersAreDeuced())
            {
                return "Deuce";
            }

            if (Player1HasAdvantage())
            {
                return "Advantage Player 1";
            }

            if (Player2HasAdvantage())
            {
                return "Advantage Player 2";
            }

            var player1Score = CalculateScoreFromPoints(_player1Points);
            var player2Score = CalculateScoreFromPoints(_player2Points);

            return string.Format("{0} - {1}", player1Score, player2Score);
        }

        private bool Player1HasAdvantage()
        {
            return _player1Points >= 4 && _player1Points > _player2Points;
        }

        private bool Player2HasAdvantage()
        {
            return _player2Points >= 4 && _player2Points > _player1Points;
        }

        private bool PlayersAreDeuced()
        {
            return _player1Points >= 3 && _player2Points >= 3 && _player1Points == _player2Points;
        }

        private bool Player1Won()
        {
            if (_player1Points >= 4 && _player1Points > _player2Points + 1)
            {
                return true;
            }

            return false;
        }

        private bool Player2Won()
        {
            if (_player2Points >= 4 && _player2Points > _player1Points + 1)
            {
                return true;
            }

            return false;
        }

        private string CalculateScoreFromPoints(int points)
        {
            return points > 2 ? "40" : (points * 15).ToString();
        }
    }
}