using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Chess
{
    public class ChessBoard
    {
        public Figure[,] figures = new Figure[8, 8];
        int i1, j1, i2, j2;
        Figure[][,] history = new Figure[8][,]; int sizeHistory = 0;
        Color color;
        string step;
        string[] steps = new string[10]; int size = 0;
        int stepsCount, stepsCount2 = 0;

        public void Figures()
        {
            figures[0, 0] = figures[0, 7] = new Rook(Color.Red);
            figures[7, 0] = figures[7, 7] = new Rook(Color.Blue);
            figures[0, 1] = figures[0, 6] = new Knight(Color.Red);
            figures[7, 1] = figures[7, 6] = new Knight(Color.Blue);
            figures[0, 2] = figures[0, 5] = new Bishop(Color.Red);
            figures[7, 2] = figures[7, 5] = new Bishop(Color.Blue);
            figures[0, 3] = new Queen(Color.Red);
            figures[7, 3] = new Queen(Color.Blue);
            figures[0, 4] = new King(Color.Red);
            figures[7, 4] = new King(Color.Blue);

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (i == 1)
                    {
                        figures[i, j] = new Pawn(Color.Red);
                    }
                    if (i == 6)
                    {
                        figures[i, j] = new Pawn(Color.Blue);
                    }
                }
            }
        }
        public void Show()
        {

            Console.WriteLine();
            for (int i = 0; i < 8; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write($"{8 - i} ");
                for (int j = 0; j < 8; j++)
                {
                    if ((i + j) % 2 == 0) Console.BackgroundColor = ConsoleColor.White;
                    else Console.BackgroundColor = ConsoleColor.Yellow;

                    Console.OutputEncoding = System.Text.Encoding.Unicode;
                    if (figures[i, j] != null)
                    {
                        figures[i, j].ConsolColor();
                        Console.Write(figures[i, j].Name + " ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  A B C D E F G H ");

            stepsCount = stepsCount2;
            for (int i = 0; i < size; i++)
            {
                stepsCount++;
                if (i % 2 == 0) Console.Write($"Player 1. step {stepsCount} - {steps[i]}    ");
                else Console.WriteLine($"Player 2. step {stepsCount} - {steps[i]}");
                if (i == size - 1 && i % 2 == 0) Console.WriteLine();
                if (i == steps.Length - 1) stepsCount2 += 2;
            }
        }
        public void Step()
        {
            History();
            //color = figures[i2, j2].Color;

            do
            {
                do
                {
                    do
                    {
                        step = Console.ReadLine();
                        if (step == "z" || step == "Z" || step == "^Z")
                        {
                            Undo();
                            Console.Clear();
                            Show();
                        }
                    } while (step.Length < 4);
                    if (size % 2 == 0) color = Color.Blue; else color = Color.Red;

                    j1 = Check(step[0]);
                    i1 = 8 - ((int)step[1] - 48);
                    j2 = Check(step[step.Length - 2]);
                    i2 = 8 - ((int)step[step.Length - 1] - 48);

                } while (i1 < 0 || i1 > 7 || i2 < 0 || i2 > 7 || j1 < 0 || j1 > 7 || j2 < 0 || j2 > 7);
            }
            while (figures[i1, j1] == null || figures[i1, j1].Color != color || !figures[i1, j1].Move(i1, j1, i2, j2, figures));

            Steps(step);

            figures[i2, j2] = figures[i1, j1];
            figures[i1, j1] = null;

            if (figures[i2, j2] is Pawn && (i2 == 0 || i2 == 7))
            {
                Console.Clear();
                Show();
                new Pawn(figures[i2, j2].Color).Replace(i1, j1, i2, j2, figures, figures[i2, j2].Color);
            }
        }
        private int Check(char c)
        {
            if ((int)c >= 97) return (int)c - 97;
            else return (int)c - 65;
        }
        public void Steps(string s)
        {
            if (size == steps.Length)
            {
                for (int i = 0; i < steps.Length - 2; i++)
                {
                    steps[i] = steps[i + 2];
                }
                size -= 2;
            }

            steps[size] = s;
            if (size < steps.Length) size++;
        }
        public void History()
        {
            if (sizeHistory == history.GetLongLength(0))
            {
                Figure[][,] history2 = new Figure[history.GetLongLength(0) * 2][,];
                for (int i = 0; i < history.GetLongLength(0); i++)
                {
                    history2[i] = history[i];
                }
                history = history2;
            }

            history[sizeHistory] = new Figure[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    history[sizeHistory][i, j] = figures[i, j];
                }
            }
            sizeHistory++;
        }
        public void Undo()
        {
            if (sizeHistory > 1)
            {
                figures = new Figure[8, 8];
                for (int i = 0; i < figures.GetLength(0); i++)
                {
                    for (int j = 0; j < figures.GetLength(1); j++)
                    {
                        figures[i, j] =  history[sizeHistory - 2][i, j];
                    }
                }
                sizeHistory--;
                size--;
            }
        }
    }
}
