# ConsoleProgress
Simple progress indicator for console .NET projects.

## How to use

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

<img src="/assets/img/progressbar.gif?raw=true"/>
