using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CreatingArray;

namespace _02_01xPW8_1xArray
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        VisualArray Array = new VisualArray();
        private void CreateArray_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int rowCount = Convert.ToInt32(RowCount.Text);
                if(rowCount != 1)
                    VisualArrayTable.ItemsSource = Array.CreateTable(ArrayCreator.CreateArray(rowCount, Convert.ToInt32(ColumnCount.Text))).DefaultView;
                else
                    VisualArrayTable.ItemsSource = Array.CreateTable(ArrayCreator.CreateArray(Convert.ToInt32(ColumnCount.Text))).DefaultView;
            }
            catch
            {
                MessageBox.Show("Некорректно введено значение столбцов! Смотрите подробности в справке!", "Создание", MessageBoxButton.OK, MessageBoxImage.Error);
                ControlTab.Focus();
                ColumnCount.Focus();
            }
        }
        private void FillArray_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (VisualArrayTable.ItemsSource == null) throw new Exception();
                if (Array.CurrentTable.Rows.Count != 1)
                    VisualArrayTable.ItemsSource = Array.CreateTable(ArrayCreator.FillArray(Array.GetArray(), new ArrayCreator.Range(Convert.ToInt32(FirstValue.Text), Convert.ToInt32(SecondValue.Text)))).DefaultView;
                else
                    VisualArrayTable.ItemsSource = Array.CreateTable(ArrayCreator.FillArray(Array.GetOneDoubleArray(), new ArrayCreator.Range(Convert.ToInt32(FirstValue.Text), Convert.ToInt32(SecondValue.Text)))).DefaultView;
                TableTab.Focus();
            }
            catch
            {
                MessageBox.Show("Некорректно введены значения диапазона или массива не существует!", "Ошибка данных", MessageBoxButton.OK, MessageBoxImage.Error);
                ControlTab.Focus();
            }
        }

        string CurrentCell = "";
        private void VisualArrayTable_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            int iColumn = e.Column.DisplayIndex;
            CurrentCell = Array.GetOneArray()[iColumn].ToString();
        }

        private void VisualArrayTable_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (!double.TryParse(((TextBox)e.EditingElement).Text, out _))
            {
                ((TextBox)e.EditingElement).Text = CurrentCell;
                e.Cancel = true;
            }
        }

        private void ClearArray_Click(object sender, RoutedEventArgs e)
        {
            VisualArrayTable.ItemsSource = null;
            Array.ClearTable();
            VisualArrayTable.Focus();
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Задание:\n" +
                "9. Дан одномерный массив А1, А2, …, А10 целых чисел. Получить наименьшее среди А1+А6, А2+А7, …, А5+А10.", "Справка", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void FindLess_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Result.Text = LessFinder.GetArrayMin(Array.GetArray()).ToString();
            }
            catch
            {
                MessageBox.Show("Массив не является двумерным!", "Нахождение наименьшего", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ShiftTo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                VisualArrayTable.ItemsSource = Array.CreateTable(ArraySorter.ShiftToJSort(Array.GetOneDoubleArray(), Convert.ToInt32(ShiftValue.Text))).DefaultView;
            }
            catch
            {
                MessageBox.Show("Массив не является одномерным!", "Нахождение наименьшего", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
