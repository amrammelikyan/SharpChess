using Library.Chess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessBoard chess = new ChessBoard();

            chess.Figures();

            do
            {
                chess.Show();
                chess.Step();
                Console.Clear();
                
            } while (true);
        }
    }
}
