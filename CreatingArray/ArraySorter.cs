using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatingArray
{
    public static class ArraySorter
    {
        /// <summary>
        /// Производит сортировку методом пузырька
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int[] BubbleSort(int[] arr)
        {
            int temp;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        temp = arr[j + 1];
                        arr[j + 1] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
            return arr;
        }
        /// <summary>
        /// Производит сортировку на указанное количество значений
        /// </summary>
        /// <returns></returns>
        public static int[] ShiftToJSort(int[] arr, int iShift)
        {            
            int dif = iShift / arr.Length;
            if (dif != 0) iShift = iShift - arr.Length * 2;
            List<int> values = new List<int>();
            for (int i = iShift; i < arr.Length; i++)
            {
                values.Add(arr[i]);
            }
            for (int i = 0; i < iShift; i++)
            {
                values.Add(arr[i]);
            }
            return values.ToArray();
        }
    }
}
