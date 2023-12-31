﻿using System;
using System.Globalization;
using System.Text;

namespace CourseManagement.Utility
{
    public class UtilityService
    {
        private static readonly Random _random = new Random();
        public static List<DateTime> GetDatesBetweenTwoDates(DateTime startDate, DateTime endDate, int dayOfWeek)
        {
            List<DateTime> dates = new List<DateTime>();
            int startWeekNum = GetWeekNum(startDate);
            int endWeekNum = GetWeekNum(endDate);
            DateTime d = startDate.AddDays(dayOfWeek - 2);
            dates.Add(d);
            for(int i = startWeekNum + 1; i <= endWeekNum; i++) {
                d = d.AddDays(7);
                dates.Add(d);
            }
            return dates;
        }
        private static int GetWeekNum(DateTime d)
        {
            CultureInfo cul = CultureInfo.CurrentCulture;
            return cul.Calendar.GetWeekOfYear(d,
                                                     CalendarWeekRule.FirstDay,
                                                     DayOfWeek.Monday);
        }
        public static string GenerateRandomPassword()
        {
            var passwordBuilder = new StringBuilder();

            // 4-Letters lower case
            passwordBuilder.Append(RandomString(4, true));

            // 4-Digits between 1000 and 9999
            passwordBuilder.Append(RandomNumber(1000, 9999));

            // 2-Letters upper case
            passwordBuilder.Append(RandomString(2));
            return passwordBuilder.ToString();
        }
        private static string RandomString(int size, bool lowerCase = false)
        {
            var builder = new StringBuilder(size);

            // Unicode/ASCII Letters are divided into two blocks
            // (Letters 65–90 / 97–122):
            // The first group containing the uppercase letters and
            // the second group containing the lowercase.

            // char is a single Unicode character
            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26; // A...Z or a..z: length=26

            for (var i = 0; i < size; i++)
            {
                var @char = (char)_random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }
        // Generates a random number within a range.
        private static int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }
    }
}
