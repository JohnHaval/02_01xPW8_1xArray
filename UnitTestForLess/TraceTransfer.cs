using System.Data;
using System.Diagnostics;
using System.IO;

namespace UnitTestForLess
{
    public static class TraceTransfer
    {        
        /// <summary>
        /// Счетчик для учета ведения порядкового номера теста
        /// </summary>
        public static int Counter = 0;
        /// <summary>
        /// Накопитель информации для вывода результатов в файл (может быть README)
        /// </summary>
        public static string AllDebug = "";
        /// <summary>
        /// Используется для добавления информации из трассировки в файл автоматически. 
        /// Если true - автоматическое занесение в файл.
        /// </summary>
        public static bool IsDefaultToReadme { get; set; }
        /// <summary>
        /// Фиксирование в трассировке необходимой информации по проводимому тесту
        /// </summary>
        public static void ToTrace(int[] arr, bool isOnlyTrace)//isOnlyTrace используется как идентификатор сохранения трассировки в файл
        {
            if (!isOnlyTrace) StartTest();
            TraceAndSave("Представление одномерного массива для целочисленных значений:\n\n");
            for (int i = 0; i < arr.Length; i++)
            {
                TraceAndSave($"{arr[i]} ");
            }
            TraceAndSave("\n\n");
            if (!isOnlyTrace) EndTest();
            if (!isOnlyTrace) if (IsDefaultToReadme) ToReadme();
        }
        /// <summary>
        /// Фиксирование в трассировке необходимой информации по проводимому тесту
        /// </summary>
        public static void ToTrace(double[] arr, bool isOnlyTrace)
        {
            if (!isOnlyTrace) StartTest();
            TraceAndSave("Представление одномерного массива:\n\n");
            for (int i = 0; i < arr.Length; i++)
            {
                TraceAndSave($"{arr[i]} ");
            }
            TraceAndSave("\n\n");
            if (!isOnlyTrace) EndTest();
            if (!isOnlyTrace) if (IsDefaultToReadme) ToReadme();
        }
        /// <summary>
        /// Фиксирование в трассировке необходимой информации по проводимому тесту
        /// </summary>
        public static void ToTrace(double[,] arr, bool isOnlyTrace)
        {
            if (!isOnlyTrace) StartTest();
            TraceAndSave("Представление двумерного массива:\n\n");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {                    
                    TraceAndSave($"{arr[i, j]} ");
                }
                TraceAndSave("\n\n");
            }
            TraceAndSave("\n\n");
            if (!isOnlyTrace) EndTest();
            if (!isOnlyTrace) if (IsDefaultToReadme) ToReadme();
        }
        /// <summary>
        /// Фиксирование в трассировке необходимой информации по проводимому тесту (чаще, можно использовать для классов)
        /// </summary>
        /// <param name="allAboutSomething"></param>
        public static void ToTrace(string allAboutSomething)
        {
            StartTest();
            TraceAndSave(allAboutSomething + "\n\n");//Для конца строки нужно всегда указывать \n
            EndTest();
            if (IsDefaultToReadme) ToReadme();
        }
        /// <summary>
        /// Используется для сохранения из AllDebug информации в файл, с указанием пути вручную в коде
        /// </summary>
        public static void ToReadme()
        {
            #region Поставить нужный путь
            StreamWriter writer = new StreamWriter(@"E:\Совершенствование класса TraceTransfer\PW8P1-V11-Transport\PW8P1-V11-Transport\README.md");//<--
            #endregion
            for (int i = 0; i < AllDebug.Length; i++)
            {
                writer.Write(AllDebug[i]);
            }
            writer.Close();
        }
        /// <summary>
        /// Используется для объявления начала теста
        /// </summary>
        private static void StartTest()
        {
            AllDebug += $"Test {++Counter}:\n\n";            
            Debug.WriteLine("");
        }
        /// <summary>
        /// Используется для объявления окончания теста
        /// </summary>
        private static void EndTest()
        {
            AllDebug += $"Test {Counter} окончен\n\n";
            Debug.WriteLine("");
        }
        /// <summary>
        /// Используется для сохранения информации в трассировку теста и в переменную сохранения любой строчной информации
        /// без объявления о начале или завершении теста
        /// </summary>
        /// <param name="something"></param>
        private static void TraceAndSave(string something)
        {
            AllDebug += something;
            Debug.Write(something);
        }
        /// <summary>
        /// Учет дополнительной информации (используется для unit test'a чаще всего)
        /// </summary>
        /// <param name="something"></param>
        /// <param name="isAdvancedForTest"></param>
        public static void TraceAndSave(string something, bool isAdvancedForTest)
        {
            if (isAdvancedForTest)
            {
                TraceAndSave("Дополнительно:\n\n" + something + "\n\n");    
            }
            else TraceAndSave(something);
        }
        /// <summary>
        /// Добавление заголовка в README (чаще используется на старте работы)
        /// </summary>
        /// <param name="header"></param>
        public static void GiveHeaderToReadme(string header)
        {
            AllDebug += "# " + header;
            AllDebug += "\n\n";
        }
        /// <summary>
        /// Добавление номеров строк последовательности к строкам
        /// </summary>
        /// <param name="info"></param>
        public static void GiveNumberStrings(string[] info)
        {
            for (int i = 1; i <= info.Length; i++)
            {
                AllDebug += i + "." + " " + info.GetValue(i - 1);
                AllDebug += "\n";
            }
            AllDebug += "\n\n";
        }
        /// <summary>
        /// Добавление точек беред каждой строкой (для README)
        /// </summary>
        /// <param name="info"></param>
        public static void GivePointStrings(string[] info)
        {
            for (int i = 1; i <= info.Length; i++)
            {
                AllDebug += "*" + " " + info.GetValue(i - 1);
                AllDebug += "\n";
            }
            AllDebug += "\n\n";
        }
        /// <summary>
        /// Создание таблицы для README
        /// </summary>
        /// <param name="headers"></param>
        /// <param name="values"></param>
        public static void GiveStringsToTable(string[] headers, string[] values)
        {
            for (int i = 0; i < headers.Length; i++)
            {
                AllDebug += headers.GetValue(i) + "|";                
            }
            AllDebug += "\n";
            for (int i = 0; i < headers.Length; i++)
            {
                AllDebug += "-|";
            }
            AllDebug += "\n";
            for (int i = 0; i < values.Length; i++)
            {
                AllDebug += values.GetValue(i) + "|";
                if ((i + 1) % headers.Length == 0 && i != 0) AllDebug += "\n";
            }
            AllDebug += "\n\n";
        }
        /// <summary>
        /// Добавление горизонтального разделителя для заголовка
        /// </summary>
        public static void GiveHorizontalSeparator()
        {
            AllDebug += "----------------------------------";
            AllDebug += "\n\n";//В конце всегда 2 \n для отделение пустым параграфом
        }
        //Раскомментировать, если потребуется, так как необходимо для элемента DataTable добавить ссылку в тестовый проект на PresentationFramework.dll
        public static void DataGridTraceView(DataTable table, bool isOnlyTrace)
        {
            if (!isOnlyTrace) StartTest();
            TraceAndSave("DataTable представление:\n\n");
            for (int i = 0; i < table.Rows.Count; i++)
            {
                var row = table.Rows[i];
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    TraceAndSave($"{row[j]} ");
                }
                TraceAndSave("\n\n");
            }
            TraceAndSave("\n\n");
            if (!isOnlyTrace) EndTest();
            if (!isOnlyTrace) if (IsDefaultToReadme) ToReadme();
        }
    }
}
