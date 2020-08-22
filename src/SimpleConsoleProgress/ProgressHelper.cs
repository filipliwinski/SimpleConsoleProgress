using System;

namespace SimpleConsoleProgress
{
    internal static class ProgressHelper
    {
        internal static void ValidateInputs(int current, int total)
        {
            if (total <= 0)
            {
                throw new ArgumentException("Unable to write progress. Total below ore equal zero.");
            }
            if (current < 0)
            {
                throw new ArgumentException("Unable to write progress. Current below zero.");
            }
            if (total < current)
            {
                throw new ArgumentException("Unable to write progress. Total less than current.");
            }
        }

        internal static string GetElapsedString(TimeSpan elapsed)
        {
            var format = elapsed.Hours > 0 ? "hh\\:mm\\:ss" : elapsed.Minutes > 0 ? "mm\\:ss" : elapsed.Seconds > 0 ? "mm\\:ss\\.fff" : "ss\\.fff";
            return $" {elapsed.ToString(format)}";
        }
    }
}
