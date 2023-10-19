// MIT License
//  
//  Copyright (c) 2020-2023 Filip Liwiński
//  
//  Licensed under the MIT License. See the LICENSE file in the project root for license information.
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
        public static void Write(int current, int total, TimeSpan? elapsed = null, bool autoHide = false, int accuracy = 0)
        {
            if (current + 1 < total)
            {
                Console.CursorVisible = false;
            }
            var progress = GetProgress(current, total, elapsed, accuracy);
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
        public static void WriteLine(int current, int total, TimeSpan? elapsed = null, int accuracy = 0)
        {
            Console.WriteLine(GetProgress(current, total, elapsed, accuracy));
        }

        private static string GetProgress(int current, int total, TimeSpan? elapsed, int accuracy)
        {
            var accuracyLevel = ProgressHelper.SetAccuracy(accuracy);

            var progressValue = ProgressHelper.GetProgressValue(current, total);

            var progressString = ProgressHelper.GetProgressString(progressValue, PercentLocation.Middle, accuracyLevel);

            if (elapsed.HasValue)
            {
                progressString += ProgressHelper.GetElapsedString(elapsed.Value);
            }

            return progressString;
        }
    }
}
