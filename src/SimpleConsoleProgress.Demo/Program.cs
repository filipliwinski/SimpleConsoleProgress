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

            Console.WriteLine("ProgressBar.Write():");
            for (int i = 0; i < total; i++)
            {
                Task.Delay(40).Wait();
                ProgressBar.Write(i, total);
            }

            Console.WriteLine("ProgressBar.Write() with timer:");
            timer.Start();
            for (int i = 0; i < total; i++)
            {
                Task.Delay(40).Wait();
                ProgressBar.Write(i, total, timer.Elapsed);
            }

            Console.WriteLine("ProgressBar.WriteLine():");
            timer.Reset();
            timer.Start();
            for (int i = 0; i < total; i++)
            {
                Task.Delay(40).Wait();
                ProgressBar.WriteLine(i, total, timer.Elapsed);
            }
        }
    }
}
