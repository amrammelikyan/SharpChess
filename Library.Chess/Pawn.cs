using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Chess
{
    public class Pawn : Figure
    {
        public override char Name => '♙';
        public Pawn(Color color) : base(color) { }

        public override bool Move(int i1, int j1, int i2, int j2, Figure[,] array)
        {
            if (((i2 == i1 - 1) && (j2 == j1 + 1 || j2 == j1 - 1 && array[i1, j1].Color == Color.Blue)
              || (i2 == i1 + 1) && (j2 == j1 + 1 || j2 == j1 - 1 && array[i1, j1].Color == Color.Red))
              && array[i2, j2] == null)
            {
                return false;
            }

            else if (array[i1, j1].Color == Color.Blue)
            {
                if ((i1 == 6 && i2 == i1 - 2 && j1 == j2 && array[i2 + 1, j2] == null && array[i2, j2] == null)
                 || (i2 == i1 - 1) && (j1 == j2) && array[i2, j2] == null
                 || (i2 == i1 - 1) && (j2 == j1 + 1 || j2 == j1 - 1) && array[i2, j2].Color != Color && array[i2, j2].Name != '♔')
                {
                    return true;
                }
            }

            else if (array[i1, j1].Color == Color.Red)
            {
                if ((i1 == 1 && i2 == i1 + 2 && j1 == j2 && array[i1 + 1, j1] == null && array[i2, j2] == null)
                 || (i2 == i1 + 1) && (j1 == j2) && array[i2, j2] == null
                 || (i2 == i1 + 1) && (j2 == j1 + 1 || j2 == j1 - 1) && array[i2, j2].Color != Color && array[i2, j2].Name != '♔')
                {
                    return true;
                }
            }

            return false;
        }

        public void Replace(int i1, int j1, int i2, int j2, Figure[,] array, Color color)
        {
            Console.WriteLine("Mutqagreq poxarinvox figury\n1. Queen\n2. Rook\n3. Knight\n4. Bishop");

            if (i2 == 0 || i2 == 7)
            {
                do
                {
                    string figure = Console.ReadLine();
                    switch (figure)
                {
                    case "Queen": case "queen": case "Q": case "q": case "1":
                        {
                            array[i2, j2] = new Queen(color);
                            break;
                        }

                    case "Rook": case "rook": case "R": case "r": case "2":
                        {
                            array[i2, j2] = new Rook(color);
                            break;
                        }

                    case "Knight": case "knight": case "K": case "k": case "3":
                        {
                            array[i2, j2] = new Knight(color);
                            break;
                        }

                    case "Bishop": case "bishop": case "B": case "b": case "4":
                        {
                            array[i2, j2] = new Bishop(color);
                            break;
                        }
                }
                } while (array[i2, j2] is Pawn);
            }
        }
    }
}
