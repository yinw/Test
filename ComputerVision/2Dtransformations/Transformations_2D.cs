using System;
using System.Drawing;
using MatrixLib;

namespace Transformations
{
    public class Transformations_2D
    {
        public static Point Translation(Point p,int dx, int dy)
        {
            double[,] a = new double[3, 1] { { p.X }, { p.Y }, { 1 } }; 
            Matrix mA = new Matrix(a);

            double[,] b = new double[3, 3] { { 1, 0, dx }, { 0, 1, dy }, { 0, 0, 1 } };
            Matrix mB = new Matrix(b);

            Matrix mc = mB * mA;
            Point newP = new Point((int)mc[0, 0], (int)mc[1, 0]);
            return newP;
        }

        public static Point Rotation(Point p, int dx, int dy, double degrees)
        {
            double[,] a = new double[3, 1] { { p.X }, { p.Y }, { 1 } };
            Matrix mA = new Matrix(a);

            double angle = Math.PI * degrees / 180.0;
            double[,] b = new double[2, 3] { { Math.Cos(angle), -Math.Sin(angle), dx }, { Math.Sin(angle), Math.Cos(angle), dy }};
            Matrix mB = new Matrix(b);

            Matrix mc = mB * mA;
            Point newP = new Point((int)mc[0, 0], (int)mc[1, 0]);
            return newP;
        }

        public static Point ScaledRotation(Point p, int dx, int dy, double degrees, double scale)
        {
            double[,] a = new double[3, 1] { { p.X }, { p.Y }, { 1 } };
            Matrix mA = new Matrix(a);

            double angle = Math.PI * degrees / 180.0;
            double[,] b = new double[2, 3] { { scale * Math.Cos(angle), -scale * Math.Sin(angle), dx },
                                            { scale * Math.Sin(angle), scale * Math.Cos(angle), dy } };
            Matrix mB = new Matrix(b);

            Matrix mc = mB * mA;
            Point newP = new Point((int)mc[0, 0], (int)mc[1, 0]);
            return newP;
        }

        public static Point Affine(Point p, double a00, double a01, double a02, double a10, double a11, double a12)
        {
            double[,] a = new double[3, 1] { { p.X }, { p.Y }, { 1 } };
            Matrix mA = new Matrix(a);

            double[,] b = new double[2, 3] { { a00, a01, a02 }, { a10, a11, a12 }};
            Matrix mB = new Matrix(b);

            Matrix mc = mB * mA;
            Point newP = new Point((int)mc[0, 0], (int)mc[1, 0]);
            return newP;
        }

    }
}
