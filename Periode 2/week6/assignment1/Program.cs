using System;

namespace assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Start();
        }
        void Start()
        {
            ChessPiece[,] chessboard = new ChessPiece[8, 8];

            InitChessboard(chessboard);
            DisplayChessboard(chessboard);
            Console.WriteLine();
            PlayChess(chessboard);

            Console.ReadKey();
        }

        void InitChessboard(ChessPiece[,] chessboard)
        {
            for (int row = 0; row < chessboard.GetLength(0); row++)
            {
                for (int col = 0; col < chessboard.GetLength(1); col++)
                {
                    chessboard[row, col] = null;
                }
            }
            PutChessPieces(chessboard);
        }
        void DisplayChessboard(ChessPiece[,] chessboard)
        {

            string[] colLetters = { " ", " a ", "b ", "c ", "d ", "e ", "f ", "g ", "h " };

            for (int row = chessboard.GetLength(0); row >= 0; row--)
            {
                for (int col = 0; col < chessboard.GetLength(1) + 1; col++)
                {
                    if (row == 0)
                    {
                        Console.Write("{0} ", colLetters[col]);
                        continue;
                    }
                    else if (col == 0)
                    {
                        Console.Write("{0} ", row);
                        continue;
                    }

                    if ((row + col) % 2 == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                    }

                    DisplayChessPiece(chessboard[row - 1, col - 1]);
                }
                Console.ResetColor();
                Console.WriteLine();
            }
        }

        void PutChessPieces(ChessPiece[,] chessboard)
        {
            ChessPieceType[] order = { ChessPieceType.Rook, ChessPieceType.Knight, ChessPieceType.Bishop, ChessPieceType.Queen, ChessPieceType.King, ChessPieceType.Bishop, ChessPieceType.Knight, ChessPieceType.Rook };

            for (int row = 0; row < chessboard.GetLength(0); row++)
            {
                for (int col = 0; col < chessboard.GetLength(1); col++)
                {
                    // Set type
                    if (row == 1 || row == 6)
                    {
                        chessboard[row, col] = new ChessPiece();
                        chessboard[row, col].type = ChessPieceType.Pawn;

                    }
                    else if (row == 0 || row == 7)
                    {

                        chessboard[row, col] = new ChessPiece();
                        chessboard[row, col].type = order[col];
                    }

                    // Set color
                    if (row == 0 || row == 1)
                    {
                        chessboard[row, col].color = ChessPieceColor.White;
                    }

                    else if (row == 6 || row == 7)
                    {
                        chessboard[row, col].color = ChessPieceColor.Black;
                    }
                }
            }
        }

        void DisplayChessPiece(ChessPiece chessPiece)
        {
            if (chessPiece == null)
            {
                Console.Write("   ");
            }
            else
            {
                if (chessPiece.color == ChessPieceColor.Black)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }

                if (chessPiece.type == ChessPieceType.King || chessPiece.type == ChessPieceType.Queen)
                {
                    Console.Write($" {chessPiece.type.ToString()[0]} ");
                }
                else
                {
                    Console.Write($" {chessPiece.type.ToString().ToLower()[0]} ");
                }
            }
            Console.ResetColor();
        }

        Position String2Position(string pos) //a2 
        {


            int c = pos[0] - 'a';
            int r = int.Parse(pos[1].ToString()) - 1;

            Position position = new Position();

         
            if (r >= 8 || c >= 8)
            {
                throw new Exception($"invalid position: {pos}");
            }
            else
            {
                position.column = c;
                position.row = r;
            }
            return position;
        }
        void PlayChess(ChessPiece[,] chessboard)
        {
            Console.WriteLine("Enter a move (e.g. a2 a3) ");
            string input = Console.ReadLine(); //a2 a3

            while (input != "stop")
            {

                Position from = new Position();
                Position to = new Position();
                
                try
                {
                    string[] field = input.Split(' ');
                    string key = field[0]; //a2
                    string value = field[1]; //a3

                    from = String2Position(key); //a2
                    to = String2Position(value); //a3

                    Console.WriteLine($"move from {key} to {value} ");
                    Console.WriteLine();
                    DoMove(chessboard, from, to);
                }
                catch (Exception e )
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                }
                Console.ResetColor();
                
                DisplayChessboard(chessboard);

                Console.WriteLine("Enter a move (e.g. a2 a3) ");
                input = Console.ReadLine();
            }
        }

        void DoMove(ChessPiece[,] chessboard, Position from, Position to)
        {

            CheckMove(chessboard, from, to);

            chessboard[to.row, to.column] = chessboard[from.row, from.column];
            chessboard[from.row, from.column] = null;

        }

        void CheckMove(ChessPiece[,] chessboard, Position from, Position to)
        {
            ChessPiece chessPiece = chessboard[from.row, from.column];
            int hor = Math.Abs(from.column - to.column);
            int ver = Math.Abs(from.row - to.row);

            if (chessboard[to.row, to.column] != null && chessboard[from.row, from.column].color == chessboard[to.row, to.column].color)
            {
                throw new Exception("Can not take a chess piece of same color");

            }
            if (chessPiece == null)
            {
                throw new Exception ("No chess piece at from-position");
            }

            if (hor == 0 && ver == 0)
            {
                throw new Exception($"No movement");
            }
            else
            {
                switch (chessPiece.type)
                {
                    case ChessPieceType.Pawn:
                        if (hor != 0 || ver != 1)
                        if (hor != 0 || ver != 1)
                        {
                            throw new Exception("Invalid move for chess piece Pawn");
                        }
                        break;

                    case ChessPieceType.Rook:
                        if (hor * ver != 0)
                        {
                            throw new Exception("Invalid move for chess piece Rook");
                        }
                        break;

                    case ChessPieceType.Knight:
                        if (hor * ver != 2)
                        {
                            throw new Exception("Invalid move for chess piece Knight");
                        }
                        break;

                    case ChessPieceType.Bishop:
                        if (hor != ver)
                        {
                            throw new Exception("Invalid move for chess piece Bishop");
                        }
                        break;

                    case ChessPieceType.King:
                        if ((hor != 1 || ver != 1) || (hor != 1 && ver != 1))
                        {
                            throw new Exception("Invalid move for chess piece King");
                        }
                        break;

                    case ChessPieceType.Queen:
                        if ((hor * ver != 0) || (hor != ver))
                        {
                            throw new Exception("Invalid move for chess piece Queen");
                        }
                        break;
                }
            }
        }
    }
}