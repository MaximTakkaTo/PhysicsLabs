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
using PhysicsLabs.Labs;

namespace PhysicsLabs
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GradeLb_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (GradeCb.SelectedItem == null)
            {
                GradeLb.Visibility = Visibility.Collapsed;
                GradeCb.IsDropDownOpen = true;

            }
        }

        private void GradeCb_DropDownOpened(object sender, EventArgs e)
        {
            if (GradeCb.SelectedItem == null)
            {
                GradeLb.Visibility = Visibility.Collapsed;
                GradeCb.IsDropDownOpen = true;

            }
        }

        private void GradeCb_DropDownClosed(object sender, EventArgs e)
        {
            if (GradeCb.SelectedItem == null)
                GradeLb.Visibility = Visibility.Visible;
        }

        private void LabLb_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (LabCb.SelectedItem == null)
            {
                LabLb.Visibility = Visibility.Collapsed;
                LabCb.IsDropDownOpen = true;

            }
        }

        private void LabCb_DropDownOpened(object sender, EventArgs e)
        {
            if (LabCb.SelectedItem == null)
            {
                LabLb.Visibility = Visibility.Collapsed;
                LabCb.IsDropDownOpen = true;

            }
        }

        private void LabCb_DropDownClosed(object sender, EventArgs e)
        {
            if (LabCb.SelectedItem == null)
                LabLb.Visibility = Visibility.Visible;
        }

        private void GradeCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LabCb.Items.Clear();
            if (GradeCb.SelectedItem == GradeCb.Items[1])
            {
                LabCb.Items.Add("Изучение движения тел по окружности под действием силы упругости и тяжести.");
                LabCb.Items.Add("Экспериментальное изучение закона сохранения механической энергии.");
                LabCb.Items.Add("Опытная проверка закона Гей-Люссака.");
                LabCb.Items.Add("Изучение законов последовательного и параллельного соединений проводников.");
                LabCb.Items.Add("Измерение ЭДС и внутреннего сопротивления источника тока.");
            }
        }

        private void LabCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LabCb.SelectedItem == LabCb.Items[0])
            {
                MessageBox.Show("Переходим");
                TenOne tenOne = new TenOne();
                this.Close();
                tenOne.Show();
            }
                
        }
    }
}
