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

namespace SimpleConsoleProgress
{
    public enum PercentLocation
    {
        None,
        Left,
        Middle,
        Right
    }

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
        public static void Write(int current, int total, TimeSpan? elapsed = null, char character = '#', bool autoHide = false, PercentLocation location = PercentLocation.Middle)
        {
            if (current + 1 < total)
            {
                Console.CursorVisible = false;
            }
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(GetProgress(current, total, elapsed, character, location));
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
        public static void WriteLine(int current, int total, TimeSpan? elapsed = null, char character = '#', PercentLocation location = PercentLocation.Middle)
        {
            Console.WriteLine(GetProgress(current, total, elapsed, character, location));
        }

        private static string GetProgress(int current, int total, TimeSpan? elapsed, char character, PercentLocation location, byte accuracy = 0)
        {
            if (accuracy > 3)
            {
                accuracy = 3;
            }

            var barLength = Console.WindowWidth;

            barLength -= elapsed.HasValue ? ProgressHelper.GetElapsedString(elapsed.Value).Length : 0; // elapsed time

            barLength -= 2; // brackets []

            if (accuracy > 0)
            {
                barLength -= accuracy - 1; // decimal points
            }

            if (location == PercentLocation.Left || location == PercentLocation.Right)
            {
                // This will shorten the bar to fit the progress outside.
                barLength -= 5 + accuracy;
            }

            ProgressHelper.ValidateInputs(current, total);

            decimal percent = (current + 1) * 100 / total;
            string percentString;

            switch (location)
            {
                case PercentLocation.Left:
                    if (accuracy == 0)
                    {
                        percentString = $"{percent,3:0}";
                    }
                    else if (accuracy == 1)
                    {
                        percentString = $"{percent,5:0.0}";
                    }
                    else if (accuracy == 2)
                    {
                        percentString = $"{percent,6:0.00}";
                    }
                    else
                    {
                        percentString = $"{percent,7:0.000}";
                    }
                    break;
                case PercentLocation.Middle:
                case PercentLocation.Right:
                    if (accuracy == 0)
                    {
                        percentString = $"{percent:0}";
                    }
                    else if (accuracy == 1)
                    {
                        percentString = $"{percent:0.0}";
                    }
                    else if (accuracy == 2)
                    {
                        percentString = $"{percent:0.00}";
                    }
                    else
                    {
                        percentString = $"{percent:0.000}";
                    }
                    break;
                default:
                    percentString = "";
                    break;
            }

            var progressBar = location == PercentLocation.Left ? $"{percentString}% [" : "[";

            for (byte i = 0; i < barLength; i++)
            {
                var position = barLength * percent / 100 - 1;
                if (percent > 0 && i <= position)
                {
                    progressBar += character;
                }
                else
                {
                    progressBar += " ";
                }
            }

            progressBar += location == PercentLocation.Right ? $"] {percentString}%" : "]";

            if (elapsed.HasValue)
            {
                progressBar += ProgressHelper.GetElapsedString(elapsed.Value);
            }

            if (location == PercentLocation.Middle)
            {
                var digits = percent < 10 ? 1 : percent < 100 ? 2 : 3;
                var substringLength = barLength / 2;

                return progressBar.Substring(0, substringLength - digits) + percentString + "%" + progressBar.Substring(substringLength + 3);
            }

            return progressBar;
        }
    }
}
