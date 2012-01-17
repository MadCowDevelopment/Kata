using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Monopoly.Test
{
    [TestClass]
    public class AStartedGameWithTwoPlayers : GameTestBase
    {
        protected override void OnInitialize()
        {
            AddPlayerToGame("Hans");
            AddPlayerToGame("Sepp");
            _game.Start();
        }

        [TestMethod]
        public void GameCanStartWithTwoPlayers()
        {
            Assert.AreEqual(GameState.Running, _game.GameState);
        }
        
        [TestMethod]
        public void RandomizeWorks()
        {
            do
            {
                _game.Start();
            }
            while (_game.Players[0].Name == "Hans");

            Assert.AreEqual("Sepp", _game.Players[0].Name);
            Assert.AreEqual("Hans", _game.Players[1].Name);
        }

        [TestMethod]
        public void GameLastsTwentyRounds()
        {
            for (int i = 0; i < 40; i++)
            {
                _game.Roll(1);
            }

            Assert.AreEqual(GameState.GameOver, _game.GameState);
        }

        [TestMethod]
        public void OrderOfPlayersIsTheSameInEveryRound()
        {
            var firstPlayer = _game.Players[0];
            var secondPlayer = _game.Players[1];

            for (int i = 0; i < 20; i++)
            {
                Assert.AreEqual(firstPlayer, _game.CurrentPlayer);
                _game.Roll(1);
                Assert.AreEqual(secondPlayer, _game.CurrentPlayer);
                _game.Roll(1);
            }
        }
    }
}
