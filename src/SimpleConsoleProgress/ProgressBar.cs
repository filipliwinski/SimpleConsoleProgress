// Copyright (c) Filip Liwiński
//  
//  Licensed under the MIT License. See the LICENSE file in the project root for license information.
//

using System;
using System.Text;

namespace SimpleConsoleProgress
{
    /// <summary>
    /// Allows to write the progress bar to the standard output stream.
    /// </summary>
    public static class ProgressBar
    {
        /// <summary>
        /// Writes the progress bar to the standard output stream.
        /// </summary>
        /// <param name="current">Current item number (not the percentage).</param>
        /// <param name="total">Total number of items.</param>
        /// <param name="elapsed">Total time elapsed since the start of the process.</param>
        /// <param name="character">Character to show in the progress bar.</param>
        /// <param name="autoHide">If true, the progress bar is removed upon completion.</param>
        /// <param name="location">Specifies the position of the percentage.</param>
        public static void Write(int current, int total, TimeSpan? elapsed = null, char character = '#', bool autoHide = false, PercentLocation location = PercentLocation.Middle, int accuracy = 0, BarSize size = BarSize.Full)
        {
            if (current + 1 < total)
            {
                Console.CursorVisible = false;
            }

            // Store the value of CursorTop for future reference to prevent wrapping to a new line - #25
            var initialCursorTop = Console.CursorTop;
            Console.SetCursorPosition(0, initialCursorTop);

            Console.Write(GetProgress(current, total, size, elapsed, character, location, accuracy));

            if (current + 1 >= total)
            {
                if (autoHide)
                {
                    // Clear console line
                    Console.SetCursorPosition(0, initialCursorTop);
                    for (int i = 0; i < Console.WindowWidth; i++)
                    {
                        Console.Write(" ");
                    }
                }
                else
                {
                    Console.WriteLine();
                }
                Console.CursorVisible = true;
            }

            // Set position of cursor based on the initial value - #25
            if (autoHide || current + 1 != total) {
                Console.SetCursorPosition(0, initialCursorTop);
            }
            else
            {
                // For the last value move to a new line
                Console.SetCursorPosition(0, initialCursorTop + 1);
            }
        }

        /// <summary>
        /// Writes the progress bar, followed by the current line terminator, to the standard output stream.
        /// </summary>
        /// <param name="current">Current item number (not the percentage).</param>
        /// <param name="total">Total number of items.</param>
        /// <param name="elapsed">Total time elapsed since the start of the process.</param>
        /// <param name="character">Character to show in the progress bar.</param>
        /// <param name="location">Specifies the position of the percentage.</param>
        public static void WriteLine(int current, int total, TimeSpan? elapsed = null, char character = '#', PercentLocation location = PercentLocation.Middle, int accuracy = 0, BarSize size = BarSize.Full)
        {
            // Store the value of CursorTop for future reference to prevent wrapping to a new line - #25
            var initialCursorTop = Console.CursorTop;

            Console.WriteLine(GetProgress(current, total, size, elapsed, character, location, accuracy));

            // Set position of cursor based on the initial value - #25
            Console.SetCursorPosition(0, initialCursorTop + 1);
        }

        internal static string GetProgress(
            int current,
            int total,
            BarSize size = BarSize.Full,
            TimeSpan? elapsed = null,
            char character = '#',
            PercentLocation location = PercentLocation.Middle,
            int accuracy = 0)
        {
            int barLength;
            var elapsedLength = elapsed.HasValue ? ProgressHelper.GetElapsedString(elapsed.Value).Length : 0;
            var accuracyLevel = ProgressHelper.SetAccuracy(accuracy);

            if (size != BarSize.Full && (int)size < GetConsoleWindowWidth())
            {
                barLength = (int)size - 2;
            }
            else
            {
                barLength = GetConsoleWindowWidth() - 2; // brackets []
            }

            // Make space for elapsed time.
            if (barLength + elapsedLength >= GetConsoleWindowWidth())
            {
                barLength -= elapsedLength;
            }

            if (size == BarSize.Full && (location == PercentLocation.Left || location == PercentLocation.Right))
            {
                // This will shorten the bar to fit the progress value outside.
                barLength -= 5;

                if (accuracyLevel > 0)
                {
                    barLength -= (int)accuracyLevel + 1;  // Include decimal points and delimiter
                }
            }

            decimal progressValue = ProgressHelper.GetProgressValue(current, total);
            string progressString = ProgressHelper.GetProgressString(progressValue, location, accuracyLevel);
            
            var progressBuilder = new StringBuilder();

            progressBuilder.Append(location == PercentLocation.Left ? $"{progressString} [" : "[");

            for (byte i = 0; i < barLength; i++)
            {
                var position = barLength * progressValue / 100 - 1;
                if (progressValue > 0 && i <= position)
                {
                    progressBuilder.Append(character);
                }
                else
                {
                    progressBuilder.Append(" ");
                }
            }

            progressBuilder.Append(location == PercentLocation.Right ? $"] {progressString}" : "]");

            if (elapsed.HasValue)
            {
                progressBuilder.Append(ProgressHelper.GetElapsedString(elapsed.Value));
            }

            var progressBar = progressBuilder.ToString();

            if (location == PercentLocation.Middle)
            {
                var postfix = 0;
                var substringLength = barLength / 2 + 1; // Adding 1 for centering the progress value.

                var progressLength = progressString.Length;

                if (progressLength % 2 == 1)
                {
                    postfix++;
                }
                
                progressBar =  progressBar.Substring(0, substringLength - progressLength / 2) + progressString + progressBar.Substring(substringLength + progressLength / 2 + postfix);
            }

            return progressBar;
        }

        private static int GetConsoleWindowWidth()
        {
            if (Console.LargestWindowWidth == 0)
            {
                // This does not run in a Console window (workaround for unit tests).
                return (int)BarSize.Full;
            }
            return Console.WindowWidth;
        }
    }
}
