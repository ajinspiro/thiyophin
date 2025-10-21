// See https://aka.ms/new-console-template for more information
using System;
namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            int fixedNum = 2;
            int option;
            Console.WriteLine("Select one option --> [1] Fixed prediction and [2] Random prediction");
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Invalid option");
                    continue;
                }
                else if (option < 0 || option > 2)
                {
                    Console.WriteLine("Invalid option");
                    continue;
                }
                else
                {
                    break;
                }
            }
            if (option == 1)
            {
                Console.WriteLine("Enter the number between 1 and 9 : ");
                while (true)
                    if (!int.TryParse(Console.ReadLine(), out int guessNum))
                    {
                        Console.WriteLine("Invalid guess");
                        continue;
                    }
                    else if (guessNum < 0 || guessNum > 9)
                    {
                        Console.WriteLine("Invalid guess");
                        continue;
                    }
                    else
                    {
                        if (fixedNum == guessNum)
                        {
                            Console.WriteLine($"You won, the guessed number {guessNum} is correct !");
                        }
                        else
                        {
                            Console.WriteLine($"You lost!");
                        }
                        break;
                    }
            }
            else if (option == 2)
            {
                Random random = new();
                int randomNum = random.Next(1, 9);
                Console.WriteLine("Enter the number between 1 and 9 : ");
                while (true)
                    if (!int.TryParse(Console.ReadLine(), out int guessNum))
                    {
                        Console.WriteLine("Invalid guess");
                        continue;
                    }
                    else if (guessNum < 0 || guessNum > 9)
                    {
                        Console.WriteLine("Invalid guess");
                        continue;
                    }
                    else
                    {
                        if (randomNum == guessNum)
                        {
                            Console.WriteLine($"You won, the guessed number {guessNum} is correct !");
                        }
                        else
                        {
                            Console.WriteLine($"You lost! the correct number is {randomNum}");
                        }
                        break;
                    }

            }
        }
    }
}