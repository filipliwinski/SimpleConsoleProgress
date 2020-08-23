using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SimpleConsoleProgress.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var total = 20;
            var timer = new Stopwatch();

            Console.WriteLine("SimpleConsoleProgress Demo");

            Console.WriteLine("\nSingle-line progress bar\n");
            for (int i = 0; i < total; i++)
            {
                Task.Delay(40).Wait();
                ProgressBar.Write(i, total);
            }
            Console.WriteLine("Process completed.");

            Console.WriteLine("\nMultiline progress bar\n");
            for (int i = 0; i < total; i++)
            {
                Task.Delay(40).Wait();
                ProgressBar.WriteLine(i, total);
            }
            Console.WriteLine("Process completed.");

            Console.WriteLine("\nShow elapsed time\n");
            timer.Start();
            for (int i = 0; i < total; i++)
            {
                Task.Delay(40).Wait();
                ProgressBar.Write(i, total, timer.Elapsed);
            }
            Console.WriteLine("Process completed.");
            timer.Reset();

            Console.WriteLine("\nCustom progress indicator\n");
            for (int i = 0; i < total; i++)
            {
                Task.Delay(40).Wait();
                ProgressBar.Write(i, total, character: '>');
            }
            Console.WriteLine("Process completed.");

            Console.WriteLine("\nAutohide progress bar (single-line)\n");
            for (int i = 0; i < total; i++)
            {
                Task.Delay(40).Wait();
                ProgressBar.Write(i, total, autoHide: true);
            }
            Console.WriteLine("Process completed.");
        }
    }
}
