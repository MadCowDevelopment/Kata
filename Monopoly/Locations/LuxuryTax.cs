namespace Monopoly.Locations
{
    public class LuxuryTax : ILocation
    {
        public void PerformAction(Player player)
        {
            if (player.Balance > 75)
            {
                player.Balance -= 75;
            }
        }
    }
}
