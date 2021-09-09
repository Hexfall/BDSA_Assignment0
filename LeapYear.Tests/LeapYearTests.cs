using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Xunit;

namespace LeapYear.Tests
{
    public class LeapYearTests
    {
        // Sample years for testing.
        private readonly List<int> leapYears = new()
        {
            1600, 1996, 2000, 2020, 2400
        }, nonLeapYears = new()
        {
            1900, 1999, 2021, 2100
        };

        [Fact]
        public void Returns_True_On_Sample_Leap_Years()
        {
            foreach (int year in leapYears)
                Assert.True(LeapYear.IsLeapYear(year));
        }

        [Fact]
        public void Returns_False_On_Sample_Non_Leap_Years()
        {
            foreach (int year in nonLeapYears)
                Assert.False(LeapYear.IsLeapYear(year));
        }

        [Fact]
        public void Responds_Correctly_To_User_input()
        {
            // Arrange
            var inputString = "";
            foreach (var y in leapYears)
                inputString += y.ToString() + Environment.NewLine.ToString();
            foreach (var y in nonLeapYears)
                inputString += y.ToString() + Environment.NewLine.ToString();
            inputString += $"q{Environment.NewLine}";

            // Act
            var reader = new StringReader(inputString);
            var writer = new StringWriter();
            Console.SetIn(reader);
            Console.SetOut(writer);
            LeapYear.InteractiveLeapCalander();

            // Assert
            string expectedOutput = $"Input year to check (or \'q\' to exit):{Environment.NewLine}";
            foreach (var y in leapYears)
                expectedOutput += $"yay{Environment.NewLine}";
            foreach (var y in nonLeapYears)
                expectedOutput += $"nay{Environment.NewLine}";
            string actualOutput = writer.GetStringBuilder().ToString();
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void Throws_Error_Before_1582()
        {
            // Arrange
            List<int> years = new()
            {
                -15,
                1,
                56,
                1444,
                1580,
                1581
            };

            foreach (int y in years)
            {
                try
                {
                    // Act
                    LeapYear.IsLeapYear(y);
                    throw new InvalidOperationException("Earlier line should have thrown exception.");
                }
                catch (Exception e)
                {
                    // Assert
                    Assert.Equal(new ArgumentOutOfRangeException().GetType(), e.GetType());
                }
            }
        }

        [Fact]
        public void Console_Responds_Correctly_Below_1582()
        {
            // Arrange
            string inputString = 1581.ToString() + Environment.NewLine + "q" + Environment.NewLine;
            var reader = new StringReader(inputString);
            var writer = new StringWriter();

            // Act
            Console.SetIn(reader);
            Console.SetOut(writer);
            LeapYear.InteractiveLeapCalander();
            string actualOutput = writer.GetStringBuilder().ToString();

            // Assert
            string expectedOutput = $"Input year to check (or \'q\' to exit):{Environment.NewLine}";
            expectedOutput += $"1582 marks the introduction of the Gregorian calendar, so dates before then are invalid{Environment.NewLine}";
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void IsLeapYear_Throws_Error_For_0()
        {
            try
            {
                // Act
                LeapYear.IsLeapYear(0);
                throw new InvalidOperationException("Earlier line should have thrown exception.");
            }
            catch (Exception e)
            {
                // Assert
                Assert.Equal(new ArgumentNullException().GetType(), e.GetType());
            }
        }

        [Fact]
        public void Console_Responds_Correctly_To_0()
        {
            // Arrange
            string inputString = 0.ToString() + Environment.NewLine + "q" + Environment.NewLine;
            var reader = new StringReader(inputString);
            var writer = new StringWriter();

            // Act
            Console.SetIn(reader);
            Console.SetOut(writer);
            LeapYear.InteractiveLeapCalander();
            string actualOutput = writer.GetStringBuilder().ToString();

            // Assert
            string expectedOutput = $"Input year to check (or \'q\' to exit):{Environment.NewLine}";
            expectedOutput += $"The year 0 AD does not exist. The Gregorian calendar goes from 1 BC to 1 AD{Environment.NewLine}";
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void Catches_Non_Numbers_And_Responds_Accordingly()
        {
            // Arrange
            string inputString = "Not a number" + Environment.NewLine + "q" + Environment.NewLine;
            var reader = new StringReader(inputString);
            var writer = new StringWriter();

            // Act
            Console.SetIn(reader);
            Console.SetOut(writer);
            LeapYear.InteractiveLeapCalander();
            string actualOutput = writer.GetStringBuilder().ToString();

            // Assert
            string expectedOutput = $"Input year to check (or \'q\' to exit):{Environment.NewLine}";
            expectedOutput += $"Input must be a whole number{Environment.NewLine}";
            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}
