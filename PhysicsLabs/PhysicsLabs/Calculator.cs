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

        static public void calcTenOne (double[] data,out double T,out double a1,out double a2,out double a3)
        {
            T = data[2] / data[1];
            a1 = 4 * (3.14 * 3.14 * (data[0]/ 100) / (T * T));
            a2 = g * (data[0] / 100) / (data[4]/ 100);
            a3 = data[5] / (data[4]/ 1000);
        }

        static public void inputData(TextBox[] tb, Label[] lb, double[] data, out string eror, out int er)
        {
            er = 0;
            eror = "Некорректно введенные данные: ";
            for (int i = 0;i < tb.Length;i++)
            {
                if (double.TryParse(tb[i].Text,out data[i]))
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
        }
    }
}
