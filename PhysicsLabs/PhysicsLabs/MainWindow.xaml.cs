using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Ph = PhysicsLabs.Labs.ten;
using System.Windows.Threading;
using System.Threading;

namespace PhysicsLabs
{
    public partial class MainWindow : Window
    {
        public MainWindow(bool f)
        { 
            InitializeComponent();
        }

        public MainWindow()
        {
            //Splash();
            InitializeComponent();
        }

        private bool Splash()
        {
            var time = new TimeSpan(0, 0, 3);
            SplashScreen splashScreen = new SplashScreen("Pictures/Splash.png");
            splashScreen.Show(false);
            splashScreen.Close(time);
            Thread.Sleep(4000);
            return true;
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
            if (LabCb.SelectedItem == null && GradeCb.SelectedItem != null)
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

            if (GradeCb.SelectedItem != null)
            {
                LabCb.IsEnabled = true;
                LabLb.IsEnabled = true;
            }
            if (GradeCb.SelectedItem == GradeCb.Items[1])
            { 
                LabCb.Items.Add("Изучение движения тел по окружности под действием силы упругости и тяжести.");
                LabCb.Items.Add("Экспериментальное изучение закона сохранения механической энергии.");
                LabCb.Items.Add("Опытная проверка закона Гей-Люссака.");
                LabCb.Items.Add("Изучение законов последовательного и параллельного соединений проводников.");
                LabCb.Items.Add("Измерение ЭДС и внутреннего сопротивления источника тока.");
            }   
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (LabCb.SelectedItem == LabCb.Items[0])
            {
                Ph.tenOne.tenOne tenOne = new Ph.tenOne.tenOne();
                this.Close();
                tenOne.Show();
            }
            
            if(LabCb.SelectedItem == LabCb.Items[1])
            {
                Ph.tenTwo.tenTwo tenTwo = new Ph.tenTwo.tenTwo();
                this.Close();
                tenTwo.Show();
            }
            if(LabCb.SelectedItem == LabCb.Items[2])
            {
                Ph.tenThree.tenThree tenThree = new Ph.tenThree.tenThree();
                this.Close();
                tenThree.Show();
            }
            if(LabCb.SelectedItem == LabCb.Items[3])
            {
                Ph.tenFour.tenFour tenFour = new Ph.tenFour.tenFour();
                this.Close();
                tenFour.Show();
            }
            
        }

        private void LabCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LabCb.SelectedItem != null)
                Btn.IsEnabled = true;
            else
                Btn.IsEnabled = false;
        }
    }
}
