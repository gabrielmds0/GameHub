using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace GameHub {
    class TicTacToe
    {
        private string[,] board = new string[3, 3];
        private List<Player> players = new List<Player>();
        private string filePath = @"C:\Users\gabri\Downloads\players.json";

        public TicTacToe()
        {
            LoadPlayers();
        }

        public void Play()
        {
            Console.WriteLine("Enter player X name: ");
            string playerX = Console.ReadLine();
            Player player1 = players.Find(x => x.Name == playerX);
            if (player1 == null)
            {
                player1 = new Player(playerX);
                players.Add(player1);
            }
            Console.WriteLine("Enter player O name: ");
            string playerO = Console.ReadLine();
            Player player2 = players.Find(x => x.Name == playerO);
            if (player2 == null)
            {
                player2 = new Player(playerO);
                players.Add(player2);
            }

            string currentPlayer = "X";
            int moves = 0;
            while (true)
            {
                Console.WriteLine("Current board state: ");
                PrintBoard();
                Console.WriteLine(currentPlayer + "'s turn. Enter row and column (e.g. 0 1): ");
                int row = int.Parse(Console.ReadLine());
                int col = int.Parse(Console.ReadLine());
                if (row < 0 || row > 2 || col < 0 || col > 2)
                {
                    Console.WriteLine("Invalid move. Try again.");
                    continue;
                }
                if (!string.IsNullOrEmpty(board[row, col]))
                {
                    Console.WriteLine("Place already filled. Try again.");
                    continue;
                }
                board[row, col] = currentPlayer;
                moves++;
                if (moves >= 5)
                {
                    if (IsWinner(row, col))
                    {
                        Console.WriteLine(currentPlayer + " wins!");
                        if (currentPlayer == "X")
                        {
                            player1.Wins++;
                            player2.Losses++;
                        }
                        else
                        {
                            player2.Wins++;
                            player1.Losses++;
                        }
                        SavePlayers();
                        Console.WriteLine("Do you want to play again? (y/n)");
                        string playAgain = Console.ReadLine();
                        if (playAgain == "y")
                        {
                            ResetBoard();
                            moves = 0;
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else if (moves == 9)
                    {
                        Console.WriteLine("It's a draw!");
                        Console.WriteLine("Do you want to play again? (y/n)");
                        string playAgain = Console.ReadLine();
                        if (playAgain == "y")
                        {
                            ResetBoard();
                            moves = 0;
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                if (currentPlayer == "X")
                {
                    currentPlayer = "O";
                }
                else
                {
                    currentPlayer = "X";
                }
            }
        }

        private void ResetBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = "";
                }
            }
        }

        private void PrintBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(board[i, j] + " | ");
                }
                Console.WriteLine();
            }
        }

        private bool IsWinner(int row, int col)
        {
            return (board[0, col] == board[1, col] && board[1, col] == board[2, col]) ||
                   (board[row, 0] == board[row, 1] && board[row, 1] == board[row, 2]) ||
                   (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && row == col) ||
                   (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0] && row + col == 2);
        }

        private void LoadPlayers()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                players = JsonConvert.DeserializeObject<List<Player>>(json);
            }
        }

        private void SavePlayers()
        {
            string json = JsonConvert.SerializeObject(players, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public void CheckProfile(string name)
        {
            Player player = players.Find(x => x.Name == name);
            if (player == null)
            {
                Console.WriteLine("Player not found.");
                return;
            }
            Console.WriteLine("Name: " + player.Name);
            Console.WriteLine("Wins: " + player.Wins);
            Console.WriteLine("Losses: " + player.Losses);
        }
    }

   


}
    

