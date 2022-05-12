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
using ListClass.Classes;
using System.IO;
using Microsoft.Win32;

namespace ListClass
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
       // List<Pharmacy> pharmacies = new List<Pharmacy>();
        public MainWindow()
        {
            InitializeComponent();
            BtnPrint.IsEnabled = false;
            BtnSave.IsEnabled = false;
            TxtSearch.IsEnabled = false;
            BtnAdd.IsEnabled = false;
            BtnClear.IsEnabled = false;
            RbUp.IsEnabled = false;
            RbDown.IsEnabled = false;
            CmbFiltr.IsEnabled = false;


        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            DtgListSTUDENT.ItemsSource = ConnectHelper.student.ToList();
            DtgListSTUDENT.SelectedIndex = -1;
           
        }
        /// <summary>
        /// сортировка по алфавиту
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RbUp_Checked(object sender, RoutedEventArgs e)
        {
            DtgListSTUDENT.ItemsSource = ConnectHelper.student.OrderBy(x=>x.Name).ToList();
        }
        /// <summary>
        /// сортировка в обратном порядке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RbDown_Checked(object sender, RoutedEventArgs e)
        {
            DtgListSTUDENT.ItemsSource = ConnectHelper.student.OrderByDescending(x => x.Name).ToList();
        }
        /// <summary>
        /// поиск по названию
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            DtgListSTUDENT.ItemsSource = ConnectHelper.student.Where(x => 
                x.Name.ToLower().Contains(TxtSearch.Text.ToLower())).ToList();
        }

        /// <summary>
        /// фильтр по количеству
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmbFiltr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (CmbFiltr.SelectedIndex == 0)
            {
                DtgListSTUDENT.ItemsSource = ConnectHelper.student.Where(x =>
                    (x.Math+x.History+x.Obzh+x.Physics+x.French)/5 >= 2 && (x.Math + x.History + x.Obzh + x.Physics + x.French) / 5 <= 3).ToList();
                MessageBox.Show("Плохо",
                    "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
                if (CmbFiltr.SelectedIndex == 1)
            {
                DtgListSTUDENT.ItemsSource = ConnectHelper.student.Where(x =>
                    (x.Math + x.History + x.Obzh + x.Physics + x.French) / 5 >= 4 ).ToList();
                MessageBox.Show("Хорошо",
                    "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                DtgListSTUDENT.ItemsSource = ConnectHelper.student.Where(x =>
                   (x.Math + x.History + x.Obzh + x.Physics + x.French) / 5 >= 5).ToList();
                MessageBox.Show("Отлично",
                    "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowAddPreparate windowAdd = new WindowAddPreparate();
            windowAdd.ShowDialog();
        }

       

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            DtgListSTUDENT.ItemsSource = null;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowAddPreparate windowAdd = new WindowAddPreparate((sender as Button).DataContext as STUDENT);
            windowAdd.ShowDialog();
            ConnectHelper.SaveListToFile(ConnectHelper.filename);
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var resMessage = MessageBox.Show("Удалить запись?", "Подтверждение",
               MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resMessage == MessageBoxResult.Yes)
            {
                int ind = DtgListSTUDENT.SelectedIndex;
                ConnectHelper.student.RemoveAt(ind);
                DtgListSTUDENT.ItemsSource = ConnectHelper.student.ToList();
                ConnectHelper.SaveListToFile(ConnectHelper.filename);
            }

        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                if ((bool)saveFileDialog.ShowDialog())
                {
                    string file = saveFileDialog.FileName;
                    ConnectHelper.SaveListToFile(file);
                }
            }
        }
        private void BtnOpen_Click(object sender, RoutedEventArgs e)
        {
            //загрузка данных из файла

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if ((bool)openFileDialog.ShowDialog())
            {
                ConnectHelper.filename = openFileDialog.FileName;
                ConnectHelper.ReadListFromFile(ConnectHelper.filename);
                BtnPrint.IsEnabled = true;
                BtnSave.IsEnabled = true;
                TxtSearch.IsEnabled = true;
                BtnAdd.IsEnabled = true;
                BtnClear.IsEnabled = true;
                RbUp.IsEnabled = true;
                RbDown.IsEnabled = true;
                CmbFiltr.IsEnabled = true;
                RbDown.IsEnabled = true;

            }
            else
                return;
            DtgListSTUDENT.ItemsSource = ConnectHelper.student.ToList();

        }
    }
}
