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
using System.Windows.Shapes;
using ListClass.Classes;

namespace ListClass
{
    /// <summary>
    /// Логика взаимодействия для WindowAddPreparate.xaml
    /// </summary>
    public partial class WindowAddPreparate : Window
    {
        int mode;
        public WindowAddPreparate()
        {
            InitializeComponent();
            mode = 0;
        }
        public WindowAddPreparate(STUDENT students)
        {
            InitializeComponent();
            TxbName.Text = students.Name;
            TxbGroup.Text = students.Group;
            TxbMath.Text = students.Math.ToString();
            TxbHistory.Text = students.History.ToString();
            TxbPhysics.Text = students.Physics.ToString();
            TxbObzh.Text = students.Obzh.ToString();
            TxbFrench.Text = students.French.ToString();
            mode = 1;
            BtnAddPreparate.Content = "Сохранить";
        }
        /// <summary>
        /// Привязка полей для добавления
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void BtnAddPreparate_Click(object sender, RoutedEventArgs e)
        {
            if (int.Parse(TxbMath.Text) < 0)
            {
                MessageBox.Show("Количество не может быть отрицательным", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                TxbMath.Clear();
                TxbMath.Focus();
                return;
            }
            if (double.Parse(TxbHistory.Text) < 0)
            {
                MessageBox.Show("Цена не может быть отрицательным", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                TxbHistory.Clear();
                TxbHistory.Focus();
                return;
            }
            if (int.Parse(TxbPhysics.Text) < 0)
            {
                MessageBox.Show("Месяц не может быть отрицательным", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                TxbPhysics.Clear();
                TxbPhysics.Focus();
                return;
            }
            if (int.Parse(TxbObzh.Text) < 0)
            {
                MessageBox.Show("Месяц не может быть отрицательным", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                TxbObzh.Clear();
                TxbObzh.Focus();
                return;
            }
            if (int.Parse(TxbFrench.Text) < 0)
            {
                MessageBox.Show("Месяц не может быть отрицательным", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                TxbFrench.Clear();
                TxbFrench.Focus();
                return;
            }
            if (mode == 0)
            {
                try
                {
                    STUDENT student = new STUDENT()
                    {
                        Name = TxbName.Text,
                        Group = TxbGroup.Text,
                        Math = int.Parse(TxbMath.Text),
                        History = int.Parse(TxbHistory.Text),
                        Physics = int.Parse(TxbPhysics.Text),
                        Obzh = int.Parse(TxbObzh.Text),
                        French = int.Parse(TxbFrench.Text),
                    };
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Проверьте входные данные: {ex}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                try
                {
                    for (int i = 0; i < ConnectHelper.student.Count; i++)
                    {
                        if (ConnectHelper.student[i].Name == TxbName.Text)
                        {
                            ConnectHelper.student[i].Group = TxbGroup.Text;
                            ConnectHelper.student[i].Math =int.Parse(TxbMath.Text);
                            ConnectHelper.student[i].History= int.Parse(TxbHistory.Text);
                            ConnectHelper.student[i].Physics = int.Parse(TxbPhysics.Text);
                            ConnectHelper.student[i].Obzh = int.Parse(TxbObzh.Text);
                            ConnectHelper.student[i].French = int.Parse(TxbFrench.Text);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Проверьте входные данные: {ex}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            ConnectHelper.SaveListToFile(ConnectHelper.filename);
            this.Close();
        }
    }
}
