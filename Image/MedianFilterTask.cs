using System.Collections.Generic;
using System;

namespace Recognizer
{
    internal static class MedianFilterTask
    {
        static double GetMedianInList(List<double> list)
        {
            list.Sort();
            var count = list.Count;
            if (count % 2 == 0)
                return (list[count / 2 - 1] + list[count / 2]) / 2;
            return list[count / 2];
        }

        static void ValueMedian(int i, int j, List<double> list, double[,] original)
        {
            var column = original.GetLength(1);

            if (j - 1 > -1)
                list.Add(original[i, j - 1]);
            list.Add(original[i, j]);
            if (j + 1 < column)
                list.Add(original[i, j + 1]);
        }

        static List<double> ArrayInList(int i, int j, double[,] original)
        {
            var row = original.GetLength(0);
            var list = new List<double>();

            if (i - 1 > -1)
                ValueMedian(i - 1, j, list, original);
            ValueMedian(i, j, list, original);
            if (i + 1 < row)
                ValueMedian(i + 1, j, list, original);
            return list;
        }

        public static double[,] MedianFilter(double[,] original)
        {
            var row = original.GetLength(0);
            var column = original.GetLength(1);
            var arr = new double[row, column];

            for (var i = 0; i < row; i++)
                for (var j = 0; j < column; j++)
                    arr[i, j] = GetMedianInList(ArrayInList(i, j, original));
            return arr;
        }
    }
}