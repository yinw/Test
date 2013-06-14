using System;
using System.Drawing;
using MatrixLib;

namespace Transformations
{
    public class Transformations_2D
    {
        /// <summary>
        /// 平移
        /// </summary>
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

        /// <summary>
        /// 旋转+平移
        /// </summary>
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

        /// <summary>
        /// 缩放旋转
        /// </summary>
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

        /// <summary>
        /// 仿射
        /// </summary>
        public static Point Affine(Point p, Matrix A)
        {
            if (A.Row != 2 && A.Col != 3)
            {
                throw new Exception("矩阵必须是2行3列");
            }

            double[,] a = new double[3, 1] { { p.X }, { p.Y }, { 1 } };
            Matrix x = new Matrix(a);

            //double[,] b = new double[2, 3] { { a00, a01, a02 }, { a10, a11, a12 }};
            //Matrix mB = new Matrix(b);

            Matrix mc = A * x;
            Point newP = new Point((int)mc[0, 0], (int)mc[1, 0]);
            return newP;
        }

        /// <summary>
        /// 投影
        /// </summary>
        public static Point Projective(Point p, Matrix H)
        {
            if (H.Row != 3 && H.Col != 3)
            {
                throw new Exception("矩阵必须是3行3列");
            }

            double[,] a = new double[3, 1] { { p.X }, { p.Y }, { 1 } };
            Matrix x = new Matrix(a);

            Matrix mc = H * x;

            int px = 0, py = 0;
            if (mc[2, 0] != 0)
            {
                px = (int)(mc[0, 0] / mc[2, 0]);
                py = (int)(mc[1, 0] / mc[2, 0]);
            }
            Point newP = new Point(px, py);
            return newP;
        }

    }
}
