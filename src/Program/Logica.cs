namespace Ucu.Poo.GameOfLife
{
    public class Logica
    {
        private Board board;
        private bool[,] cloneBoard;

        public Logica(Board board)
        {
            this.board = board;
            this.cloneBoard = new bool[board.Width, board.Height];
        }
        private int CountAliveNeighbors(int x, int y)
        {
            int aliveNeighbors = 0;
            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (i == x && j == y)
                    {
                        continue;
                    }

                    if (i >= 0 && i < board.Width && j >= 0 && j < board.Height && board.GetCellState(i, j))
                    {
                        aliveNeighbors++;
                    }
                }
            }
            return aliveNeighbors;
        }
    }
}
