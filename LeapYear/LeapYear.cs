using System;

namespace LeapYear
{
    public class LeapYear
    {
        public static void Main(string[] args)
        {
            InteractiveLeapCalander();
        }

        public static bool IsLeapYear(int year)
        {
            if (year == 0)
                throw new ArgumentNullException("0 AD does not exist");
            if (year < 1582)
                throw new ArgumentOutOfRangeException("Does not apply to years before 1582.");
            if (year % 400 == 0)
                return true;
            if (year % 100 == 0)
                return false;
            if (year % 4 == 0)
                return true;
            return false;
        }

        public static void InteractiveLeapCalander()
        {
            Console.WriteLine("Input year to check (or \'q\' to exit):");
            string input = Console.ReadLine().Trim();
            while (!(input == "q"))
            {
                try
                {
                    var num = int.Parse(input);
                    Console.WriteLine(IsLeapYear(num) ? "yay" : "nay");
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("1582 marks the introduction of the Gregorian calendar, so dates before then are invalid");
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("The year 0 AD does not exist. The Gregorian calendar goes from 1 BC to 1 AD");
                }
                input = Console.ReadLine().Trim();
            }
        }
    }
}
