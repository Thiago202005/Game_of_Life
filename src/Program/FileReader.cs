namespace Ucu.Poo.GameOfLife;

using System;
using System.IO;

public class FileReader
{
    public static void ReadFile()
    {
        string filePath = "board.txt"; 

        string content = File.ReadAllText(filePath);
        string[] contentLines = content.Split('\n');
        Board board = new Board(contentLines[0].Length, contentLines.Length);

        for (int y = 0; y < contentLines.Length; y++)
        {
            for (int x = 0; x < contentLines[y].Length; x++)
            {
                board[x, y] = contentLines[y][x] == '1';
            }
        }
    }
    
}