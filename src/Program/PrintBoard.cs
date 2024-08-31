using System;
using System.Runtime.InteropServices.JavaScript;
using System.Text;

/* se decidio separar esta clase de board debido a que sino generaria una responsabilidad de cambio adicional a la clase board como por ejemplo si se cambiara la forma de mostrar el tablero y ahora sea en una interfaz*/
public class PrintBoard
{
    private Board board;

    public PrintBoard(Board board)
    {
        this.board = board;
    }

    public void ImprimirTablero()
    {
        
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
