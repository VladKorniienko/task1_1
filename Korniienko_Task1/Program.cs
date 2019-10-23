using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Korniienko_Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix m1 = new Matrix(2, 2);
            m1.CreateFromConsole();
            m1.Print();

            Matrix m2 = new Matrix(1, 3);
            m2.CreateFromConsole();
            m2.Print();

            Console.ReadKey();

            Matrix m3 = new Matrix();
            try
            {
                m3 = m1 * m2;
                m3.Print();
            }
            catch (MatrixException exception)
            {
                Console.WriteLine($"Error: {exception.Message}");
                Console.WriteLine($"Columns of the first matrix:{exception.Value1}");
                Console.WriteLine($"Rows of the second matrix:{exception.Value2}");
            }


            Matrix m4 = new Matrix();
            try
            {
                m4 = m1 + m2;
                m4.Print();
            }
            catch (MatrixException exception)
            {
                Console.WriteLine($"Error: {exception.Message}");
                Console.WriteLine($"Rows and columns  of the first matrix: {exception.Value3}, {exception.Value1}");
                Console.WriteLine($"Rows and columns  of the second matrix: {exception.Value4}, {exception.Value2}");
            }

            Console.ReadKey();


            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream("Matrix.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, m1);
            }

            using (FileStream fs = new FileStream("Matrix.dat", FileMode.OpenOrCreate))
            {
                Matrix tempMatrix = (Matrix)formatter.Deserialize(fs);
                tempMatrix.Print();
            }

            Console.ReadLine();

        }
    }
}
