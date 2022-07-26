namespace LoggingKata
{
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            //Commented out to stop multiple logs running through the console
            //logger.LogInfo("Begin parsing");

            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            var cells = line.Split(',');

            // Checks array length to ensure longitude, latitude, and name exist
            if (cells.Length < 3)
            {
                logger.LogWarning("Missing Latitude, Longitude, or Name in CSV file");
                return null;
            }

            // stores latitude from CSV array at index 0
            var lat = double.Parse(cells[0]);
            // stores Longitude from CSV array at index 1
            var lon = double.Parse(cells[1]);
            // stores name from CSV array at index 2
            var name = cells[2];

            // stores longitude and latitude into one object
            var point = new Point()
            {
                Latitude = lat,
                Longitude = lon
            };

            // Instance of Taco Bell that adds name and location
            var tacoBell = new TacoBell(name, point);
            return tacoBell;
        }
    }
}