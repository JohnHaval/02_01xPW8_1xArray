using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_01xPW8_1xArray
{
    public static class LessFinder
    {        
        public static string ResultDescription { get; set; }
        public static int ResultValue { get; set; }
        public static int GetLess(int[] arr)
        {
            ResultValue = 0;
            ResultDescription = "";
            List<int> values = new List<int>();
            for (int i = 0; i < arr.Length - 5; i++)
            {
                values.Add(arr[i] + arr[i + 5]);
            }
            int indexMin = 0, minVal = values[0];
            for (int i = 1; i < values.Count; i++)
            {
                if (minVal > values[i])
                {                    
                    minVal = values[indexMin = i];
                }
            }
            ResultDescription = $"A{indexMin + 1} + A{indexMin + 6} = {minVal}";
            return ResultValue = minVal;
        }
        /// <summary>
        /// Нахождение минимального значения в двумерном массиве массиве
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static double GetArrayMin(double[,] arr)
        {
            double minVal = arr[0, 0];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (minVal > arr[i, j])
                    {
                        minVal = arr[i, j];
                    }
                }
            }
            return minVal;
        }
    }
}
