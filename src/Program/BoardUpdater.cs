public class BoardUpdater
{
    private Board board;
    private GameRules rules;
/*Se decidio separar esta clase de la logica del juego ya que si decidieramos cambiar que el tablero ya no sea con booleanos generaria mas razones de cambio en logica.cs*/
    public BoardUpdater(Board board, GameRules rules)
    {
        this.board = board;
        this.rules = rules;
    }

    public void UpdateBoard()
    {
        bool[,] newBoardState = new bool[board.Width, board.Height];

        for (int x = 0; x < board.Width; x++)
        {
            for (int y = 0; y < board.Height; y++)
            {
                newBoardState[x, y] = rules.GetNextCellState(x, y);
            }
        }
        
        for (int x = 0; x < board.Width; x++)
        {
            for (int y = 0; y < board.Height; y++)
            {
                board.SetCellState(x, y, newBoardState[x, y]);
            }
        }
    }
}