using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntermediateExcersises
{
  public class Section2
  {
    Stopwatch stopwatch;

    public Section2()
    {
      stopwatch = new Stopwatch();
    }

    public void RunStopwatch()
    {
      Console.WriteLine("Stowatch is running.");
      Console.WriteLine("Enter a command [start, stop, print, reset, quit]");
      bool isRunning = true;

      while (isRunning)
      {
        string userInput = Console.ReadLine();

        switch (userInput)
        {
          case "start":
            stopwatch.Start();
            break;

          case "stop":
            stopwatch.Stop();
            break;

          case "print":
            stopwatch.PrintDuration();
            break;

          case "reset":
            stopwatch.Reset();
            break;

          case "quit":
            isRunning = false;
            Console.WriteLine("Closing stopwatch.");
            break;

          default: 
            Console.WriteLine("Invalid input, try again.");
            break;
        }
      }
    }


  }

  public class Stopwatch
  {
    private DateTime _startTime;
    private DateTime _stopTime;
    private bool _isStarted;
    private bool _isReset;

    public Stopwatch()
    {
      _startTime = new DateTime();
      _stopTime = new DateTime();
      _isStarted = false;
      _isReset = true;
    }
    public void Start()
    {
      if (!_isStarted && _isReset)
      {
        _isStarted = true;
        _isReset = false;
        _startTime = DateTime.Now;
        Console.WriteLine("Stopwatch started.");
        return;
      }
      else if (!_isStarted && !_isReset)
      {
        _isStarted = true;
        Console.WriteLine("Stopwatch restarted.");
        return;
      }

      throw new InvalidOperationException(message: "Stopwatch already started.");
    }

    public void Stop()
    {
      if (_isStarted)
      {
        _isStarted = false;
        _stopTime = DateTime.Now;
        Console.WriteLine("Stopwatch stopped.");
        return;
      }

      Console.WriteLine("Stopwatch is not currently running.");
    }

    public void Reset()
    {
      if (!_isStarted)
      {
        _isReset = true;
        Console.WriteLine("Stopwatch reset.");
        return;
      }

      Console.WriteLine("Cannot reset while stopwatch is running.");
    }

    public void PrintDuration()
    {
      if (!_isStarted)
      {
        Console.WriteLine("Current duration: " + (_stopTime - _startTime));
        return;
      }

      Console.WriteLine("Cannot print while stopwatch is running.");

    }
  }
}
