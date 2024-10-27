using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab2
{
    public partial class MyMatrix
    {
        public static MyMatrix operator +(MyMatrix matrix1, MyMatrix matrix2)
        {
            if (matrix1.Height == matrix2.Height && matrix1.Width == matrix2.Width)
            {
                double[,] matrix = new double[matrix1.Height, matrix1.Width];
                MyMatrix matrixSum = new MyMatrix(matrix);

                for (int i = 0; i < matrix1.Height; i++)
                {
                    for (int j = 0; j < matrix1.Width; j++)
                    {
                        matrixSum[i, j] = matrix1[i, j] + matrix2[i, j];
                    }
                }
                return matrixSum;
            }
            else
            {
                throw new ArgumentException("These matrices cannot be added as they are not the same size");
            }
        }
    }
}
