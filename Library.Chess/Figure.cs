using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Chess
{
     abstract public class Figure
    {
        public abstract char Name { get; }
        public Color Color { get; }
        public Figure(Color color)
        {
            Color = color;
        }

        public virtual void ConsolColor()
        {
            if (Color == Color.Red) Console.ForegroundColor = ConsoleColor.Red;
            else Console.ForegroundColor = ConsoleColor.Blue;
        }

        public abstract bool Move(int i1, int j1, int i2, int j2, Figure[,] array);
        
    }
}
