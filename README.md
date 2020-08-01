# SimpleConsoleProgress
Simple progress indicator for .NET console projects.

[![Build Status](https://filipliwinski.visualstudio.com/ConsoleProgress/_apis/build/status/ConsoleProgress?branchName=master)](https://filipliwinski.visualstudio.com/ConsoleProgress/_build/latest?definitionId=1&branchName=master)

## How to use
    using SimpleConsoleProgress;

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

<img src="./assets/img/progressbar.gif?raw=true"/>
