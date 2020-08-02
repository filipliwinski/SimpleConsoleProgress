using System;

namespace SimpleConsoleProgress
{
    public static class ProgressBar
    {
        /// <summary>
        /// Writes the specified value to the standard output stream as a progress bar.
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
            Progress(current, total, elapsed, true, character);
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
        /// Writes the specified value, followed by the current line terminator, to the standard output stream as a progress bar.
        /// </summary>
        /// <param name="current">Current item number (not the percentage).</param>
        /// <param name="total">Total number of items.</param>
        /// <param name="elapsed">Total time elapsed since the start of the process.</param>
        /// <param name="character">Character to show in the progress bar.</param>
        public static void WriteLine(int current, int total, TimeSpan? elapsed = null, char character = '#')
        {
            Progress(current, total, elapsed, false, character);
        }

        private static void Progress(int current, int total, TimeSpan? elapsed, bool singleLine, char character)
        {
            // Progress bar length equals console window with - brakets (2) - elapsed string length
            var length = Console.WindowWidth - 2 - (elapsed.HasValue ? GetElapsedString(elapsed.Value).Length : 0);
            if (total <= 0 || current < 0 || total < current)
            {
                Console.WriteLine("Unable to write progress bar...");
                return;
            }

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
                progressBar += GetElapsedString(elapsed.Value);
            }

            var digits = procent < 10 ? 1 : procent < 100 ? 2 : 3;
            var substringLength = length / 2;

            progressBar = progressBar.Substring(0, substringLength - digits) + procent + "%" + progressBar.Substring(substringLength + 3);

            if (singleLine)
            {
                Console.SetCursorPosition(0, Console.CursorTop);
            }
            else
            {
                progressBar += "\n";
            }

            Console.Write(progressBar);
        }

        private static string GetElapsedString(TimeSpan elapsed)
        {
            var format = elapsed.Hours > 0 ? "hh\\:mm\\:ss" : elapsed.Minutes > 0 ? "mm\\:ss" : elapsed.Seconds > 0 ? "mm\\:ss\\.fff" : "ss\\.fff";
            return $" {elapsed.ToString(format)}";
        }
    }
}
