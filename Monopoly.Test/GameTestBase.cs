using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Monopoly.Test
{
    [TestClass]
    public class GameTestBase
    {
        protected Game _game;

        [TestInitialize]
        public void Initialize()
        {
            _game = new Game();
            OnInitialize();
        }

        protected virtual void OnInitialize()
        {
        }

        protected void AddPlayerToGame(string name)
        {
            _game.AddPlayer(new Player(name, _game.Locations));
        }
    }
}
