using System.Security.Cryptography;
using System.Data;
using System;

namespace csharp_task3
{
    class Program
    {
        static void Main(string[] args)
        {
            string level;
            int guess_limit;
            int max_number;
            int secret_number;
            bool game_over = false;

            Random rnd = new Random();
            while(true){
                Console.Write("Choose your level (easy, medium or hard): ");
                level = Console.ReadLine();

                if ( level == "easy" ) {
                    guess_limit = 6;
                    max_number = 10;
                    secret_number =  rnd.Next(1, max_number);
                    break;
                } else if ( level == "medium" ) {
                    guess_limit = 4;
                    max_number = 20;
                    secret_number = rnd.Next(1, max_number);;
                    break;
                } else if ( level == "hard" ) {
                    guess_limit = 3;
                    max_number = 50;
                    secret_number = rnd.Next(1, max_number);;
                    break;
                } else {
                    continue;
                }
            }

            int guess_count = 1;
            while ( guess_count <= guess_limit ) {
                Console.Write("Guess the secret number from 1 - " + max_number + ": ");
                int guess = int.Parse(Console.ReadLine());
                if ( guess == secret_number ) {
                    Console.WriteLine("You got it right");
                    break;
                } else {
                    int remaining_guesses = guess_limit - guess_count;
                    if ( remaining_guesses > 0 ) {
                        Console.WriteLine("That was wrong. You have " + remaining_guesses + " guesses left");
                    } else {
                        game_over = true;
                    }
                    guess_count ++;
                }
            }
            
            if ( game_over ) {
                Console.WriteLine("Game Over!");
            }
        }
    }
}
