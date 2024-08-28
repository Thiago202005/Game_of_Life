namespace Ucu.Poo.GameOfLife
{
    public class Logica
    {
        private static int boardWidth;
        private static int boardHeight;

        public static int BoardWidth
        {
            get => boardWidth;
            set => boardWidth = value;
        }

        public static int BoardHeight
        {
            get => boardHeight;
            set => boardHeight = value;
        }

        private static bool[,] cloneBoard;
        private static bool[,] gameBoard;

        public static bool[,] ClonedBoard
        {
            get => cloneBoard;
            set => cloneBoard = value;
        }

        public static bool[,] GameBoard
        {
            get => gameBoard;
            set => gameBoard = value;
        }

        public static bool[,] UpdatedBoard
        {
            get
            {
                cloneBoard = new bool[BoardWidth, BoardHeight]; // Aseguramos que tenga el tamaño correcto
                for (int x = 0; x < BoardWidth; x++)
                {
                    for (int y = 0; y < BoardHeight; y++)
                    {
                        int aliveNeighbors = CountAliveNeighbors(x, y);

                        if (GameBoard[x, y] && aliveNeighbors < 2)
                        {
                            // Célula muere por baja población
                            cloneBoard[x, y] = false;
                        }
                        else if (GameBoard[x, y] && aliveNeighbors > 3)
                        {
                            // Célula muere por sobrepoblación
                            cloneBoard[x, y] = false;
                        }
                        else if (!GameBoard[x, y] && aliveNeighbors == 3)
                        {
                            // Célula nace por reproducción
                            cloneBoard[x, y] = true;
                        }
                        else
                        {
                            // Célula mantiene el estado que tenía
                            cloneBoard[x, y] = GameBoard[x, y];
                        }
                    }
                }

                return cloneBoard;
            }
        }

        // Método para contar vecinos vivos alrededor de una célula
        private static int CountAliveNeighbors(int x, int y)
        {
            int aliveNeighbors = 0;
            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (i == x && j == y) continue; // Ignora la célula actual

                    if (i >= 0 && i < BoardWidth && j >= 0 && j < BoardHeight && GameBoard[i, j])
                    {
                        aliveNeighbors++;
                    }
                }
            }
            return aliveNeighbors;
        }
    }
}
