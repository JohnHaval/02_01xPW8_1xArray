using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CreatingArray;
using _02_01xPW8_1xArray;
using System.Diagnostics;

namespace UnitTestForLess
{
    [TestClass]
    public class FirstUnitTest
    {
        [TestMethod]
        public void __1TestArrayCreate()
        {
            int[] arr = ArrayCreator.CreateArray(10, false);
            TraceTransfer.ToTrace(arr, true);
        }
        [TestMethod]
        public void __2TestArrayFill()
        {
            localArray = ArrayCreator.FillArray(ArrayCreator.CreateArray(10, false), new ArrayCreator.Range(0, 16));
            TraceTransfer.ToTrace(localArray, true);
        }
        static int[] localArray;
        static VisualArray visualArr = new VisualArray();
        [TestMethod]
        public void __3TestArrayToTable()
        {            
            TraceTransfer.DataGridTraceView(visualArr.CreateTable(localArray), true);
        }
        [TestMethod]
        public void __4TestArrayFromTable()
        {
            TraceTransfer.DataGridTraceView(visualArr.CreateTable(localArray), true);
            TraceTransfer.ToTrace(visualArr.GetOneArray(), true);
        }
        [TestMethod]
        public void __5TestLessFinderWithFill()//Должно быть A(3)4+A(8)9
        {
            FindLessWithManualValues();
        }
        [TestMethod]
        public void __6TestLessFinderWith0()//Должно быть A(0)1+A(5)6
        {
            FindLessWith0();
        }
        [TestMethod]
        public void __7FindLessCheckPropertiesClear()
        {
            FindLessWithManualValues();
            FindLessWith0();
            FindLessWithManualValues();
        }
        [TestMethod]
        public void __8Check10RestrictionWhenMore10AndFalse()
        {
            bool ifError = false;
            try
            {
                localArray = ArrayCreator.CreateArray(14, false);
                ifError = true;
                throw new Exception();
            }
            catch 
            {
                if (ifError) throw new Exception();
                Debug.WriteLine("Переловил исключение. Условие работает исправно!");
            }
        }
        [TestMethod]
        public void __9Check10RestrictionWhenNotMore10AndTrue()
        {
            bool ifError = false;
            try
            {
                localArray = ArrayCreator.CreateArray(10, true);
                ifError = true;
                throw new Exception();
            }
            catch
            {
                if (ifError) throw new Exception();
                Debug.WriteLine("Переловил исключение. Условие работает исправно!");
            }
        }
        [TestMethod]
        public void _10Check10RestrictionWhenMore10AndTrue()
        {
            localArray = ArrayCreator.CreateArray(14, true);
            Debug.WriteLine("Условие работает исправно!");
        }
        [TestMethod]
        public void _11CheckPercent2()
        {
            bool ifError = false;
            try
            {
                localArray = ArrayCreator.CreateArray(11, true);
                ifError = true;
                throw new Exception();
            }
            catch
            {
                if (ifError) throw new Exception();
                Debug.WriteLine("Переловил исключение. Условие работает исправно!");
            }
        }
        [TestMethod]
        public void _12CheckLess10Size()
        {
            bool ifError = false;
            try
            {
                localArray = ArrayCreator.CreateArray(9, false);
                ifError = true;
                throw new Exception();
            }
            catch
            {
                if (ifError) throw new Exception();
                Debug.WriteLine("Переловил исключение. Условие работает исправно!");
            }
        }
        private void FindLessWith0()
        {
            localArray = ArrayCreator.CreateArray(10, false);
            TraceTransfer.ToTrace(localArray, true);
            Assert.IsTrue(/*Будет 0*/localArray[3] + localArray[8] == LessFinder.GetLess(localArray)/*Должно быть тоже 0*/);
            TraceTransfer.IsDefaultToReadme = false;
            TraceTransfer.ToTrace(LessFinder.ResultDescription);
        }
        private void FindLessWithManualValues()
        {
            localArray[0] = 15;
            localArray[1] = 16;
            localArray[2] = 17;
            localArray[3] = 18;
            localArray[4] = 15;
            localArray[5] = 16;
            localArray[6] = 17;
            localArray[7] = 18;
            localArray[8] = -5;
            localArray[9] = 0;
            TraceTransfer.ToTrace(localArray, true);
            Assert.IsTrue(/*Будет 13*/localArray[3] + localArray[8] == LessFinder.GetLess(localArray)/*Должно быть тоже 13*/);
            TraceTransfer.IsDefaultToReadme = false;
            TraceTransfer.ToTrace(LessFinder.ResultDescription);
        }
    }
}
