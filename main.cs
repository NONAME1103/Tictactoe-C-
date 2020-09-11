using System;
using static System.Console;

class MainClass {
  public static void Main (string[] args) {
    Tictactoe();
    WriteLine ("\nGame Over!");
  }
  public static void Tictactoe() {
    string[,] board = new string[,] {
            {"free", "free", "free"},
            {"free", "free", "free"},
            {"free", "free", "free"} };
    Random random = new Random(); 
    bool gameOver = false;
    string player, row, cell;
    int[] move = new int[2] {3, 3};
    while (!gameOver) {
      PrintBoard(board);
      player = "  X ";
      bool first = true;
      while (!ValidMove(board, move, first)) {
        first = false;
        Write("Choose a row (1 - 3): ");
        row = ReadLine();
        Write ("Choose a cell (1 - 3): ");
        cell = ReadLine();
        move[0] = Convert.ToInt32(row) - 1;
        move[1] = Convert.ToInt32(cell) - 1;
      }
      board[move[0], move[1]] = player;
      gameOver = CheckGameOver(board);
      if (gameOver) {
        WriteLine("\n\nYou win!");
        break;
      }
      player = "  O ";
      move[0] = 3;
      move[1] = 3;
      while (!ValidMove(board, move, true)) {
        row = Convert.ToString(random.Next(0,2));
        cell = Convert.ToString(random.Next(0,2));
        move[0] = Convert.ToInt32(row);
        move[1] = Convert.ToInt32(cell);
      }
      board[move[0], move[1]] = player;
      gameOver = CheckGameOver(board);
      if (gameOver) {
        WriteLine("\n\nYou lose!");
      }
    }
  }
  public static void PrintBoard (string[,] board) {
    WriteLine();
    for (int row = 0; row <= 2; row++) {
      for (int cell = 0; cell <= 2; cell++) {
        Write(" " + board[row, cell]);
        if (cell != 2) {
          Write(" |");
        }
      }
      WriteLine();
      if (row != 2) {
        WriteLine("------|------|------");
      }
    }
    WriteLine();
  }
  public static bool ValidMove (string[,] board, int[] move, bool comp) {
    if (!(move[0] <= 2) || !(move[1] <= 2)) {
      if (!comp) {
        WriteLine ("Invalid move!");
      }
      return false;
    }
    // WriteLine(!comp);
    if (board[move[0], move[1]] == "free") {
      return true;
    }
    else {
      if (!comp) {
        WriteLine ("Invalid move!");
      }
    }
    return false;
  }
  public static bool CheckGameOver (string[,] board) {
    // Checks for horizontal win
    int countX = 0;
    int countO = 0;
    for (int row = 0; row <= 2; row++) {
      for (int cell = 0; cell <= 2; cell++) {
        if (board[row, cell] == "  X ") {
          countX += 1;
        }
        if (board[row, cell] == "  O ") {
          countO += 1;
        }
      }
      if (countX == 3 || countO == 3) {
        return true;
      }
      countX = 0;
      countO = 0;
    }
  // Checks for vertical win
  countX = 0;
  countO = 0;
  for (int cell = 0; cell <= 2; cell++) {
      for (int col = 0; col <= 2; col++) {
        if (board[col, cell] == "  X ") {
          countX += 1;
        }
        if (board[col, cell] == "  O ") {
          countO += 1;
        }
      }
      if (countX == 3 || countO == 3) {
        return true;
      }
      countX = 0;
      countO = 0;
    }
  // Checks for diagonal win
  if (board[1, 1] != "free") {
    string d = board[1, 1];
    if (((board[0, 0] == d) && (board[2, 2] == d)) || ((board[0, 2] == d) && (board[2, 0] == d))) {
      return true;
      }
    }
  // Checks for full board
  bool full = true;
  foreach (string cell in board) {
    if (cell == "free") {
      full = false;
  }
  }
  return full;
  }
}