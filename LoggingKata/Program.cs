using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {

            logger.LogInfo("Log initialized");

            // Log and error if you get 0 lines and a warning if you get 1 line
            var lines = File.ReadAllLines(csvPath);
            if (lines.Length == 0)
            {
                logger.LogError("No input");
            }
            if (lines.Length == 1)
            {
                logger.LogWarning("Only one input");
            }

            logger.LogInfo($"Lines: {lines[0]}");

            // Create a new instance of your TacoParser class
            var parser = new TacoParser();

            // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
            var locations = lines.Select(line => parser.Parse(line)).ToArray();

            // instantiates classess of Taco Bells farthest apart
            ITrackable tacoBellOne = new TacoBell();
            ITrackable tacoBellTwo = new TacoBell();

            // stores distance
            double distance = 0;

            // stors lat and lon locations into one variable and asigns stored values into Taco Bell classes.
            for (int i = 0; i < locations.Length; i++)
            {
                var locA = locations[i];
                var corA = new GeoCoordinate();
                corA.Latitude = locA.Location.Latitude;
                corA.Longitude = locA.Location.Latitude;

                for (int j = 0; j < locations.Length; j++)
                {
                    var locB = locations[j];
                    var corB = new GeoCoordinate();
                    corB.Latitude = locB.Location.Latitude;
                    corB.Longitude = locB.Location.Latitude;
                    // Calculates to see which two Taco Bells are farthest apart
                    if (corA.GetDistanceTo(corB) > distance)
                    {
                        distance = corA.GetDistanceTo(corB);
                        tacoBellOne = locA;
                        tacoBellTwo = locB;
                    }
                }
            }
            // Reads to the console the Taco Bells farthest from each other
            logger.LogInfo($"{tacoBellOne.Name} is farthest from {tacoBellTwo.Name}.");
        }
    }
}
