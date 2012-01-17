namespace Monopoly.Locations
{
    public class IncomeTax : ILocation
    {
        public void PerformAction(Player player)
        {
            if (player.Balance >= 200)
            {
                player.Balance -= 200;
            }
        }
    }
}
