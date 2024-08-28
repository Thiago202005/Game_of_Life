namespace Ucu.Poo.GameOfLife;

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


    private static int aliveNeighborsCounter;

    public static int AliveNeighbours
    {
        get
        {
            int aliveNeighbors = 0;
            for (int x = 0; x < BoardWidth; x++)
            {
                for (int y = 0; y < BoardHeight; y++)
                {
                    for (int i = x - 1; i <= x + 1; i++)
                    {
                        for (int j = y - 1; j <= y + 1; j++)
                        {
                            if (i >= 0 && i < BoardWidth && j >= 0 && j < BoardHeight && GameBoard[i, j])
                            {
                                aliveNeighbors++;
                            }
                        }
                    }
                }
            }

            return aliveNeighbors;
        }
    }

    private static bool[,] cloneBoard = new bool[boardWidth, boardHeight];

    public static bool[,] ClonedBoard
    {
        get => cloneBoard;
        set => cloneBoard = value;
    }

    private static bool[,] gameBoard;

    public static bool[,] GameBoard
    {
        get => gameBoard;
        set => gameBoard = value;
    }

    public static bool[,] UpdatedBoard
    {
        get
        {
            for (int x = 0; x < BoardWidth; x++)
            {

                for (int y = 0; y < BoardHeight; y++)
                {
                    if (GameBoard[x, y])
                    {
                        aliveNeighborsCounter--;
                    }

                    if (GameBoard[x, y] && AliveNeighbours < 2)
                    {
                        //Celula muere por baja población
                        cloneBoard[x, y] = false;
                    }
                    else if (GameBoard[x, y] && AliveNeighbours > 3)
                    {
                        //Celula muere por sobrepoblación
                        UpdatedBoard[x, y] = false;
                    }
                    else if (!GameBoard[x, y] && AliveNeighbours == 3)
                    {
                        //Celula nace por reproducción
                        UpdatedBoard[x, y] = true;
                    }
                    else
                    {
                        //Celula mantiene el estado que tenía
                        UpdatedBoard[x, y] = GameBoard[x, y];
                    }

                }

            }

            return UpdatedBoard;
        }
    }

}



