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
        public static MyMatrix operator * (MyMatrix matrix1, MyMatrix matrix2)
        {
            if (matrix1.Width == matrix2.Height)
            {
                double[,] matrix = new double[matrix1.Height, matrix2.Width];
                
                for(int i=0; i < matrix1.Height; i++)
                {
                    for(int j = 0; j < matrix2.Width; j++)
                    {
                        matrix[i, j] = 0;
                        for(int k=0; k < matrix1.Width; k++)
                        {
                            matrix[i,j] += matrix1[i, k] * matrix2[k, j];
                        }
                    }
                }
                MyMatrix matrixMultiply = new MyMatrix(matrix);
                return matrixMultiply;
            }
            else
            {
                throw new ArgumentException("First matrix columns must match second matrix rows");
            }
        }
    }
}
