using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;
using System.ComponentModel;

namespace LoggingKata;

class Program
{
    static readonly ILog logger = new TacoLogger();
    const string csvPath = "TacoBell-US-AL.csv";

    static void Main(string[] args)
    {
        logger.LogInfo("Log initialized");

        // Use File.ReadAllLines(path) to grab all the lines from your csv file. 
        // Optional: Log an error if you get 0 lines and a warning if you get 1 line
        var lines = File.ReadAllLines(csvPath);

       
        foreach (var line in lines) 
        {
            logger.LogInfo($"Lines: {lines[0]}");
            
        }

        var parser = new TacoParser();
        var locations = lines.Select(parser.Parse).ToArray();

        ITrackable tacobell1 = null;
        ITrackable tacobell2 = null;
        double distance = 0;

        GeoCoordinate geo = new GeoCoordinate();

        for (int i = 0; i < locations.Length; i++) 
        { 
        
            var locA = locations[i];
            GeoCoordinate corA = new GeoCoordinate(locA.Location.Latitude, locA.Location.Longitude);

            for (int j = 0; j < locations.Length; j++) 
            {
                var locB = locations[j];
                GeoCoordinate corB = new GeoCoordinate(locB.Location.Latitude, locB.Location.Longitude);
                if (corA.GetDistanceTo(corB) > distance) 
                { 
                    tacobell1 = locA;
                    tacobell2 = locB;
                    distance = corA.GetDistanceTo(corB);
                }
            }
        }


        Console.WriteLine("The two taco bells that are farthest away are");
        Console.WriteLine("-----------------------------------------------------------------------------------");
        Console.WriteLine($"Taco Bell 1: {tacobell1.Name}, {tacobell1.Location.Latitude} {tacobell1.Location.Longitude}");
        Console.WriteLine($"Taco Bell 2: {tacobell2.Name}, {tacobell2.Location.Latitude} {tacobell2.Location.Longitude}");



    }
}
