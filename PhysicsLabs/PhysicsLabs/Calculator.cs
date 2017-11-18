using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace PhysicsLabs
{
    public static class Calculator
    {
        const double g = 10;

        public static void initComponents(TextBox[] tb, Label[] lb,string[] cont,string[] hint,Grid g)
        {
            int l = 30;
            int t = 58;

            for (int i = 0; i < lb.Length; i++)
            {
                lb[i] = new Label();
                lb[i].HorizontalAlignment = HorizontalAlignment.Left;
                lb[i].VerticalAlignment = VerticalAlignment.Top;
                lb[i].Width = 207;
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

        public static void inputData(TextBox[] tb, Label[] lb, double[] data, out string eror, out int er)
        {
            er = 0;
            eror = "Некорректно введенные данные: ";
            for (int i = 0; i < tb.Length; i++)
            {
                if (double.TryParse(tb[i].Text, out data[i]))
                {
                    lb[i].Foreground = System.Windows.Media.Brushes.Black;
                }
                else
                {
                    lb[i].Foreground = System.Windows.Media.Brushes.Red;
                    tb[i].Clear();
                    if (er != 0)
                        eror += "  ,";
                    eror += lb[i].ToolTip;
                    er++;
                }
            }
            eror += " .";
        }

        static public void calcTenOne (double[] data,out double T,out double a1,out double a2,out double a3)
        {
            T = data[2] / data[1];
            a1 = 4 * (3.14 * 3.14 * (data[0]/ 100) / (T * T));
            a2 = g * (data[0] / 100) / (data[3]/ 100);
            a3 = data[5] / (data[4]/ 1000);
        }

        public static void tenOneOutput(double[] data, double T, double a1, double a2, double a3 ,out string cT,out string cA1,out string cA2,out string cA3,out string conc)
        {
            cT = "T = \\frac{t}{N}" + " = \\frac{" + data[2] + "}" + "{" + data[1] + "} = " + T.ToString("0.###") + "C";
            cA1 = "a_{1} = " + "\\frac{4\\pi^2R}{T^2} " + " = \\frac{4 \\pi^2 *" + (data[0] / 100).ToString("0.###") + "}{" + T.ToString("0.###") + "^{2}} = " + a1.ToString("0.###") + "\\frac{M}{C^2}";
            cA2 = "a_{2} = " + " \\frac{gR}{h}" + " = \\frac{g * " + (data[0] / 100).ToString("0.###") + "}{" + (data[3] / 100).ToString("0.###") + "} = " + a2.ToString("0.###") + "\\frac{M}{C^2}";
            cA3 = "a_{3} = \\frac {F_{1}}{m}" + " = \\frac{" + data[5].ToString() + "}{" + (data[4] / 1000).ToString("0.###") + "} =" + a3.ToString("0.###") + "\\frac{M}{C^2}";

            if (a1.ToString()[0] == a2.ToString()[0] && a1.ToString()[0] == a3.ToString()[0])
                conc = "Вывод : сравнивая полученные три значения модуля центростремительного ускорения : a1 = " + a1.ToString("0.###") + "; a2 = " + a2.ToString("0.###") + "; a3 = " + a3.ToString("0.###") + ", убеждаемся, что они примерно одинаковы.Это подтверждает правильность ваших измерений.";
            else
                conc = "Вывод : сравнивая полученные три значения модуля центростремительного ускорения : a1 = " + a1.ToString("0.###") + ";\na2 = " + a2.ToString("0.###") + "; a3 = " + a3.ToString("0.###") + ", убеждаемся, что они неравны => проверьте точность и правильность своих измерений.Читайте справку по лабораторной.";
            
        }
    }
}
