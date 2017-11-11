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
            if (GradeCb.SelectedItem == null)
            {
                LabLb.Visibility = Visibility.Collapsed;
                LabCb.IsDropDownOpen = true;

            }
        }

        private void LabeCb_DropDownOpened(object sender, EventArgs e)
        {
            if (GradeCb.SelectedItem == null)
            {
                GradeLb.Visibility = Visibility.Collapsed;
                GradeCb.IsDropDownOpen = true;

            }
        }

        private void LabCb_DropDownClosed(object sender, EventArgs e)
        {
            if (GradeCb.SelectedItem == null)
                LabLb.Visibility = Visibility.Visible;
        }

        
    }
}
