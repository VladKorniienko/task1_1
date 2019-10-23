using System;

namespace Korniienko_Task1
{
    class MatrixException : ArgumentException
    {
        public int Value1 { get; }
        public int Value2 { get; }
        public int Value3 { get; }
        public int Value4 { get; }

        public MatrixException(string message, int value1, int value2)
        : base(message)
        {
            Value1 = value1;
            Value2 = value2;
        }
        public MatrixException(string message, int value1, int value2, int value3, int value4)
        : base(message)
        {
            Value1 = value1;
            Value2 = value2;
            Value3 = value3;
            Value4 = value4;
        }
    }
}
