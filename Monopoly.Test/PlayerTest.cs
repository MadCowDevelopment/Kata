using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Monopoly.Test
{
    [TestClass]
    public class PlayerTest
    {
        private Player _player;

        [TestInitialize]
        public void Initialize()
        {
            var game = new Game();
            _player = new Player("Hans", game.Locations);
        }

        [TestMethod]
        public void PlayerCanMove()
        {
            _player.Roll(1);

            Assert.AreEqual(1, _player.Position);
        }

        [TestMethod]
        public void MovingOverStartContinuesAtTheBeginning()
        {
            _player.Roll(45);

            Assert.AreEqual(5, _player.Position);
        }

        [TestMethod]
        public void MovingOverStartAdds200DollarToBalance()
        {
            _player.Roll(45);

            Assert.AreEqual(200, _player.Balance);
        }

        [TestMethod]
        public void MovingOverStartTwiceAdds200DollarToBalance()
        {
            _player.Roll(100);

            Assert.AreEqual(400, _player.Balance);
        }

        [TestMethod]
        public void LandingOnGoToJailPutsThePlayerInJail()
        {
            _player.Roll(30);

            Assert.AreEqual(10, _player.Position);
        }

        [TestMethod]
        public void MovingOverANormalFieldDoesntIncreaseBalance()
        {
            _player.Roll(1);

            Assert.AreEqual(0, _player.Balance);
        }

        [TestMethod]
        public void LandingOnIncomeTaxWith200BalanceReducesBalanceBy200()
        {
            _player.Balance = 200;

            _player.Roll(4);

            Assert.AreEqual(0, _player.Balance);
        }

        [TestMethod]
        public void LandingOnIncomeTaxWith0BalanceReducesBalanceBy0()
        {
            _player.Roll(4);

            Assert.AreEqual(0, _player.Balance);
        }

        [TestMethod]
        public void SteppingOverIncomeTaxWith200BalanceDoesntChangeBalance()
        {
            _player.Balance = 200;

            _player.Roll(5);

            Assert.AreEqual(200, _player.Balance);
        }

        [TestMethod]
        public void LandingOnLuxuryTaxWith200BalanceReducesBalanceBy75()
        {
            _player.Balance = 200;

            _player.Roll(38);

            Assert.AreEqual(125, _player.Balance);
        }

        [TestMethod]
        public void LandingOnLuxuryTaxWith0BalanceDoesntChangeBalance()
        {
            _player.Roll(38);

            Assert.AreEqual(0, _player.Balance);
        }
    }
}
