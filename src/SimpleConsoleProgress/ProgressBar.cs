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
        public static void Write(int current, int total, TimeSpan? elapsed = null, char character = '#', bool autoHide = false)
        {
            if (current + 1 < total)
            {
                Console.CursorVisible = false;
            }
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(GetProgress(current, total, elapsed, character));
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
        public static void WriteLine(int current, int total, TimeSpan? elapsed = null, char character = '#')
        {
            Console.WriteLine(GetProgress(current, total, elapsed, character));
        }

        private static string GetProgress(int current, int total, TimeSpan? elapsed, char character)
        {
            // Progress bar length equals console window with - brakets (2) - elapsed string length
            var length = Console.WindowWidth - 2 - (elapsed.HasValue ? ProgressHelper.GetElapsedString(elapsed.Value).Length : 0);

            ProgressHelper.ValidateInputs(current, total);

            var procent = (current + 1) * 100 / total;
            var progressBar = "[";

            for (byte i = 0; i < length; i++)
            {
                var position = (decimal)length * procent / 100 - 1;
                if (procent > 0 && i <= position)
                {
                    progressBar += character;
                }
                else
                {
                    progressBar += " ";
                }
            }

            progressBar += "]";

            if (elapsed.HasValue)
            {
                progressBar += ProgressHelper.GetElapsedString(elapsed.Value);
            }

            var digits = procent < 10 ? 1 : procent < 100 ? 2 : 3;
            var substringLength = length / 2;

            return progressBar.Substring(0, substringLength - digits) + procent + "%" + progressBar.Substring(substringLength + 3);
        }
    }
}
