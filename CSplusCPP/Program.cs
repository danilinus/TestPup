using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace CSplusCPP
{
    class Program
    {
        [DllImport(@"D:\Projects\TestPup\Release\MyCppDLLForTest.dll", EntryPoint = "math_add", CallingConvention = CallingConvention.StdCall)]
        static extern void Sum();

        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 10000000; ++i)
                Sum();
            sw.Stop();
            Console.WriteLine(sw.Elapsed.TotalMilliseconds / 1000.0);
            Console.ReadKey();
        }
    }
}
