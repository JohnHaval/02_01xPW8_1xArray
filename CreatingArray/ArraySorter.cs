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
        /// Производит сортировку на указанное количество значений
        /// </summary>
        /// <returns></returns>
        public static double[] ShiftToJSort(double[] arr, int iShift)
        {            
            int dif = iShift / arr.Length;
            if (dif != 0) iShift = iShift - arr.Length * 2;
            List<double> values = new List<double>();
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
