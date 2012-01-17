namespace Monopoly.Locations
{
    public class GoToJail : ILocation
    {
        public void PerformAction(Player player)
        {
            player.Position = 10;
        }
    }
}
