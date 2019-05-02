using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Chess
{
    public class King : Figure
    {
        public override char Name => '♔';

        public King(Color color) : base(color) { }
        
        public override bool Move(int i1, int j1, int i2, int j2, Figure[,] array)
        {
            if ((i2 == i1 + 1 || i2 == i1 || i2 == i1 - 1)
             && (j2 == j1 + 1 || j2 == j1 || j2 == j1 - 1)
             && (array[i2, j2] == null || array[i2, j2].Color != Color  && array[i2, j2].Name != '♔'))
            {
                return true;
            }
            return false;
        }
    }
}
