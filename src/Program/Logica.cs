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

        public bool[,] UpdatedBoard
        {
            get
            {
                for (int x = 0; x < board.Width; x++)
                {
                    for (int y = 0; y < board.Height; y++)
                    {
                        int aliveNeighbors = CountAliveNeighbors(x, y);

                        if (board.GetCellState(x, y) && aliveNeighbors < 2)
                        {
                            // Célula muere por baja población
                            cloneBoard[x, y] = false;
                        }
                        else if (board.GetCellState(x, y) && aliveNeighbors > 3)
                        {
                            // Célula muere por sobrepoblación
                            cloneBoard[x, y] = false;
                        }
                        else if (!board.GetCellState(x, y) && aliveNeighbors == 3)
                        {
                            // Célula nace por reproducción
                            cloneBoard[x, y] = true;
                        }
                        else
                        {
                            // Célula mantiene el estado que tenía
                            cloneBoard[x, y] = board.GetCellState(x, y);
                        }
                    }
                }

                return cloneBoard;
            }
        }

        private int CountAliveNeighbors(int x, int y)
        {
            int aliveNeighbors = 0;
            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (i == x && j == y) continue; // Ignora la célula actual

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
