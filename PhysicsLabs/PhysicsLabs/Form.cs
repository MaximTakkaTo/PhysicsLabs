using System;
using System.Windows;
using System.Windows.Controls;

namespace PhysicsLabs
{
    public static class Form
    {
        const double g = 10;
        static int l, t, b;
        /*
        public static void InComp(TextBox[] tb, Label[] lb, string[] cont, string[] hint, Grid g)
        {
            l = 5;
            t = 33;

            for (int i = 0; i < lb.Length; i++)
            {
                lb[i] = new Label();
                lb[i].HorizontalAlignment = HorizontalAlignment.Left;
                lb[i].VerticalAlignment = VerticalAlignment.Top;
                lb[i].Width = 280;
                lb[i].FontSize = 16;
                g.Children.Add(lb[i]);
            }

            for (int i = 0; i < tb.Length; i++)
            {
                tb[i] = new TextBox();
                tb[i].HorizontalAlignment = HorizontalAlignment.Left;
                tb[i].VerticalAlignment = VerticalAlignment.Top;
                tb[i].Height = 23;
                tb[i].Width = 120;
                tb[i].FontSize = 16;
                tb[i].TextWrapping = TextWrapping.Wrap;
                g.Children.Add(tb[i]);
            }

            for (int i = 0; i < tb.Length; i++)
            {
                tb[i].Margin = new Thickness(20, t, 0, 0);
                t += 54;
            }

            for (int i = 0; i < lb.Length; i++)
            {
                lb[i].Margin = new Thickness(15, l, 0, 0);
                l += 54;
            }

            for (int i = 0; i < lb.Length; i++)
                lb[i].Content = cont[i];

            for (int i = 0; i < lb.Length; i++)
                lb[i].ToolTip = hint[i];
        }
        */

        public static void InBtn(Button[] btn, string[] bCont, Grid g) 
        {
            b = 20;

            for (int i = 0; i < (btn.Length / 2); i++)
            {
                btn[i] = new Button();
                btn[i].Content = bCont[i];
                btn[i].HorizontalAlignment = HorizontalAlignment.Left;
                btn[i].VerticalAlignment = VerticalAlignment.Bottom;
                btn[i].Margin = new Thickness(b, 0, 0, 16);
                b += 118;
                btn[i].Height = 23;
                g.Children.Add(btn[i]);
            }

            b = 138;
            for (int i = 2; i < btn.Length; i++)
            {
                btn[i] = new Button();
                btn[i].Content = bCont[i];
                btn[i].HorizontalAlignment = HorizontalAlignment.Right;
                btn[i].VerticalAlignment = VerticalAlignment.Bottom;
                btn[i].Margin = new Thickness(0, 0, b, 16);
                b -= 118;
                btn[i].Height = 23;
                g.Children.Add(btn[i]);
            }

            btn[0].Width = 75;
            btn[1].Width = 107;
            btn[1].IsEnabled = false;
            btn[2].Width = 141;
            btn[3].Width = 75;

        }

        public static void InComp(TextBox[] tb, Label[] lb, string[] cont, string[] hint, Grid g, int tbMargin, int lbMargin)
        {
            for (int i = 0; i < lb.Length; i++)
            {
                lb[i] = new Label();
                lb[i].HorizontalAlignment = HorizontalAlignment.Left;
                lb[i].VerticalAlignment = VerticalAlignment.Top;
                lb[i].Width = 280;
                lb[i].FontSize = 16;
                g.Children.Add(lb[i]);
            }

            for (int i = 0; i < tb.Length; i++)
            {
                tb[i] = new TextBox();
                tb[i].HorizontalAlignment = HorizontalAlignment.Left;
                tb[i].VerticalAlignment = VerticalAlignment.Top;
                tb[i].Height = 23;
                tb[i].Width = 120;
                tb[i].FontSize = 16;
                tb[i].TextWrapping = TextWrapping.Wrap;
                g.Children.Add(tb[i]);
            }

            for (int i = 0; i < tb.Length; i++)
            {
                tb[i].Margin = new Thickness(20, tbMargin, 0, 0);
                tbMargin += 54;
            }

            for (int i = 0; i < lb.Length; i++)
            {
                lb[i].Margin = new Thickness(15, lbMargin, 0, 0);
                lbMargin += 54;
            }

            for (int i = 0; i < lb.Length; i++)
                lb[i].Content = cont[i];

            for (int i = 0; i < lb.Length; i++)
                lb[i].ToolTip = hint[i];
        }

        public static void InData(TextBox[] tb, Label[] lb, double[] data, out string eror, out int er)
        {
            er = 0;
            eror = "Некорректно введенные данные: ";

            for (int i = 0; i < tb.Length; i++)
            {
                if (double.TryParse(tb[i].Text, out data[i]))
                    lb[i].Foreground = System.Windows.Media.Brushes.Black;
                else
                {
                    lb[i].Foreground = System.Windows.Media.Brushes.Red;
                    tb[i].Clear();
                    if (er != 0)
                        eror += " , ";
                    eror += lb[i].ToolTip;
                    er++;
                }
            }
            eror += " .";
        }

        public static void Menu(Window mW, Window aW)
        {
            mW.Show();
            aW.Close();
        }
    }
}
