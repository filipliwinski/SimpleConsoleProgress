// MIT License
//  
//  Copyright (c) 2020-2021 Filip Liwiński
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in all
//  copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//  SOFTWARE.
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
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(GetProgress(current, total, size, elapsed, character, location, accuracy));
            if (current + 1 >= total)
            {
                if (autoHide)
                {
                    // Clear console line
                    Console.SetCursorPosition(0, Console.CursorTop);
                    for (int i = 0; i < Console.WindowWidth; i++)
                    {
                        Console.Write(" ");
                    }
                    Console.SetCursorPosition(0, Console.CursorTop);
                }
                else
                {
                    Console.WriteLine();
                }
                Console.CursorVisible = true;
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
            Console.WriteLine(GetProgress(current, total, size, elapsed, character, location, accuracy));
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
