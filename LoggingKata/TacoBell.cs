using System;
namespace LoggingKata
{
    public class TacoBell :ITrackable
    {
        // Default Constructor
        public TacoBell()
        {

        }

        // Perameterized Constructor
        public TacoBell(string name,Point location)
        {
            Name = name;
            Location = location;
        }

        // Inhereted Properties from ITrackable Interface
        public string Name { get; set; }
        public Point Location { get; set; }
    }
}

