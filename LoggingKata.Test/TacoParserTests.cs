using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldReturnNonNullObject()
        {            
            var tacoParser = new TacoParser();      
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");            
            Assert.NotNull(actual);
        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("34.170417,-84.782808, Taco Bell Cartersvill...", -84.782808)]
        [InlineData("33.889469,-84.057706, Taco Bell Lawrenceville...", -84.057706)]

        public void ShouldParseLongitude(string line, double expected)
        {
            TacoParser parser = new TacoParser();
            var actual = parser.Parse(line);
            Assert.Equal(expected, actual.Location.Longitude);
        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
        [InlineData("34.170417,-84.782808, Taco Bell Cartersvill...", 34.170417)]
        [InlineData("33.889469,-84.057706, Taco Bell Lawrenceville...", 33.889469)]

        public void ShouldParseLatitude(string line, double expected)         
        { 
            TacoParser parser1 = new TacoParser();  
            var actual = parser1.Parse(line);
            Assert.Equal(expected, actual.Location.Latitude);        
        }
    }
}
