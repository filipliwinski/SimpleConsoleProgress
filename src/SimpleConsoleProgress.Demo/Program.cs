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

            Console.WriteLine("\nMultiline progress bar\n");
            for (int i = 0; i < total; i++)
            {
                Task.Delay(40).Wait();
                ProgressBar.WriteLine(i, total);
            }

            Console.WriteLine("\nShow elapsed time\n");
            timer.Start();
            for (int i = 0; i < total; i++)
            {
                Task.Delay(40).Wait();
                ProgressBar.Write(i, total, timer.Elapsed);
            }

            Console.WriteLine("\nCustomize progress indicator\n");
            timer.Start();
            for (int i = 0; i < total; i++)
            {
                Task.Delay(40).Wait();
                ProgressBar.Write(i, total, null, '>');
            }

            Console.WriteLine("\nAutohide progress bar (single-line)\n");
            timer.Start();
            for (int i = 0; i < total; i++)
            {
                Task.Delay(40).Wait();
                ProgressBar.Write(i, total, null, '#', true);
            }
        }
    }
}
