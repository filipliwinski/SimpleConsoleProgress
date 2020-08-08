using System;

namespace SimpleConsoleProgress
{
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
            if (total <= 0)
            {
                throw new ArgumentException("Unable to write progress. Total below zero.");
            }
            if (current < 0)
            {
                throw new ArgumentException("Unable to write progress. Current below zero.");
            }
            if (total < current)
            {
                throw new ArgumentException("Unable to write progress. Total less than current.");
            }

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
