using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Monopoly.Locations;

namespace Monopoly.Test
{
    [TestClass]
    public class ANewlyCreatedGame : GameTestBase
    {
        protected override void OnInitialize()
        {      
        }

        [TestMethod]
        public void HasAllLocationsSetup()
        {
            Assert.IsTrue(_game.Locations[4] is IncomeTax);
            Assert.IsTrue(_game.Locations[30] is GoToJail);
            Assert.AreEqual(40, _game.Locations.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PlayerCanNotRollWhenGameHasNotStarted()
        {
            _game.Roll(1);
        }

        [TestMethod]
        public void CanAddPlayer()
        {
            AddPlayerToGame("Hans");

            Assert.AreEqual("Hans", _game.Players[0].Name);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GameCanNotStartWithOnePlayer()
        {
            AddPlayerToGame("Hans");

            _game.Start();
        }

        [TestMethod]
        public void GameCanStartWithEightPlayers()
        {
            AddPlayerToGame("Hans");
            AddPlayerToGame("Sepp");
            AddPlayerToGame("Susi");
            AddPlayerToGame("Franz");
            AddPlayerToGame("Paul");
            AddPlayerToGame("Peter");
            AddPlayerToGame("Elisabeth");
            AddPlayerToGame("Magdalena");

            _game.Start();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GameCanNotStartWithNinePlayers()
        {
            AddPlayerToGame("Hans");
            AddPlayerToGame("Sepp");
            AddPlayerToGame("Susi");
            AddPlayerToGame("Franz");
            AddPlayerToGame("Paul");
            AddPlayerToGame("Peter");
            AddPlayerToGame("Elisabeth");
            AddPlayerToGame("Magdalena");
            AddPlayerToGame("Hildegard");

            _game.Start();
        }
    }
}
