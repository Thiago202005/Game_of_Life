public class Board
{
    private bool[,] cells;

    public int Width { get; private set; }
    public int Height { get; private set; }
    
    public Board(int width, int height)
    {
        this.Width = width;
        this.Height = height;
        cells = new bool[width, height];
    }
    
    public Board(bool[,] initialState)
    {
        this.Width = initialState.GetLength(0);
        this.Height = initialState.GetLength(1);
        cells = (bool[,])initialState.Clone();
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

    public bool[,] GetBoardState()
    {
        return (bool[,])cells.Clone();
    }
}