using System.Collections.Generic;
using System;
namespace Recognizer
{
    public static class ThresholdFilterTask
    {
        static double GetBrightnessThreshold(double[,] original, double threshold)
        {
            var row = original.GetLength(0);
            var column = original.GetLength(1);
            var numberWhite = Convert.ToInt32(Math.Floor(threshold * row * column));
            var list = new List<double>();

            for (var i = 0; i < row; i++)
                for (var j = 0; j < column; j++)
                    list.Add(original[i, j]);
            list.Sort();

            if (numberWhite == 0)
                return list[row * column - 1] + 1;
            return list[row * column - numberWhite];
        }

        public static double[,] ThresholdFilter(double[,] original, double threshold)
        {
            var brightnessThreshold = GetBrightnessThreshold(original, threshold);
            var row = original.GetLength(0);
            var column = original.GetLength(1);
            var arr = new double[row, column];
            for (var i = 0; i < row; i++)
                for (var j = 0; j < column; j++)
                    if (original[i, j] >= brightnessThreshold)
                        arr[i, j] = 1;
            return arr;
        }
    }
}