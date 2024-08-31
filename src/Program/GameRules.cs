public class GameRules
{
    private Board board;
    public GameRules(Board board)
    {
        this.board = board;
    }

    public bool GetNextCellState(int x, int y)
    {
        int aliveNeighbors = CountAliveNeighbors(x, y);
        bool currentState = board.GetCellState(x, y);

        if (currentState && aliveNeighbors < 2)
        {
            return false; // Célula muere por baja población
        }
        else if (currentState && aliveNeighbors > 3)
        {
            return false; // Célula muere por sobrepoblación
        }
        else if (!currentState && aliveNeighbors == 3)
        {
            return true; // Célula nace por reproducción
        }
        else
        {
            return currentState; // Célula mantiene el estado que tenía
        }
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