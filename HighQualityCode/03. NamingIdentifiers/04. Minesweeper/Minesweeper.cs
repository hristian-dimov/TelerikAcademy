using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper
{
    public class Minesweeper
    {
        public class Score
        {
            private string name;
            private int points;

            public Score() 
            {
            }

            public Score(string name, int points)
            {
                this.Name = name;
                this.Points = points;
            }

            public string Name
            {
                get { return this.name; }
                set { this.name = value; }
            }

            public int Points
            {
                get { return this.points; }
                set { this.points = value; }
            }
        }

        public static void Main()
        {
            const int MaxScore = 35;

            List<Score> champions = new List<Score>(6);

            string command = string.Empty;
            char[,] board = CreateMineField();
            char[,] mineField = PlaceBombs();

            int score = 0;
            int row = 0;
            int col = 0;

            bool hitBomb = false;
            bool isNewGame = true;
            bool hasCompletedGame = false;

            do
            {
                if (isNewGame)
                {
                    Console.WriteLine("Lets play Minesweeper, try your luck finding the mines. The command \'top\' shows the Top Score, \'restart\' starts a New Game, \'exit\' quits the game!");
                    DisplayBoard(board);
                    isNewGame = false;
                }

                Console.Write("Enter row and colomn (separated by blankspace!) : ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                        int.TryParse(command[2].ToString(), out col) &&
                        row <= board.GetLength(0) && col <= board.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        TopScore(champions);
                        break;
                    case "restart":
                        board = CreateMineField();
                        mineField = PlaceBombs();
                        DisplayBoard(board);
                        hitBomb = false;
                        isNewGame = false;
                        break;
                    case "exit":
                        Console.WriteLine("Good bye!");
                        break;
                    case "turn":
                        if (mineField[row, col] != '*')
                        {
                            if (mineField[row, col] == '-')
                            {
                                NextTurn(board, mineField, row, col);
                                score++;
                            }

                            if (MaxScore == score)
                            {
                                hasCompletedGame = true;
                            }
                            else
                            {
                                DisplayBoard(board);
                            }
                        }
                        else
                        {
                            hitBomb = true;
                        }
                        break;
                    default:
                        Console.WriteLine("\nInvalid Command!\n");
                        break;
                }

                if (hitBomb)
                {
                    DisplayBoard(mineField);
                    Console.Write("\nBoom! You died. You have {0} points.", score);

                    Console.Write("Your nickname: ");
                    string name = Console.ReadLine();
                    Score playerScore = new Score(name, score);

                    if (champions.Count < 5)
                    {
                        champions.Add(playerScore);
                    }
                    else
                    {
                        for (int i = 0; i < champions.Count; i++)
                        {
                            if (champions[i].Points < playerScore.Points)
                            {
                                champions.Insert(i, playerScore);
                                champions.RemoveAt(champions.Count - 1);
                                break;
                            }
                        }
                    }

                    champions.Sort((Score first, Score second) => second.Name.CompareTo(first.Name));
                    champions.Sort((Score first, Score second) => second.Points.CompareTo(first.Points));
                    TopScore(champions);

                    board = CreateMineField();
                    mineField = PlaceBombs();
                    score = 0;
                    hitBomb = false;
                    isNewGame = true;
                }

                if (hasCompletedGame)
                {
                    Console.WriteLine("\nCongratulations, you won!");
                    DisplayBoard(mineField);
                    Console.WriteLine("Please enter your name: ");
                    string name = Console.ReadLine();
                    Score playerScores = new Score(name, score);
                    champions.Add(playerScores);
                    TopScore(champions);
                    board = CreateMineField();
                    mineField = PlaceBombs();
                    score = 0;
                    hasCompletedGame = false;
                    isNewGame = true;
                }
            } while (command != "exit");
            Console.Read();
        }

        private static void TopScore(List<Score> playerScore)
        {
            Console.WriteLine("\nPoints:");
            if (playerScore.Count > 0)
            {
                for (int i = 0; i < playerScore.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} points",
                        i + 1, playerScore[i].Name, playerScore[i].Points);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No scores were tracked yet!\n");
            }
        }

        private static void NextTurn(char[,] field, char[,] bombs, int row, int col)
        {
            char bombsCount = CountBombs(bombs, row, col);

            bombs[row, col] = bombsCount;
            field[row, col] = bombsCount;
        }

        private static void DisplayBoard(char[,] board)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateMineField()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];

            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] PlaceBombs()
        {
            int rows = 5;
            int cols = 10;
            char[,] board = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    board[i, j] = '-';
                }
            }

            List<int> bombsCoords = new List<int>();

            while (bombsCoords.Count < 15)
            {
                Random random = new Random();
                int bombPlace = random.Next(50);
                if (!bombsCoords.Contains(bombPlace))
                {
                    bombsCoords.Add(bombPlace);
                }
            }

            foreach (int bomb in bombsCoords)
            {
                int col = (bomb / cols);
                int row = (bomb % cols);

                if (row == 0 && bomb != 0)
                {
                    col--;
                    row = cols;
                }
                else
                {
                    row++;
                }

                board[col, row - 1] = '*';
            }

            return board;
        }

        private static char CountBombs(char[,] field, int row, int col)
        {
            int bombsCount = 0;
            int rows = field.GetLength(0);
            int cols = field.GetLength(1);

            if (row - 1 >= 0)
            {
                if (field[row - 1, col] == '*')
                {
                    bombsCount++;
                }
            }
            if (row + 1 < rows)
            {
                if (field[row + 1, col] == '*')
                {
                    bombsCount++;
                }
            }
            if (col - 1 >= 0)
            {
                if (field[row, col - 1] == '*')
                {
                    bombsCount++;
                }
            }
            if (col + 1 < cols)
            {
                if (field[row, col + 1] == '*')
                {
                    bombsCount++;
                }
            }
            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (field[row - 1, col - 1] == '*')
                {
                    bombsCount++;
                }
            }
            if ((row - 1 >= 0) && (col + 1 < cols))
            {
                if (field[row - 1, col + 1] == '*')
                {
                    bombsCount++;
                }
            }
            if ((row + 1 < rows) && (col - 1 >= 0))
            {
                if (field[row + 1, col - 1] == '*')
                {
                    bombsCount++;
                }
            }
            if ((row + 1 < rows) && (col + 1 < cols))
            {
                if (field[row + 1, col + 1] == '*')
                {
                    bombsCount++;
                }
            }
            return char.Parse(bombsCount.ToString());
        }
    }
}