using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab2
{
    public partial class MyMatrix
    {
        private double[,] matrixElements;
        public MyMatrix(MyMatrix copy)
        {
            matrixElements = copy.matrixElements;
        }
        public MyMatrix(double[,]elements)
        {
            matrixElements = elements;
        }
        public MyMatrix(double[][]elements)
        {
            bool isRectangle = true;
            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i].Length != elements[0].Length)
                {
                    isRectangle = false;
                    throw new ArgumentException("Матриця повинна бути прямокутною");
                }
            }

            if (isRectangle==true)
            {
                for(int i =0; i < elements.Length; i++)
                {
                    for(int j=0; j < elements[0].Length; j++)
                    {
                        matrixElements[i, j] = elements[i][j];
                    }
                }
            }
        }
    }
}
