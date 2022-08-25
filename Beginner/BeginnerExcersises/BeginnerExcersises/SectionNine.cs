using System;
using System.IO;

namespace BeginnerExcersises
{
  static public class Section9
  {
    /*
    Write a program that reads a text file and displays the number of words.
    */
    static public void ProblemOne()
    {
      string fileText = System.IO.File.ReadAllText(@"PathHere\TextResource.txt");
      string[] lines = fileText.Split(" ");
      Console.WriteLine("Number of Words: " + lines.Length);
    }

    /*
    Write a program that reads a text file and displays the longest word in the file.
    */
    static public void ProblemTwo()
    {
      string fileText = System.IO.File.ReadAllText(@"PathHere\TextResource.txt");
      string[] lines = fileText.Split(" ");

      int largestWordLength = 0;
      int tempLength = 0;
      string longestWord = "";

      foreach (var line in lines)
      {
        tempLength = line.Length;
        if ((line.Contains(".")) || (line.Contains(",")))
          tempLength--;

        if (tempLength > largestWordLength)
        {
          largestWordLength = tempLength;
          longestWord = line;
        }
      }

      Console.WriteLine("Problem Two: Longest Word: " + longestWord + ", Length: " + largestWordLength);
    }
  }
}
