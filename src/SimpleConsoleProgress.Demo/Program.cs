// MIT License
//  
//  Copyright (c) 2020-2023 Filip Liwiński
//  
//  Licensed under the MIT License. See the LICENSE file in the project root for license information.
//

using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SimpleConsoleProgress.Demo
{
    static class Program
    {
        static void Main(string[] args)
        {
            var total = 20;
            var delay = 40;
            var timer = new Stopwatch();

            Console.WriteLine("SimpleConsoleProgress Demo");

            Console.WriteLine("\nSingle-line progress bar\n");
            for (int i = 0; i < total; i++)
            {
                Task.Delay(delay).Wait();
                ProgressBar.Write(i, total);
            }
            Console.WriteLine("Process completed.");

            Console.WriteLine("\nMultiline progress bar\n");
            for (int i = 0; i < total; i++)
            {
                Task.Delay(delay).Wait();
                ProgressBar.WriteLine(i, total);
            }
            Console.WriteLine("Process completed.");

            Console.WriteLine("\nNo progress bar\n");
            for (int i = 0; i < total; i++)
            {
                Task.Delay(delay).Wait();
                Progress.Write(i, total);
            }
            Console.WriteLine("Process completed.");

            Console.WriteLine("\nShow elapsed time\n");
            timer.Start();
            for (int i = 0; i < total; i++)
            {
                Task.Delay(delay).Wait();
                ProgressBar.Write(i, total, timer.Elapsed);
            }
            Console.WriteLine("Process completed.");
            timer.Reset();

            Console.WriteLine("\nCustom progress indicator\n");
            for (int i = 0; i < total; i++)
            {
                Task.Delay(delay).Wait();
                ProgressBar.Write(i, total, character: '>');
            }
            Console.WriteLine("Process completed.");

            Console.WriteLine("\nAutohide progress bar (single-line)\n");
            for (int i = 0; i < total; i++)
            {
                Task.Delay(delay).Wait();
                ProgressBar.Write(i, total, autoHide: true);
            }
            Console.WriteLine("Process completed.");

            Console.WriteLine("Size: Small\n");
            for (int i = 0; i < total; i++)
            {
                Task.Delay(delay).Wait();
                ProgressBar.Write(i, total, size: BarSize.Small);
            }
            Console.WriteLine("Process completed.");

            Console.WriteLine("Size: Medium\n");
            for (int i = 0; i < total; i++)
            {
                Task.Delay(delay).Wait();
                ProgressBar.Write(i, total, size: BarSize.Medium);
            }
            Console.WriteLine("Process completed.");

            Console.WriteLine("Size: Big\n");
            for (int i = 0; i < total; i++)
            {
                Task.Delay(delay).Wait();
                ProgressBar.Write(i, total, size: BarSize.Big);
            }
            Console.WriteLine("Process completed.");

            Console.WriteLine("Size: Full\n");
            for (int i = 0; i < total; i++)
            {
                Task.Delay(delay).Wait();
                ProgressBar.Write(i, total, size: BarSize.Full);
            }
            Console.WriteLine("Process completed.");

            Console.WriteLine("\nPercent location: left\n");
            for (int i = 0; i < total; i++)
            {
                Task.Delay(delay).Wait();
                ProgressBar.Write(i, total, location: PercentLocation.Left);
            }
            Console.WriteLine("Process completed.");

            Console.WriteLine("\nPercent location: right\n");
            for (int i = 0; i < total; i++)
            {
                Task.Delay(delay).Wait();

                ProgressBar.Write(i, total, location: PercentLocation.Right);
            }
            Console.WriteLine("Process completed.");

            Console.WriteLine("\nPercent location: none\n");
            for (int i = 0; i < total; i++)
            {
                Task.Delay(delay).Wait();
                ProgressBar.Write(i, total, location: PercentLocation.None);
            }
            Console.WriteLine("Process completed.");

            Console.WriteLine("\nAccuracy: 1\n");
            for (int i = 0; i < total; i++)
            {
                Task.Delay(delay).Wait();
                ProgressBar.Write(i, total, accuracy: 1);
            }
            Console.WriteLine("Process completed.");

            Console.WriteLine("\nAccuracy: 2\n");
            for (int i = 0; i < total; i++)
            {
                Task.Delay(delay).Wait();
                ProgressBar.Write(i, total, accuracy: 2);
            }
            Console.WriteLine("Process completed.");

            Console.WriteLine("\nAccuracy: 3\n");
            for (int i = 0; i < total; i++)
            {
                Task.Delay(delay).Wait();
                ProgressBar.Write(i, total, accuracy: 3);
            }
            Console.WriteLine("Process completed.");

            Console.WriteLine("\n\n\n\n");
        }
    }
}
