namespace Ucu.Poo.GameOfLife;

using System;
using System.IO;
/* se decidio separar esta clase de board debido a que si se llegara a cambiar el archivo del tablero o se decidiera generarlo de otra manera generaria una responsabilidad de cambio adicional a la clase board*/
public class FileReader
{
    public static Board ReadFile()
    {
        string filePath = "board.txt"; 

        string content = File.ReadAllText(filePath);
        string[] contentLines = content.Split('\n');
        Board board = new Board(contentLines[0].Length, contentLines.Length);

        for (int y = 0; y < contentLines.Length; y++)
        {
            for (int x = 0; x < contentLines[y].Length; x++)
            {
                char cell = contentLines[y][x];
                board.SetCellState(x, y, cell == '1');
            }
        }

        return board;
    }
}