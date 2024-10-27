using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab2
{
    class Main_project
    {
        static void Main(string[] args)
        {
            //testing
            /*
            double[][] initialValues = new double[2][];
            initialValues[0] = new double[] { 1.1, 2.3, 3.1 };
            initialValues[1] = new double[] { 4.0, 5.0, 6.0 };
            MyMatrix matrix1 = new MyMatrix(initialValues);
            Console.WriteLine(matrix1);
            Console.WriteLine(matrix1.Height);
            
            string test = "1 2 3 \n 1 2 3\n 1 2 3";
            MyMatrix matrix2 = new MyMatrix(test);
            Console.WriteLine(matrix2);
            Console.WriteLine(matrix2.Height);

            MyMatrix matrix3 = new MyMatrix(matrix1);
            Console.WriteLine(matrix3);
            Console.WriteLine(matrix3.GetHeight());
            
            string[] lines = new string[]
            {
                "1 2 3",
                "4 5 6",
                "7 8 9"
            };
            MyMatrix matrix4 = new MyMatrix(lines);
            Console.WriteLine(matrix4);
            Console.WriteLine(matrix4.GetHeight());
            
            string[] lines5 =
            {
                "1,2 a b 5,4 3,8 i",
                "3,8 2,1 v 3,1",
                "2,3 4,0 6,1"
            };
            MyMatrix matrix5 = new MyMatrix(lines5);
            Console.WriteLine(matrix5);
            */
            string[] lines = new string[]
            {
                "1,1 2,2 3,3",
                "4,4 5,5 6,6",
                "7,7 8,8 9,9"
            };
            string[] lines2 = new string[]
            {
                "1,1 2,2 3,3 4,4",
                "4,4 5,5 6,6 5,5",
                "7,7 8,8 9,9 6,6"
            };
            MyMatrix matrix1 = new MyMatrix(lines);
            MyMatrix matrix2 = new MyMatrix(lines2);
            Console.WriteLine(matrix1 + matrix2);
            Console.ReadLine();
        }
    }
}
