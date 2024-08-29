rusing System;

namespace Ucu.Poo.GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.InitGame();
        }
        public string InitGame()
        {
            Board board = FileReader.ReadFile();
            Logica logica = new Logica(board);
            PrintBoard printBoard = new PrintBoard(board);
            while (true)
            {
                printBoard.ImprimirTablero();
                board = new Board(logica.UpdatedBoard());
                printBoard = new PrintBoard(board);
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}

