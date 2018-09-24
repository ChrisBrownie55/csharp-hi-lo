using System;
using System.Threading;

namespace hi_lo {
  public class Game {
    private Random RandomNumber = new Random();
    private bool Playing = true;

    public void Type(string output) {
      foreach (char c in output) {
        Thread.Sleep(50);
        Console.Write(c);
      }
    }

    public void TypeLine(string output) {
      Type(output);
      Console.Write('\n');
    }

    public Game() {
      Console.Clear();
      TypeLine("Welcome to HI-LO, I will choose a random number between 1 and 100 (inclusive), your job is to guess that number.");
      Thread.Sleep(500);

      while (Playing) {
        int randomGuess = RandomNumber.Next(1, 101);
        TypeLine("I've picked a number.");
        int guess = 0;

        while(guess != randomGuess) {
          guess = 0;
          while (guess < 1 || guess > 100) {
            Type("\nWhat's your guess? ");
            if (!Int32.TryParse(Console.ReadLine(), out guess) || guess < 1 || guess > 100) {
              TypeLine("Invalid guess: must be number between 1 and 100 (inclusive).");
            }
          }

          Type("Checking your guess");
          for (int i = 0; i < 3; ++i) {
            Thread.Sleep(250);
            Console.Write('.');
          }
          Console.Write('\n');

          if (guess == randomGuess) {
            TypeLine("You've done it!!!");
          } else {
            TypeLine($"You need to guess {(guess > randomGuess ? "lower" : "higher")}");
          }
        }

        Type("Do you wish to continue playing (Y/n): ");
        if (Console.ReadLine().ToUpper() == "N") {
          Playing = false;
          TypeLine("Goodbye.");
        }
      }
    }
  }
}