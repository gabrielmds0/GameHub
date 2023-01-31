
using System;
using Newtonsoft.Json;
using System.IO;
using GameHub;
namespace GameHub
{
    class Program

    {
        static void Main(string[] args)
        {
            TicTacToe game = new TicTacToe();
            Console.WriteLine("1. Play Tic Tac Toe");
            Console.WriteLine("2. Show Player Profile");
            int option = int.Parse(Console.ReadLine());
            if (option == 1)
            {
                game.Play();
            }
            else if (option == 2)
            {
                Console.WriteLine("Enter the name of the player\n");
                string nome = Console.ReadLine();
                game.CheckProfile(nome);
            }
        }


    }
}