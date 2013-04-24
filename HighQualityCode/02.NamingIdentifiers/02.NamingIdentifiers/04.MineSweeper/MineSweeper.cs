namespace _04.MineSweeper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MineSweeper
    {
        public class GameScore
        {
            string name;
            int score;

            public string Name
            {
                get
                {
                    return this.name;
                }

                set
                {
                    this.name = value;
                }
            }

            public int Score
			{
                get
                {
                    return this.score;
                }

                set
                {
                    this.score = value;
                }
            }
            
            public GameScore() { }

            public GameScore(string name, int score)
            {
                this.name = name;
                this.score = score;
            }
        }

        static void Main(string[] args)
        {
            string gameCommand = string.Empty;
            char[,] gameBoard = CreateGameBoard();
            char[,] bombs = CreateBombs();
            int counter = 0;
            bool bombActivated = false;
            List<GameScore> highScores = new List<GameScore>(6);
            int row = 0;
            int column = 0;
            bool showGameMenu = true;
            const int Max = 35;
            bool gameWon = false;

            do
            {
                if (showGameMenu)
                {
                    Console.WriteLine("Hajde da igraem na “Mini4KI”. Probvaj si kasmeta da otkriesh poleteta bez mini4ki." +
                    " Komanda 'top' pokazva klasiraneto, 'restart' po4va nova igra, 'exit' izliza i hajde 4ao!");
                    ShowBombs(gameBoard);
                    showGameMenu = false;
				}

                Console.Write("Daj red i kolona : ");
                gameCommand = Console.ReadLine().Trim();
                if (gameCommand.Length >= 3)
                {
                    if (int.TryParse(gameCommand[0].ToString(), out row) &&
                    int.TryParse(gameCommand[2].ToString(), out column) &&
                    	row <= gameBoard.GetLength(0) && column <= gameBoard.GetLength(1))
                    {
                    	gameCommand = "turn";
                    }

                }
                switch (gameCommand)
                {
                    case "top":
                        HighScores(highScores);
                        break;
                    case "restart":
                        gameBoard = CreateGameBoard();
                        bombs = CreateBombs();
                        ShowBombs(gameBoard);
                        bombActivated = false;
                        showGameMenu = false;
                        break;
                    case "exit":
                        Console.WriteLine("4a0, 4a0, 4a0!");
                        break;
                    case "turn":
                        if (bombs[row, column] != '*')
                        {
                            if (bombs[row, column] == '-')
							{
								MakeTurn(gameBoard, bombs, row, column);
								counter++;
							}

							if (Max == counter)
							{
								gameWon = true;
							}
							else
							{
								ShowBombs(gameBoard);
							}
						}
						else
						{
							bombActivated = true;
						}

						break;
					default:
						Console.WriteLine("\nGreshka! nevalidna Komanda\n");
						break;
				}
				if (bombActivated)
				{
					ShowBombs(bombs);
					Console.Write("\nHrrrrrr! Umria gerojski s {0} to4ki. " +
						"Daj si niknejm: ", counter);
					string nickName = Console.ReadLine();
					GameScore t = new GameScore(nickName, counter);
					if (highScores.Count < 5)
					{
						highScores.Add(t);
					}
					else
					{
						for (int i = 0; i < highScores.Count; i++)
						{
							if (highScores[i].Score < t.Score)
							{
								highScores.Insert(i, t);
								highScores.RemoveAt(highScores.Count - 1);
								break;
							}

						}
					}
					highScores.Sort((GameScore r1, GameScore r2) => r2.Name.CompareTo(r1.Name));
					highScores.Sort((GameScore r1, GameScore r2) => r2.Score.CompareTo(r1.Score));
					HighScores(highScores);

					gameBoard = CreateGameBoard();
					bombs = CreateBombs();
					counter = 0;
					bombActivated = false;
					showGameMenu = true;
				}

				if (gameWon)
				{
					Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
					ShowBombs(bombs);
					Console.WriteLine("Daj si imeto, batka: ");
					string name = Console.ReadLine();
					GameScore score = new GameScore(name, counter);
					highScores.Add(score);
					HighScores(highScores);
					gameBoard = CreateGameBoard();
					bombs = CreateBombs();
					counter = 0;
					gameWon = false;
					showGameMenu = true;
				}
			}
			while (gameCommand != "exit");
			Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
			Console.WriteLine("AREEEEEEeeeeeee.");
			Console.Read();
		}

		private static void HighScores(List<GameScore> score)
		{
			Console.WriteLine("\nTo4KI:");
			if (score.Count > 0)
			{
				for (int i = 0; i < score.Count; i++)
				{
					Console.WriteLine("{0}. {1} --> {2} kutii",
						i + 1, score[i].Name, score[i].Score);
				}
				Console.WriteLine();
			}
			else
			{
				Console.WriteLine("prazna klasaciq!\n");
			}
		}

		private static void MakeTurn(char[,] field,
			char[,] bombs, int row, int column)
		{
			char kolkoBombi = GetBombsCount(bombs, row, column);
			bombs[row, column] = kolkoBombi;
			field[row, column] = kolkoBombi;
		}

		private static void ShowBombs(char[,] board)
		{
			int boardRows = board.GetLength(0);
			int boardColumns = board.GetLength(1);
			Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
			Console.WriteLine("   ---------------------");
			for (int i = 0; i < boardRows; i++)
			{
				Console.Write("{0} | ", i);
				for (int j = 0; j < boardColumns; j++)
				{
					Console.Write(string.Format("{0} ", board[i, j]));
				}

				Console.Write("|");
				Console.WriteLine();
			}

			Console.WriteLine("   ---------------------\n");
		}

		private static char[,] CreateGameBoard()
		{
			int boardRows = 5;
			int boardColumns = 10;
			char[,] gameBoard = new char[boardRows, boardColumns];
			for (int i = 0; i < boardRows; i++)
			{
				for (int j = 0; j < boardColumns; j++)
				{
					gameBoard[i, j] = '?';
				}
			}

			return gameBoard;
		}

		private static char[,] CreateBombs()
		{
			int boardRows = 5;
			int boardColumns = 10;
			char[,] gameBoard = new char[boardRows, boardColumns];

			for (int i = 0; i < boardRows; i++)
			{
				for (int j = 0; j < boardColumns; j++)
				{
					gameBoard[i, j] = '-';
				}
			}

			List<int> randomValues = new List<int>();
			while (randomValues.Count < 15)
			{
				Random random = new Random();
				int randomValue = random.Next(50);
				if (!randomValues.Contains(randomValue))
				{
					randomValues.Add(randomValue);
				}
			}

			foreach (int randomValue in randomValues)
			{
				int column = (randomValue / boardColumns);
				int row = (randomValue % boardColumns);
				if (row == 0 && randomValue != 0)
				{
					column--;
					row = boardColumns;
				}
				else
				{
					row++;
				}
				gameBoard[column, row - 1] = '*';
			}

			return gameBoard;
		}

		private static char GetBombsCount(char[,] gameBoard, int currentRow, int currentColumn)
		{
			int bombsCount = 0;
			int boardRows = gameBoard.GetLength(0);
			int boardColumns = gameBoard.GetLength(1);

			if (currentRow - 1 >= 0)
			{
				if (gameBoard[currentRow - 1, currentColumn] == '*')
				{ 
					bombsCount++; 
				}

			}
			if (currentRow + 1 < boardRows)
			{
				if (gameBoard[currentRow + 1, currentColumn] == '*')
				{ 
					bombsCount++; 
				}
			}
			if (currentColumn - 1 >= 0)
			{
				if (gameBoard[currentRow, currentColumn - 1] == '*')
				{ 
					bombsCount++;
				}
			}
			if (currentColumn + 1 < boardColumns)
			{
				if (gameBoard[currentRow, currentColumn + 1] == '*')
				{ 
					bombsCount++;
				}
			}
			if ((currentRow - 1 >= 0) && (currentColumn - 1 >= 0))
			{
				if (gameBoard[currentRow - 1, currentColumn - 1] == '*')
				{ 
					bombsCount++; 
				}
			}
			if ((currentRow - 1 >= 0) && (currentColumn + 1 < boardColumns))
			{
				if (gameBoard[currentRow - 1, currentColumn + 1] == '*')
				{ 
					bombsCount++; 
				}
			}
			if ((currentRow + 1 < boardRows) && (currentColumn - 1 >= 0))
			{
				if (gameBoard[currentRow + 1, currentColumn - 1] == '*')
				{ 
					bombsCount++; 
				}
			}
			if ((currentRow + 1 < boardRows) && (currentColumn + 1 < boardColumns))
			{
				if (gameBoard[currentRow + 1, currentColumn + 1] == '*')
				{ 
					bombsCount++; 
				}
			}
			return char.Parse(bombsCount.ToString());
		}
	}
}
