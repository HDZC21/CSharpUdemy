using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntermediateExercises
{
  public class Section2
  {
    // Exercise 1: Design a Stopwatch
    /*
    Design a class called Stopwatch. The job of this class is to simulate a stopwatch. It should
    provide two methods: Start and Stop. We call the start method first, and the stop method next.
    Then we ask the stopwatch about the duration between start and stop. Duration should be a
    value in TimeSpan. Display the duration on the console.
    We should also be able to use a stopwatch multiple times. So we may start and stop it and then
    start and stop it again. Make sure the duration value each time is calculated properly.
    We should not be able to start a stopwatch twice in a row (because that may overwrite the initial
    start time). So the class should throw an InvalidOperationException if its started twice.
    [Educational tip]: The aim of this exercise is to make you understand that a class should be
    always in a valid state. We use encapsulation and information hiding to achieve that. The class
    should not reveal its implementation detail. It only reveals a little bit, like a blackbox. From the
    outside, you should not be able to misuse a class because you shouldn’t be able to see the
    implementation detail. 
    */
    public void ExerciseOne()
    {
      Stopwatch stopwatch = new Stopwatch();
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

    // Exercise 2: Design a StackOverflow Post
    /*
    Design a class called Post. This class models a StackOverflow post. It should have properties
    for title, description and the date/time it was created. We should be able to up-vote or down-vote
    a post. We should also be able to see the current vote value. In the main method, create a post,
    up-vote and down-vote it a few times and then display the the current vote value.
    In this exercise, you will learn that a StackOverflow post should provide methods for up-voting
    and down-voting. You should not give the ability to set the Vote property from the outside,
    because otherwise, you may accidentally change the votes of a class to 0 or to a random
    number. And this is how we create bugs in our programs. The class should always protect its
    state and hide its implementation detail.
    [Educational tip]: The aim of this exercise is to help you understand that classes should
    encapsulate data AND behaviour around that data. Many developers (even those with years of
    experience) tend to create classes that are purely data containers, and other classes that are
    purely behaviour (methods) providers. This is not object-oriented programming. This is
    procedural programming. Such programs are very fragile. Making a change breaks many parts
    of the code.
    */
    public void ExerciseTwo()
    {
      Post newPost = new Post("myPost", "This is my new post");
      newPost.Vote("up");
      newPost.Vote("up");
      newPost.Vote("up");
      newPost.Vote("down");

      Console.WriteLine("Post: Title: " + newPost.Title + ", Description: " + newPost.Description + ", Vote Count: " + newPost.GetVoteCount());
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

  public class Post
  {
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreateTime { get; private set; }

    private int voteCount;

    public Post()
    {
      CreateTime = DateTime.Now;
      voteCount = 0;
    }

    public Post(string title, string description)
      :this()
    {
      Title = title;
      Description = description;
    }

    public void Vote(string vote)
    {
      switch (vote)
      {
        case "up":
        {
          voteCount++;
          break;
        }
        case "down":
        {
          voteCount--;
          break;
        }
        default:
        {
          Console.WriteLine("Not a valid vote.");
          break;
        }
      }
    }

    public int GetVoteCount()
    {
      return voteCount;
    }
  }
}
