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

            Console.WriteLine("\nPercent location: left\n");
            for (int i = 0; i < total; i++)
            {
                Task.Delay(40).Wait();
                
                ProgressBar.Write(i, total, location: PercentLocation.Left);
            }
            Console.WriteLine("Process completed.");

            Console.WriteLine("\nPercent location: right\n");
            for (int i = 0; i < total; i++)
            {
                Task.Delay(40).Wait();

                ProgressBar.Write(i, total, location: PercentLocation.Right);
            }
            Console.WriteLine("Process completed.");

            Console.WriteLine("\nPercent location: none\n");
            for (int i = 0; i < total; i++)
            {
                Task.Delay(40).Wait();

                ProgressBar.Write(i, total, location: PercentLocation.None);
            }
            Console.WriteLine("Process completed.");

            Console.WriteLine("\nAccuracy: 1\n");
            for (int i = 0; i < total; i++)
            {
                Task.Delay(40).Wait();

                ProgressBar.Write(i, total, accuracy: 1);
            }
            Console.WriteLine("Process completed.");

            Console.WriteLine("\nAccuracy: 2\n");
            for (int i = 0; i < total; i++)
            {
                Task.Delay(40).Wait();

                ProgressBar.Write(i, total, accuracy: 2);
            }
            Console.WriteLine("Process completed.");

            Console.WriteLine("\nAccuracy: 3\n");
            for (int i = 0; i < total; i++)
            {
                Task.Delay(40).Wait();

                ProgressBar.Write(i, total, accuracy: 3);
            }
            Console.WriteLine("Process completed.");
        }
    }
}
