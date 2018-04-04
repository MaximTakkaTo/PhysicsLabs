using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PhysicsLabs
{
    public partial class Konstructor : Window
    {
        string NameOfLab;
        TextBox nameTb = new TextBox();
        Label nameLb = new Label();
        Button enterBtn = new Button();

        string[] NameOfValue = new string[10];
        string[] Meassure = new string[10];
        float[] Value = new float[10];

        TextBox[] NameOfValTb = new TextBox[10];
        Label[] NameOfValLb = new Label[10];

        TextBox[] MeassTb = new TextBox[10];
        Label[] MeassLb = new Label[10];

        Button addBtn = new Button();
        Button entBtn = new Button();

        bool f1 = false;

        int k = 0;

        public Konstructor()
        {
            InitializeComponent();
            /*
            StreamReader sr = new StreamReader("userLabs.data");
            if (sr.ReadToEnd() == "")
            {
                sr.Close();
                MessageBox.Show("Ранее созданные пользовательские лабораторные работы не обнаружены. Создайте первую!");
                Create();
            }
            */
            Create();
        }

        public void Create()
        {
            nameTb.VerticalAlignment = VerticalAlignment.Center;
            nameTb.HorizontalAlignment = HorizontalAlignment.Center;
            nameTb.Width = 200;
            nameTb.FontSize = 18;

            nameLb.VerticalAlignment = VerticalAlignment.Center;
            nameLb.HorizontalAlignment = HorizontalAlignment.Center;
            nameLb.Margin = new Thickness(0, 0, 0, 50);
            nameLb.Content = "Введите название лабораторной:";
            nameLb.FontSize = 18;

            enterBtn.HorizontalAlignment = HorizontalAlignment.Center;
            enterBtn.VerticalAlignment = VerticalAlignment.Center;
            enterBtn.Margin = new Thickness(0, 70, 0, 0);
            enterBtn.Content = "OK";
            enterBtn.FontSize = 15;
            enterBtn.Width = 90;
            enterBtn.Click += enterBtn_Click;

            g.Children.Add(nameLb);
            g.Children.Add(nameTb);
            g.Children.Add(enterBtn);
        }

        public void enterBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameTb.Text))
            {
                NameOfLab = nameTb.Text;
                File.AppendAllText("userLabs.data",nameTb.Text + Environment.NewLine);
                foreach (string line in File.ReadLines("userLabs.data")) ;
                this.Width = 425;
                this.Height = 425;
                double screenHeight = SystemParameters.FullPrimaryScreenHeight;
                double screenWidth = SystemParameters.FullPrimaryScreenWidth;
                this.Top = (screenHeight - this.Height) / 2;
                this.Left = (screenWidth - this.Width) / 2;
                g.Children.Clear();

                Label title = new Label();
                title.HorizontalAlignment = HorizontalAlignment.Center;
                title.VerticalAlignment = VerticalAlignment.Top;
                title.FontSize = 18;
                title.Content = "Добавьте входные данные:";
                title.FontWeight = FontWeights.Bold;
                title.Margin = new Thickness(0, 10, 0, 0);

                NameOfValLb[0] = new Label();
                NameOfValLb[0].HorizontalAlignment = HorizontalAlignment.Left;
                NameOfValLb[0].VerticalAlignment = VerticalAlignment.Top;
                NameOfValLb[0].Content = "Символьное обозначение:";
                NameOfValLb[0].FontSize = 15;
                NameOfValLb[0].Margin = new Thickness(15, 45, 0, 0);

                MeassLb[0] = new Label();
                MeassLb[0].HorizontalAlignment = HorizontalAlignment.Left;
                MeassLb[0].VerticalAlignment = VerticalAlignment.Top;
                MeassLb[0].Content = "Ед. измерения:";
                MeassLb[0].FontSize = 15;
                MeassLb[0].Margin = new Thickness(245, 45, 0, 0);

                NameOfValTb[0] = new TextBox();
                NameOfValTb[0].KeyDown += TextBox_KeyDown;
                NameOfValTb[0].HorizontalAlignment = HorizontalAlignment.Left;
                NameOfValTb[0].VerticalAlignment = VerticalAlignment.Top;
                NameOfValTb[0].FontSize = 15;
                NameOfValTb[0].Margin = new Thickness(210, 50, 0, 0);
                NameOfValTb[0].Width = 30;

                MeassTb[0] = new TextBox();
                MeassTb[0].KeyDown += TextBox1_KeyDown;
                MeassTb[0].HorizontalAlignment = HorizontalAlignment.Left;
                MeassTb[0].VerticalAlignment = VerticalAlignment.Top;
                MeassTb[0].FontSize = 15;
                MeassTb[0].Margin = new Thickness(357, 50, 0, 0);
                MeassTb[0].Width = 30;

                addBtn.HorizontalAlignment = HorizontalAlignment.Right;
                addBtn.VerticalAlignment = VerticalAlignment.Bottom;
                addBtn.Margin = new Thickness(0, 0, 130, 20);
                addBtn.Width = 100;
                addBtn.FontSize = 15;
                addBtn.Content = "Добавить";
                addBtn.Click += Values;

                entBtn.HorizontalAlignment = HorizontalAlignment.Right;
                entBtn.VerticalAlignment = VerticalAlignment.Bottom;
                entBtn.Click += ValueEnd;
                entBtn.Margin = new Thickness(0, 0, 25, 20);
                entBtn.Width = 100;
                entBtn.FontSize = 15;
                entBtn.Content = "Завершить";
                

                g.Children.Add(title);
                g.Children.Add(NameOfValLb[0]);
                g.Children.Add(NameOfValTb[0]);
                g.Children.Add(MeassLb[0]);
                g.Children.Add(MeassTb[0]);
                g.Children.Add(entBtn);
                g.Children.Add(addBtn);
                k++;
            }
            else
                MessageBox.Show("Введите корректное название лабораторной");
        }

        public void Values(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < k; i++)
            {
                if (NameOfValTb[k - 1].Text == NameOfValue[i])
                {
                    MessageBox.Show("Величина с таким обозначением уже существует.");
                    NameOfValLb[k - 1].Foreground = new SolidColorBrush(Colors.Red);
                    NameOfValTb[k - 1].Clear();
                    f1 = true;
                    break;
                }
                else
                {
                    f1 = false;
                    NameOfValLb[k - 1].Foreground = new SolidColorBrush(Colors.Black);
                }
            }
            if (!f1)
            {
                if ((!string.IsNullOrWhiteSpace(NameOfValTb[k - 1].Text) && !string.IsNullOrWhiteSpace(MeassTb[k - 1].Text)))
                {

                    NameOfValLb[k] = new Label();
                    NameOfValLb[k].HorizontalAlignment = HorizontalAlignment.Left;
                    NameOfValLb[k].VerticalAlignment = VerticalAlignment.Top;
                    NameOfValLb[k].Content = "Символьное обозначение:";
                    NameOfValLb[k].FontSize = 15;
                    NameOfValLb[k].Margin = new Thickness(15, 45 + (k * 30), 0, 0);

                    MeassLb[k] = new Label();
                    MeassLb[k].HorizontalAlignment = HorizontalAlignment.Left;
                    MeassLb[k].VerticalAlignment = VerticalAlignment.Top;
                    MeassLb[k].Content = "Ед. измерения:";
                    MeassLb[k].FontSize = 15;
                    MeassLb[k].Margin = new Thickness(245, 45 + (k * 30), 0, 0);

                    NameOfValTb[k] = new TextBox();
                    NameOfValTb[k].KeyDown += TextBox_KeyDown;
                    NameOfValTb[k].HorizontalAlignment = HorizontalAlignment.Left;
                    NameOfValTb[k].VerticalAlignment = VerticalAlignment.Top;
                    NameOfValTb[k].FontSize = 15;
                    NameOfValTb[k].Margin = new Thickness(210, 50 + (k * 30), 0, 0);
                    NameOfValTb[k].Width = 30;

                    MeassTb[k] = new TextBox();
                    MeassTb[k].KeyDown += TextBox1_KeyDown;
                    MeassTb[k].HorizontalAlignment = HorizontalAlignment.Left;
                    MeassTb[k].VerticalAlignment = VerticalAlignment.Top;
                    MeassTb[k].FontSize = 15;
                    MeassTb[k].Margin = new Thickness(357, 50 + (k * 30), 0, 0);
                    MeassTb[k].Width = 30;

                    g.Children.Add(NameOfValLb[k]);
                    g.Children.Add(NameOfValTb[k]);
                    g.Children.Add(MeassLb[k]);
                    g.Children.Add(MeassTb[k]);

                    NameOfValTb[k - 1].IsEnabled = false;
                    MeassTb[k - 1].IsEnabled = false;
                    NameOfValue[k - 1] = NameOfValTb[k - 1].Text;
                    Meassure[k - 1] = MeassTb[k - 1].Text;

                    k++;
                }
                else
                    MessageBox.Show("Заполните все поля.");

                if (k == 10)
                    addBtn.IsEnabled = false;
            }            
        }
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (NameOfValTb[k - 1].Text.Length == 3)
                e.Handled = true;
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (MeassTb[k - 1].Text.Length == 3)
                e.Handled = true;
        }
        private void ValueEnd(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < k; i++)
            {
                if (NameOfValTb[k - 1].Text == NameOfValue[i])
                {
                    MessageBox.Show("Величина с таким обозначением уже существует.");
                    NameOfValLb[k - 1].Foreground = new SolidColorBrush(Colors.Red);
                    NameOfValTb[k - 1].Clear();
                    f1 = true;
                    break;
                }
                else
                {
                    f1 = false;
                    NameOfValLb[k - 1].Foreground = new SolidColorBrush(Colors.Black);
                }
            }
            if (!f1)
            {
                if ((!string.IsNullOrWhiteSpace(NameOfValTb[k - 1].Text) && !string.IsNullOrWhiteSpace(MeassTb[k - 1].Text)))
                {
                    NameOfValTb[k - 1].IsEnabled = false;
                    MeassTb[k - 1].IsEnabled = false;
                    NameOfValue[k - 1] = NameOfValTb[k - 1].Text;
                    Meassure[k - 1] = MeassTb[k - 1].Text;
                    g.Children.Clear();
                    Directory.CreateDirectory(NameOfLab);
                    for (int i = 0; i < k; i++)
                    {
                        File.AppendAllText(NameOfLab + "//NamesOfValues.data", NameOfValue[i]  + Environment.NewLine);
                        File.AppendAllText(NameOfLab + "//MeassuresOfValues.data", Meassure[i] + Environment.NewLine);
                    }
                }
                else
                    MessageBox.Show("Заполните все поля.");
            }
        }
    }
}