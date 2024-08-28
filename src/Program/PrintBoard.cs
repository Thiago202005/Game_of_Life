using System;
using System.Runtime.InteropServices.JavaScript;
using System.Text;


public class PrintBoard
{
    private Board board;

    public PrintBoard(Board board)
    {
        this.board = board;
    }

    public void ImprimirTablero()
    {
        Console.Clear();
        StringBuilder s = new StringBuilder();
        for (int y = 0; y < board.Height; y++)
        {
            for (int x = 0; x<board.Width; x++)
            {
                if (board.GetCellState(x,y))
                {
                    s.Append("|X|");
                }
                else
                {
                    s.Append("___");
                }
            }
            s.Append("\n");
        }
        Console.WriteLine(s.ToString());
    }
}
