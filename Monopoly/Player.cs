using System.Collections.Generic;

namespace Monopoly
{
    public class Player
    {
        private readonly List<ILocation> _locations;

        public Player(string name, List<ILocation> locations)
        {
            _locations = locations;
            Name = name;
        }

        public string Name { get; private set; }

        public void Roll(int roll)
        {
            Position += roll;

            while (MovedOverStart())
            {
                Balance += 200;
                Position = Position - 40;
            }

            var location = _locations[Position];
            location.PerformAction(this);
        }

        public int Position { get; set; }

        public int Balance { get; set; }

        private bool MovedOverStart()
        {
            return Position > 39;
        }
    }
}