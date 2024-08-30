using System;

namespace Ucu.Poo.GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.InitGame();
        }
        
        public void InitGame()
        {
            Board board = FileReader.ReadFile();
            GameRules rules = new GameRules(board);
            BoardUpdater updater = new BoardUpdater(board, rules);
            PrintBoard printBoard = new PrintBoard(board);
            
            while (true)
            {
                printBoard.ImprimirTablero();
                updater.UpdateBoard();
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}