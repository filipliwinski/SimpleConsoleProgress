# SimpleConsoleProgress
Simple progress indicator for .NET console projects.

[![Build Status](https://filipliwinski.visualstudio.com/SimpleConsoleProgress/_apis/build/status/SimpleConsoleProgress?branchName=master)](https://filipliwinski.visualstudio.com/SimpleConsoleProgress/_build/latest?definitionId=2&branchName=master)

## How to use
    using SimpleConsoleProgress;

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

<img src="./assets/img/progressbar.gif?raw=true"/>
