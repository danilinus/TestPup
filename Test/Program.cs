using System;
using System.Diagnostics;

class Matrix
{
    public double[,] data;
    public const int rows = 3;
    public const int cols = 3;

    public Matrix(double init)
    {
        data = new double[rows, cols];
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                data[i, j] = init;
    }

    public static Matrix operator *(Matrix a, Matrix b)
    {
        Matrix res = new Matrix(0);

        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                for (int k = 0; k < rows; k++)
                    res.data[i, j] += a.data[i, k] * b.data[k, j];

        return res;
    }
}

class Program
{
    static double Test()
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();

        for (int i = 0; i < 10000000; ++i)
        {
            Matrix m1 = new Matrix(4.0);
            Matrix m2 = new Matrix(5.0);
            Matrix m3 = m1 * m2;
        }

        sw.Stop();
        return sw.Elapsed.TotalMilliseconds / 1000.0;
    }

    static void Main(string[] args)
    {
        double time = Test();
        Console.WriteLine(time);

        Console.ReadKey();
    }
}