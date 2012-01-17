using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tennis
{
    [TestClass]
    public class Tests
    {
        private Game _game;

        [TestInitialize]
        public void Initialize()
        {
            _game = new Game();
        }

        [TestMethod]
        public void InitialScore()
        {
            var score = _game.GetScore();
            Assert.AreEqual("0 - 0", score);
        }

        [TestMethod]
        public void PlayerOneScoresOnePoint()
        {
            _game.ScorePoint(0);
            var score = _game.GetScore();
            Assert.AreEqual("15 - 0", score);
        }

        [TestMethod]
        public void PlayerTwoScoresOnePoint()
        {
            _game.ScorePoint(1);
            var score = _game.GetScore();
            Assert.AreEqual("0 - 15", score);
        }

        [TestMethod]
        public void PlayerOneScoresTwoPoints()
        {
            ScoreManyPoints(0, 2);
            var score = _game.GetScore();
            Assert.AreEqual("30 - 0", score);
        }

        [TestMethod]
        public void PlayerOnScoresThreePoints()
        {
            ScoreManyPoints(0, 3);
            var score = _game.GetScore();
            Assert.AreEqual("40 - 0", score);
        }

        [TestMethod]
        public void PlayerOneScoresFourPoints()
        {
            ScoreManyPoints(0, 4);
            var score = _game.GetScore();
            AssertPlayerWon("1", score);
        }

        [TestMethod]
        public void PlayerTwoScoresFourPoints()
        {
            ScoreManyPoints(1, 4);
            var score = _game.GetScore();
            AssertPlayerWon("2", score);
        }

        [TestMethod]
        public void BothPlayersScoreThreePoints()
        {
            ScoreDeuce();
            var score = _game.GetScore();
            Assert.AreEqual("Deuce", score);
        }

        [TestMethod]
        public void PlayerOneScoresPointAfterBothPlayersScoredThreePoints()
        {
            ScoreDeuce();
            _game.ScorePoint(0);
            var score = _game.GetScore();
            Assert.AreEqual("Advantage Player 1", score);
        }

        [TestMethod]
        public void PlayerTwoScoresPointAfterBothPlayersScoredThreePoints()
        {
            ScoreDeuce();
            _game.ScorePoint(1);
            var score = _game.GetScore();
            Assert.AreEqual("Advantage Player 2", score);
        }

        [TestMethod]
        public void PlayerTwoScoresPointAfterPlayerOneHadAdvantage()
        {
            ScoreDeuce();
            _game.ScorePoint(0);
            _game.ScorePoint(1);
            var score = _game.GetScore();
            Assert.AreEqual("Deuce", score);
        }

        [TestMethod]
        public void PlayerOneScoresTwoPointsAfterPlayerOnHadAdvantage()
        {
            ScoreDeuce();
            ScoreManyPoints(0, 2);
            var score = _game.GetScore();
            AssertPlayerWon("1", score);
        }

        private static void AssertPlayerWon(string player, string score)
        {
            Assert.AreEqual(string.Format("Player {0} won.", player), score);
        }

        private void ScoreDeuce()
        {
            ScoreManyPoints(0, 3);
            ScoreManyPoints(1, 3);
        }

        private void ScoreManyPoints(int playerIndex, int numberOfScores)
        {
            for (int i = 0; i < numberOfScores; i++)
            {
                _game.ScorePoint(playerIndex);
            }
        }
    }
}
