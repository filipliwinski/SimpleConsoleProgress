# SimpleConsoleProgress

Simple progress indicator for .NET console projects.

[![Build Status](https://filipliwinski.visualstudio.com/SimpleConsoleProgress/_apis/build/status/SimpleConsoleProgress?branchName=master)](https://filipliwinski.visualstudio.com/SimpleConsoleProgress/_build/latest?definitionId=2&branchName=master)

Download from [NuGet](https://www.nuget.org/packages/SimpleConsoleProgress/).

## How to use

    using SimpleConsoleProgress;

### Single-line progress bar

Progress bar is updating in a single line. Use it if the progress is the only output in the process.

<img src="./assets/img/singleLine.gif?raw=true"/>

    var total = 20;
    for (int i = 0; i < total; i++)
    {
        ProgressBar.Write(i, total);
    }

### Multiline progress bar

Each progress update is written on a new line.

<img src="./assets/img/multiline.gif?raw=true"/>

    var total = 20;
    for (int i = 0; i < total; i++)
    {
        ProgressBar.WriteLine(i, total);
    }

### Options

#### Show elapsed time

You can provide a `TimeSpan` object with the time to show next to the progress bar. SimpleConsoleProgress does not include any timers, to be as simple as possible.

<img src="./assets/img/elapsedTime.gif?raw=true"/>

    var total = 20;
    var timer = new Stopwatch();
    timer.Start();

    for (int i = 0; i < total; i++)
    {
        ProgressBar.Write(i, total, timer.Elapsed);
    }

#### Customize progress indicator

By default, '#' is used as a progress indicator. You can change it with any character you want.

<img src="./assets/img/customIndicator.gif?raw=true"/>

    var total = 20;
    for (int i = 0; i < total; i++)
    {
        ProgressBar.WriteLine(i, total);
        ProgressBar.WriteLine(i, total, null, 'o');
        ProgressBar.WriteLine(i, total, null, '_');
        ProgressBar.WriteLine(i, total, null, '>');
    }

#### Auto hide progress bar (single-line)

By default, single-line progress bar persists in the output. You can hide it when it completes.

<img src="./assets/img/autoHide.gif?raw=true"/>

    var total = 20;
    for (int i = 0; i < total; i++)
    {
        ProgressBar.WriteLine(i, total, null, '#', true);
    }