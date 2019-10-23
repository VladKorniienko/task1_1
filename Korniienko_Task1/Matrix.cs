using System;
using System.Collections.Generic;


namespace Korniienko_Task1
{
    [Serializable]
    class Matrix : ICloneable, IComparer<Matrix>
    {

        private int _rows;

        private int _columns;

        private readonly double[,] _data;

        public Matrix() { }

        public Matrix(int rowsNumber, int columnsNumber)
        {
            _rows = rowsNumber;
            _columns = columnsNumber;
            _data = new double[_rows, _columns];
        }



        public int Rows { get => _rows; set => _rows = value; }
        public int Columns { get => _columns; set => _columns = value; }

        public double this[int row, int column]   //Index
        {
            get
            {
                if (row > _rows && column > _columns)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                    return this._data[row, column];
            }
            set
            {
                if (row > _rows && column > _columns)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this._data[row, column] = value;
            }
        }

        public void CreateFromConsole()     //Input from console
        {
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _columns; j++)
                {
                    Console.Write("Input [" + i.ToString() + "," + j.ToString() + "]" + "\t");
                    string input = Console.ReadLine();
                    if (double.TryParse(input, out double number))
                        this._data[i, j] = number;
                    else
                        Console.WriteLine("Incorrect input!");
                }
            }

        }

        public void Print()             //Output
        {
            Console.WriteLine("--------------------");
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _columns; j++)
                {
                    Console.Write(_data[i, j] + "\t");
                }
                Console.WriteLine();

            }
            Console.WriteLine("--------------------");
        }

        public static Matrix operator *(Matrix m1, Matrix m2)               //Multiply
        {
            if (m1._columns != m2._rows)
            {
                throw new MatrixException("Matrixes can`t be multiplied", m1._columns, m2._rows);
            }
            Matrix result = new Matrix(m1._rows, m2._columns);
            for (int i = 0; i < m2._rows; i++)
                for (int j = 0; j < m1._columns; j++)
                    for (int k = 0; k < m1._columns; k++)
                    {
                        result[i, j] += m1[i, k] * m2[k, j];
                    }
            return result;
        }

        public static Matrix operator -(Matrix m1, Matrix m2)        //subtraction
        {
            if ((m1._columns != m2._columns) || (m1._rows != m2._rows))
            {
                throw new MatrixException("Matrixes can`t be substracted", m1._columns, m2._columns, m1._rows, m2._rows);
            }
            Matrix result = new Matrix(m1._rows, m2._columns);
            for (int i = 0; i < m2._rows; i++)
                for (int j = 0; j < m1._columns; j++)
                    result[i, j] = m1[i, j] - m2[i, j];
            return result;
        }

        public static Matrix operator +(Matrix m1, Matrix m2)       //Sum
        {
            if ((m1._columns != m2._columns) || (m1._rows != m2._rows))
            {
                throw new MatrixException("Matrixes can`t be summed up", m1._columns, m2._columns, m1._rows, m2._rows);
            }
            Matrix result = new Matrix(m1._rows, m2._columns);
            for (int i = 0; i < m2._rows; i++)
                for (int j = 0; j < m1._columns; j++)
                    result[i, j] = m1[i, j] + m2[i, j];
            return result;
        }

        public object Clone()       //IClonable
        {
            return (Matrix)this.MemberwiseClone();
        }

        public int Compare(Matrix m1, Matrix m2)     //IComparer
        {
            if (m1._rows > m2._rows && m1._columns > m2._columns)
                return 1;
            else if (m1._rows < m2._rows && m1._columns < m2._columns)
                return -1;
            else
                return 0;
        }
    }
}
