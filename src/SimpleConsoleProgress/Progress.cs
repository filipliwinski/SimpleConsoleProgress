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
    /// <summary>
    /// Allows to write the progress to the standard output stream.
    /// </summary>
    public static class Progress
    {
        /// <summary>
        /// Writes the progress to the standard output stream.
        /// </summary>
        /// <param name="current">Current item number (not the percentage).</param>
        /// <param name="total">Total number of items.</param>
        /// <param name="elapsed">Total time elapsed since the start of the process.</param>
        /// <param name="autoHide">If true, the progress is removed upon completion.</param>
        public static void Write(int current, int total, TimeSpan? elapsed = null, bool autoHide = false)
        {
            if (current + 1 < total)
            {
                Console.CursorVisible = false;
            }
            var progress = GetProgress(current, total, elapsed);
            Console.Write(progress);
            Console.SetCursorPosition(Console.CursorLeft - progress.Length, Console.CursorTop);
            if (current + 1 >= total)
            {
                if (autoHide)
                {
                    // Clear console line
                    for (int i = 0; i < progress.Length; i++)
                    {
                        Console.Write(" ");
                    }
                    Console.SetCursorPosition(Console.CursorLeft - progress.Length, Console.CursorTop);
                }
                else
                {
                    Console.WriteLine();
                }
                Console.CursorVisible = true;
            }
        }

        /// <summary>
        /// Writes the progress, followed by the current line terminator, to the standard output stream.
        /// </summary>
        /// <param name="current">Current item number (not the percentage).</param>
        /// <param name="total">Total number of items.</param>
        /// <param name="elapsed">Total time elapsed since the start of the process.</param>
        public static void WriteLine(int current, int total, TimeSpan? elapsed = null)
        {
            Console.WriteLine(GetProgress(current, total, elapsed));
        }

        private static string GetProgress(int current, int total, TimeSpan? elapsed)
        {
            ProgressHelper.ValidateInputs(current, total);

            var procent = (current + 1) * 100 / total;

            var progress = procent + "%";

            progress = procent < 10 ? $"  {progress}" : procent < 100 ? $" {progress}" : $"{progress}";

            if (elapsed.HasValue)
            {
                progress += ProgressHelper.GetElapsedString(elapsed.Value);
            }

            return progress;
        }
    }
}
