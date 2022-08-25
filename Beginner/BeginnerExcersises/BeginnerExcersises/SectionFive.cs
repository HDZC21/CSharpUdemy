using System;

namespace BeginnerExcersises
{
  static public class Section5
  {
    /*
    Write a program to count how many numbers between 1 and 100 are divisible 
    by 3 with no remainder. Display the count on the console.
    */
    static public void ProblemOne()
    {
      int count = 0;
      for (int i = 1; i <= 100; i++)
      {
        if (i % 3 == 0)
          count++;
      }
      Console.WriteLine("Problem 1: Count: " + count);
    }

    /*
    Write a program and continuously ask the user to enter a number or "ok" to exit.
    Calculate the sum of all the previously entered numbers and display it on the console.
    */
    static public void ProblemTwo()
    {
      int sum = 0;
      while (true)
      {
        Console.WriteLine("Enter a number, or press Enter to exit:");
        var input = Console.ReadLine();

        if (String.IsNullOrWhiteSpace(input))
          break;

        sum += int.Parse(input);
      }

      Console.WriteLine("Problem 2: Sum: " + sum);
    }

    /*
    Write a program and ask the user to enter a number. Compute the factorial of the number and 
    print it on the console. For example, if the user enters 5, the program should calculate 
    5 x 4 x 3 x 2 x 1 and display it as 5! = 120.
    */
    static public void ProblemThree()
    {
      Console.WriteLine("Enter a number:");
      var input = int.Parse(Console.ReadLine());

      int factorial = input;

      for (int i = input - 1; i > 0; i--)
      {
        factorial *= i;
      }

      Console.WriteLine(String.Format("Problem 3: {0}! = {1}", input, factorial));
    }

    /*
    Write a program that picks a random number between 1 and 10. Give the user 4 chances to guess the 
    number. If the user guesses the number, display “You won"; otherwise, display “You lost". (To make 
    sure the program is behaving correctly, you can display the secret number on the console first.)
    */
    static public void ProblemFour()
    {
      Random random = new Random();
      int randomNumber = random.Next(1, 11);
      bool guessed = false;

      for (int i = 0; i < 4; i++)
      {
        Console.WriteLine("Guess the number:");
        var input = Console.ReadLine();
        if (int.Parse(input) == randomNumber)
        {
          Console.WriteLine("You Won!");
          guessed = true;
          break;
        }
      }

      if (!guessed)
        Console.WriteLine("You Lost. The number was " + randomNumber);
    }

    /*
    Write a program and ask the user to enter a series of numbers separated by comma. Find the maximum 
    of the numbers and display it on the console. For example, if the user enters “5, 3, 8, 1, 4", 
    the program should display 8. 
    */
    static public void ProblemFive()
    {
      Console.WriteLine("Enter a series of numbers seperated by a comma:");
      var input = Console.ReadLine();
      var splitInput = input.Split(',');

      var intArray = new int[splitInput.Length];
      for (int i = 0; i < splitInput.Length; i++)
      {
        intArray[i] = int.Parse(splitInput[i]);
      }

      Console.WriteLine("Problem 5: Max Value: " + intArray.Max());
    }
  }
}
