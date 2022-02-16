using System;
using System.Collections.Generic;
using System.IO;

namespace ZAD3_ASD
{
    class Program
    {

        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("in1.txt");
            string[] dimensions = lines[0].Split(" ");
            int width = int.Parse(dimensions[0]);
            int[][] arr = new int[width][];
            for (int i = 0; i < width; i++)
            {
                arr[i] = new int[3];
            }
            int j = 0;
            for (int i = 1; i < lines.Length; i++)
            {
                string c = lines[i];
                string[] d = c.Split(" ");
                arr[j][0] = int.Parse(d[0]);
                arr[j][1] = int.Parse(d[1]);
                arr[j][2] = int.Parse(d[2]);
                if (j < width)
                {
                    j++;
                }
            }
            Sort<int>(arr, 1);
            int t = arr[width - 1][1];
            int[] A = new int[t + 1];//array of days
            A[0] = 0;
            for (int d = 1; d <= t; d++)
            {
                for (int i = 0; i < width; i++)
                {
                    if (arr[i][1] > d)
                    {
                        A[d] = A[d - 1];
                        break;
                    }
                    else if (arr[i][1] == d)
                    {
                        A[d] = Math.Max(A[d - 1], A[arr[i][0]] + arr[i][2]);
                        break;
                    }
                }
            }

            Console.WriteLine(A[t]);

        }
        private static void Sort<T>(T[][] tab, int col)
        {
            Comparer<T> comparer = Comparer<T>.Default;
            Array.Sort<T[]>(tab, (x, y) => comparer.Compare(x[col], y[col]));
        }
    }
}
