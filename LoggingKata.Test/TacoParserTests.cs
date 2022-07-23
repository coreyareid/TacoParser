using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        // Test to see if Parse returns null
        public void ShouldDoSomething()
        {
            //Arrange
            var tacoParser = new TacoParser();
            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");
            //Assert
            Assert.NotNull(actual);
        }

        // Test to Parse Longitude
        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        public void ShouldParseLongitude(string line, double expected)
        {
            //Arrange
            var parser = new TacoParser();
            //Act
            var actual = parser.Parse(line);
            //Assert
            Assert.Equal(expected, actual.Location.Longitude);
        }

        // Test to Parse Latitude
        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
        public void ShouldParseLatitude(string Line, double expected)
        {
            //Arange
            var parser = new TacoParser();
            //Act
            var actual = parser.Parse(Line);
            //Assert
            Assert.Equal(expected, actual.Location.Latitude);
        }
    }
}
