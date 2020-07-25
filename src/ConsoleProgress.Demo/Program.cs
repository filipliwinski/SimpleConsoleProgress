using System;
using System.Threading.Tasks;

namespace ConsoleProgress.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var total = 20;

            Console.WriteLine("ConsoleProgress Demo");

            Console.WriteLine("ProgressBar.Write():");
            for (int i = 0; i < total; i++)
            {
                Task.Delay(40).Wait();
                ProgressBar.Write(i, total);
            }

            Console.WriteLine("ProgressBar.WriteLine():");
            for (int i = 0; i < total; i++)
            {
                Task.Delay(40).Wait();
                ProgressBar.WriteLine(i, total);
            }
        }
    }
}
