using System;

namespace BeginnerExcersises
{
  static public class Section6
  {
    /*
    When you post a message on Facebook, depending on the number of people who like your post, 
    Facebook displays different information.
      - If no one likes your post, it doesn't display anything.
      - If only one person likes your post, it displays: [Friend's Name] likes your post.
      - If two people like your post, it displays: [Friend 1] and [Friend 2] like your post.
      - If more than two people like your post, it displays: [Friend 1], [Friend 2] and 
        [Number of Other People] others like your post.
    Write a program and continuously ask the user to enter different names, until the user presses 
    Enter (without supplying a name). Depending on the number of names provided, display a message 
    based on the above pattern. 
    */
    static public void ProblemOne()
    {
      var nameList = new List<string>();

      while (true)
      {
        Console.WriteLine("Enter a name or press Enter to finish:");
        var userInput = Console.ReadLine();

        if (String.IsNullOrWhiteSpace(userInput))
          break;

        nameList.Add(userInput);
      }

      int numOfNames = nameList.Count;
      switch (numOfNames)
      {
        case 0:
          break;

        case 1:
          Console.WriteLine($"{nameList[0]} likes your post.");
          break;

        case 2:
          Console.WriteLine($"{nameList[0]} and {nameList[1]} like your post.");
          break;

        default:
          Console.WriteLine($"{nameList[0]}, {nameList[1]} and {numOfNames - 2} others like your post.");
          break;
      }
    }

    /*
    Write a program and ask the user to enter their name. Use an array to reverse 
    the name and then store the result in a new string. Display the reversed name 
    on the console.
    */
    static public void ProblemTwo()
    {
      Console.WriteLine("Enter your name:");
      var userInput = Console.ReadLine();

      var reversedName = new char[userInput.Length];
      for (int i = 0; i < userInput.Length; i++)
        reversedName[i] = userInput[userInput.Length -1 - i];

      string name = new string(reversedName);
      Console.WriteLine("Problem 2: Reversed Name: " + name);
    }

    /*
    Write a program and ask the user to enter 5 numbers. If a number has been previously entered, 
    display an error message and ask the user to re-try. Once the user successfully enters 5 unique 
    numbers, sort them and display the result on the console.
    */
    static public void ProblemThree()
    {
      int[] numArray = new int[5];

      int counter = 0;

      while (counter < 5)
      {
        Console.WriteLine("Enter a unique number:");
        var inputBuffer = Console.ReadLine();
        var inputInt = int.Parse(inputBuffer);

        if (numArray.Contains(inputInt))
        {
          Console.WriteLine("That number already exists, try another.");
          continue;
        }

        numArray[counter] = inputInt;
        counter++;
      }

      Array.Sort(numArray);
      Console.WriteLine("Problem 3: Sorted Array:");
      foreach (var num in numArray)
        Console.Write($"{num}, ");
      Console.WriteLine();
    }

    /*
    Write a program and ask the user to continuously enter a number or type "Quit" to exit. 
    The list of numbers may include duplicates. Display the unique numbers that the user has entered.
    */
    static public void ProblemFour()
    {
      var userNums = new List<int>();

      while (true)
      {
        Console.WriteLine("Enter a number or type \"Quit\" to exit");
        var inputString = Console.ReadLine();

        if (inputString == "Quit")
          break;

        if (!userNums.Contains(int.Parse(inputString)))
          userNums.Add(int.Parse(inputString));
      }

      Console.WriteLine("Problem 4: Unique Numbers:");
      foreach (var num in userNums)
        Console.Write($"{num}, ");
      Console.WriteLine();
    }

    /*
    Write a program and ask the user to supply a list of comma separated numbers (e.g 5, 1, 9, 2, 10). 
    If the list is empty or includes less than 5 numbers, display "Invalid List" and ask the user to 
    re-try; otherwise, display the 3 smallest numbers in the list.
    */
    static public void ProblemFive()
    {
      var globalUserInputs = new List<int>();

      while (true)
      {
        Console.WriteLine("Enter a list of comma seperated values:");
        var userInput = Console.ReadLine();
        var userInputs = userInput.Split(',');

        if (userInputs.Length >= 5)
        {
          foreach (var input in userInputs)
            globalUserInputs.Add(int.Parse(input));
          break;
        }

        Console.WriteLine("Invalid list. Please try again");
      }

      globalUserInputs.Sort();

      Console.WriteLine("Problem 5: Smallest Three Numbers:");
      for (int i = 0; i < 3; i++)
        Console.Write($"{globalUserInputs[i]}, ");
      Console.WriteLine();
    }
  }
}
