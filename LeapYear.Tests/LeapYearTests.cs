using System;
using System.Collections.Generic;
using Xunit;

namespace LeapYear.Tests
{
    public class LeapYearTests
    {
        [Fact]
        public void Returns_True_On_Sample_Leap_Years()
        {
            var years = new List<int>
            {
                1600, 1996, 2000, 2020, 2400
            };

            foreach (int year in years)
                Assert.True(LeapYear.IsLeapYear(year));
        }

        [Fact]
        public void Returns_False_On_Sample_Non_Leap_Years()
        {
            var years = new List<int>
            {
                1900, 1999, 2021, 2100
            };

            foreach (int year in years)
                Assert.False(LeapYear.IsLeapYear(year));
        }
    }
}
