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
            //конструктор копіювання
            for (int i = 0; i < copy.matrixElements.GetLength(0); i++)
            {
                for (int j = 0; j < copy.matrixElements.GetLength(1); j++)
                {
                    matrixElements[i, j] = copy.matrixElements[i, j];
                }
            }
        }
        public MyMatrix(double[,] elements)
        {
            //в разі прямокутного масиву
            matrixElements = new double[elements.GetLength(0), elements.GetLength(1)];
            for (int i = 0; i < elements.GetLength(0); i++)
            {
                for (int j = 0; j < elements.GetLength(1); j++)
                {
                    matrixElements[i, j] = elements[i, j];
                }
            }
        }
        public MyMatrix(double[][] elements)
        {
            //в разі зубчастого масиву
            bool isRectangle = true;
            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i].Length != elements[0].Length)
                {
                    isRectangle = false;
                    throw new ArgumentException("Матриця повинна бути прямокутною");
                }
            }

            if (isRectangle == true)
            {
                for (int i = 0; i < elements.Length; i++)
                {
                    for (int j = 0; j < elements[0].Length; j++)
                    {
                        matrixElements[i, j] = elements[i][j];
                    }
                }
            }
        }
        public MyMatrix(string[] lines)
        {
            //в разі масиву рядків
            bool isRectangle = true;
            //перевірка на однакову к-ть чисел в рядках (не довжину всіх елементів рядку, а саме чисел)
            int count = 0, temp = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                count = 0;
                string[] parts = lines[i].Split(' ');

                for (int j = 0; j < parts.Length; j++) //к-ть елементів у рядку
                {
                    if (double.TryParse(parts[j], out double value))
                    {
                        count++;
                    }
                }
                if (i == 0)
                {
                    temp = count;
                }
                else if (count != temp)
                {
                    isRectangle = false;
                    throw new ArgumentException("Кількість чисел в кожному рядку повинна бути однаковою.");
                }
            }

            if (isRectangle == true)
            {
                matrixElements = new double[lines.Length, count];
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] parts = lines[i].Split(' ');

                    for (int j = 0; j < parts.Length; j++)
                    {
                        if (int.TryParse(parts[j], out int intValue))
                        {
                            matrixElements[i, j] = (double)intValue;
                        }
                        else if (double.TryParse(parts[j], out double doubleValue))
                        {
                            matrixElements[i, j] = doubleValue;
                        }
                    }
                }
            }
        }
        public MyMatrix(string line)
        {
            bool isRectangle = true;
            string[] separators = new string[] { "\n", "\r\n" };
            string[] lines = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 1; i < lines.Length; i++)
            {
                if (lines[i].Split().Length != lines[0].Split().Length)
                {
                    isRectangle = false;
                    throw new ArgumentException("Кількість чисел в кожному рядку повинна бути однаковою.");
                }
            }
            if (isRectangle == true)
            {
                matrixElements = new double[lines.Length, lines[0].Split().Length];
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] oneLineElements = lines[i].Split();
                    for (int j = 0; j < lines[0].Split().Length; j++)
                    {
                        matrixElements[i, j] = double.Parse(oneLineElements[j]);
                    }
                }
            }
        }
        public int Height
        {
            get { return matrixElements.GetLength(0); }
        }
        public int Width
        {
            get { return matrixElements.GetLength(1); }
        }
        //Java-style getter & setter below:
        public int GetHeight()
        {
            return matrixElements.GetLength(0);
        }
        public int GetWidth()
        {
            return matrixElements.GetLength(1);
        }
        public double this[int index1, int index2]
        {
            get
            {
                if (index1 < 0 || index1 >= matrixElements.GetLength(0) || index2 < 0 || index2 >= matrixElements.GetLength(1))
                    throw new IndexOutOfRangeException("Неприпустимий індекс");
                return matrixElements[index1, index2];
            }
            set
            {
                if (index1 < 0 || index1 >= matrixElements.GetLength(0) || index2 < 0 || index2 >= matrixElements.GetLength(1))
                    throw new IndexOutOfRangeException("Неприпустимий індекс");
                matrixElements[index1, index2] = value;
            }
        }
        //Java-style getter & setter below:
        public double getValue(int index1, int index2)
        {
            if (index1 < 0 || index1 >= matrixElements.GetLength(0) || index2 < 0 || index2 >= matrixElements.GetLength(1))
                throw new IndexOutOfRangeException("Неприпустимий індекс");
            return matrixElements[index1, index2];
        }
        public void setValue(int index1, int index2, double value)
        {
            if (index2 < 0 || index1 >= matrixElements.GetLength(0) || index2 < 0 || index2 >= matrixElements.GetLength(1))
                throw new IndexOutOfRangeException("Непримустимий індекс");
            matrixElements[index1, index2] = value;
        }
        override public String ToString()
        {
            string data = "";
            for (int i = 0; i < matrixElements.GetLength(0); i++)
            { 
                string tempString = "";
                for (int j = 0; j < matrixElements.GetLength(1); j++)
                {
                    if (j == 0)
                    {
                        tempString = matrixElements[i, j].ToString();
                    }
                    else
                    {
                        tempString = tempString + "\t" + matrixElements[i, j];
                    }
                }
                data = data + tempString + "\n";
            }
            return data;
        }
    }
}
