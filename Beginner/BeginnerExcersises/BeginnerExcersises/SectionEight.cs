using System;
using System.Text;

namespace BeginnerExcersises
{
  static public class Section8
  {
    /*
    Write a program and ask the user to enter a few numbers separated by a hyphen. Work out 
    if the numbers are consecutive. For example, if the input is "5-6-7-8-9" or "20-19-18-17-16", 
    display a message: "Consecutive"; otherwise, display "Not Consecutive".
    */
    static public void ProblemOne()
    {
      Console.WriteLine("Enter a few numbers seperated by hyphens:");
      var userInput = Console.ReadLine();
      var splitInput = userInput.Split('-');

      var userInputNums = new List<int>();
      foreach (var num in splitInput)
        userInputNums.Add(int.Parse(num));

      // Check if consecutive
      bool isConsecutive = true;
      // false if decrementing, true if incrementing
      bool inc_dec = false;


      if (userInputNums.Count <= 1)
        Console.WriteLine("Consecutive.");
      else
      {
        if (userInputNums[1] > userInputNums[0])
          inc_dec = true;
        for (int i = 1; i < userInputNums.Count; i++)
        {
          if (inc_dec)
          {
            if (userInputNums[i] < userInputNums[i - 1])
              isConsecutive = false;
          }
          else
          {
            if (userInputNums[i] > userInputNums[i - 1])
              isConsecutive = false;
          }
        }
      }

      if (isConsecutive)
        Console.WriteLine("Consecutive.");
      else
        Console.WriteLine("Not Consecutive");
    }

    /*
    Write a program and ask the user to enter a few numbers separated by a hyphen. If the user 
    simply presses Enter, without supplying an input, exit immediately; otherwise, check to see 
    if there are duplicates. If so, display "Duplicate" on the console.
    */
    static public void ProblemTwo()
    {
      Console.WriteLine("Enter a few numbers seperated by hyphens:");
      var userInput = Console.ReadLine();

      if (String.IsNullOrWhiteSpace(userInput))
        return;

      var splitInput = userInput.Split('-');

      var userInputNums = new List<int>();
      foreach (var num in splitInput)
        if (userInputNums.Contains(int.Parse(num)))
        {
          Console.WriteLine("Duplicate.");
          return;
        }
        else
          userInputNums.Add(int.Parse(num));

      Console.WriteLine("No Duplicates.");
    }

    /*
    Write a program and ask the user to enter a time value in the 24-hour time format (e.g. 19:00). 
    A valid time should be between 00:00 and 23:59. If the time is valid, display "Ok"; otherwise, 
    display "Invalid Time". If the user doesn't provide any values, consider it as invalid time.
    */
    static public void ProblemThree()
    {
      Console.WriteLine("Enter a time in 24-hour time format:");
      var userInput = Console.ReadLine();

      if (String.IsNullOrWhiteSpace(userInput))
      {
        Console.WriteLine("Invalid Time.");
        return;
      }

      try
      {
        var inputTime = DateTime.Parse(userInput);
      }
      catch (FormatException e)
      {
        Console.WriteLine("Invalid Time.");
        return;
      }

      Console.WriteLine("Ok.");
    }

    /*
    Write a program and ask the user to enter a few words separated by a space. Use the words 
    to create a variable name with PascalCase. For example, if the user types: "number of students", 
    display "NumberOfStudents". Make sure that the program is not dependent on the input. So, if the 
    user types "NUMBER OF STUDENTS", the program should still display "NumberOfStudents".
    */
    static public void ProblemFour()
    {
      Console.WriteLine("Enter a few words seperated by spaces:");
      var userInput = Console.ReadLine();

      var splitInputs = userInput.Split(' ');
      var newInputs = new List<string>();
      
      foreach (var input in splitInputs)
      {
        StringBuilder tempString = new StringBuilder();
        tempString.Append(input.ToLower());
        tempString[0] = (char)(tempString[0] - 32);
        newInputs.Add(tempString.ToString());
      }

      var output = String.Join("", newInputs);
      Console.WriteLine("Problem Four: Pascal Case:");
      Console.WriteLine(output);
    }

    /*
    Write a program and ask the user to enter an English word. Count the number of vowels 
    (a, e, o, u, i) in the word. So, if the user enters "inadequate", the program should display 
    6 on the console.
    */
    static public void ProblemFive()
    {
      var vowels = new char[5] { 'a', 'e', 'i', 'o', 'u' };

      Console.WriteLine("Enter an English word:");
      var userInput = Console.ReadLine();

      int vowelCount = 0;
      foreach (var letter in userInput)
      {
        if (vowels.Contains(letter))
          vowelCount++;
      }

      Console.WriteLine("Problem Five: Vowel Count: " + vowelCount);
    }
  }
}
