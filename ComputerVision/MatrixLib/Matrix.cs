using System;

namespace MatrixLib
{
    public class Matrix
    {
        double[,] m_data;

        public Matrix(int row)
        {
            m_data = new double[row, row];

        }

        public Matrix(int row, int col)
        {
            m_data = new double[row, col];
        }

        public Matrix(double[,] data)
        {
            m_data = data;
        }

        //复制构造函数
        public Matrix(Matrix m)
        {
            int row = m.Row;
            int col = m.Col;
            m_data = new double[row, col];

            for (int i = 0; i < row; i++)
                for (int j = 0; j < col; j++)
                    m_data[i, j] = m[i, j];

        }

        public int Row
        {
            get
            {

                return m_data.GetLength(0);
            }
        }

        //返回列数
        public int Col
        {
            get
            {
                return m_data.GetLength(1);
            }
        }

        public double this[int row, int col]
        {
            get
            {
                return m_data[row, col];
            }
            set
            {
                m_data[row, col] = value;
            }
        }

        //binary multiple 矩阵乘
        public static Matrix operator *(Matrix lhs, Matrix rhs)
        {
            if (lhs.Col != rhs.Row)    //异常
            {
                System.Exception e = new Exception("相乘的两个矩阵的行列数不匹配");
                throw e;
            }

            Matrix ret = new Matrix(lhs.Row, rhs.Col);
            double temp;
            for (int i = 0; i < lhs.Row; i++)
            {
                for (int j = 0; j < rhs.Col; j++)
                {
                    temp = 0;
                    for (int k = 0; k < lhs.Col; k++)
                    {
                        temp += lhs[i, k] * rhs[k, j];
                    }
                    ret[i, j] = temp;
                }
            }

            return ret;
        }
    }
}
