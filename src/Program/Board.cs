public class Board
{
    private bool[,] cells;

    public int Width { get; private set; }
    public int Height { get; private set; }

    // Constructor que inicializa el tablero con un tamaño dado
    public Board(int width, int height)
    {
        this.Width = width;
        this.Height = height;
        cells = new bool[width, height];
    }

    // Constructor que inicializa el tablero con un estado inicial
    public Board(bool[,] initialState)
    {
        this.Width = initialState.GetLength(0);
        this.Height = initialState.GetLength(1);
        cells = initialState;
    }

    // Método para obtener el estado de una célula
    public bool GetCellState(int x, int y)
    {
        return cells[x, y];
    }

    // Método para establecer el estado de una célula
    public void SetCellState(int x, int y, bool state)
    {
        cells[x, y] = state;
    }

    // Método para obtener una copia del estado actual del tablero
    public bool[,] GetBoardState()
    {
        return (bool[,])cells.Clone();
    }
}