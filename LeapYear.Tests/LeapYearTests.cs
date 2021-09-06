using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Xunit;

namespace LeapYear.Tests
{
    public class LeapYearTests
    {
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
            var inputString = "";
            foreach (var y in leapYears)
                inputString += y.ToString() + "\r\n";
            foreach (var y in nonLeapYears)
                inputString += y.ToString() + "\r\n";
            inputString += "q\r\n";

            var reader = new StringReader(inputString);
            var writer = new StringWriter();
            Console.SetIn(reader);
            Console.SetOut(writer);
            LeapYear.InteractiveLeapCalander();

            string expectedOutput = "Input year to check (or \'q\' to exit):";
            foreach (var y in leapYears)
                expectedOutput += "yay\r\n";
            foreach (var y in nonLeapYears)
                expectedOutput += "nay\r\n";
            string actualOutput = writer.GetStringBuilder().ToString();
            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}
