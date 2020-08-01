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
        /// <param name="length">Length of the progress bar.</param>
        /// <param name="character">Character to show in the progress bar.</param>
        /// <param name="autoHide">If true, progress bar is removed after is completed.</param>
        public static void Write(int current, int total, byte length = 60, char character = '#', bool autoHide = false)
        {
            Progress(current, total, length, true, character);
            if (current + 1 == total)
            {
                if (autoHide)
                {
                    // Clear console line
                    Console.SetCursorPosition(0, Console.CursorTop);
                    if (length < 20) length = 20;
                    for (int i = 0; i < length + 2; i++)
                    {
                        Console.Write(" ");
                    }
                    Console.SetCursorPosition(0, Console.CursorTop);
                }
                else
                {
                    Console.WriteLine();
                }
            }
        }

        /// <summary>
        /// Writes the specified value, followed by the current line terminator, to the standard output stream as a progress bar.
        /// </summary>
        /// <param name="current">Current item number (not the percentage).</param>
        /// <param name="total">Total number of items.</param>
        /// <param name="length">Length of the progress bar.</param>
        /// <param name="character">Character to show in the progress bar.</param>
        public static void WriteLine(int current, int total, byte length = 60, char character = '#')
        {
            Progress(current, total, length, false, character);
        }

        private static void Progress(int current, int total, byte length, bool singleLine, char character)
        {
            if (length < 20) length = 20;
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
    }
}
