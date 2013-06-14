using System;
using System.Drawing;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Point p = new Point(5, 8);
            Point newP = Transformations.Transformations_2D.Translation(p,3, 2);
            Point newP2 = Transformations.Transformations_2D.Rotation(p, 3, 2, 45);
            int x = 1;
        }
    }
}
