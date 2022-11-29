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
            if (iShift > arr.Length) throw new Exception("Сдвиг не может превышать размер массива!");//Указать в отчете
            if (iShift < 0) throw new Exception("Сдвиг не может быть отрицательным!");//
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
