namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");
            var cells = line.Split(',');

            if (cells.Length < 3)
            {
                logger.LogError("Array Length is less than 3");
                return null; 
            }

            double.TryParse(cells[0], out var latitude);
            double.TryParse (cells[1], out var longitude);
            string name = cells[2];

 
            Point location = new Point() { Latitude = latitude, Longitude = longitude };

            TacoBell tacoBell = new TacoBell() { Name = name, Location = location };
            
            return tacoBell;          
        }
    }
}
