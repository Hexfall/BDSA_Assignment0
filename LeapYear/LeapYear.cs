﻿using System;

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
                var num = int.Parse(input);
                Console.WriteLine(IsLeapYear(num) ? "yay" : "nay");

                input = Console.ReadLine().Trim();
            }
        }
    }
}
