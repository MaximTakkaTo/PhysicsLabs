using System;

namespace PhysicsLabs.Labs.ten.tenOne
{
    static class Calc
    {
        const int g = 10;

        public static void Calcul(double[] data, out double T, out double a1, out double a2, out double a3)
        {
            data[0] /= 100;
            data[3] /= 100;
            data[4] /= 1000;

            T = data[2] / data[1];
            T = Math.Round(T, 3);

            a1 = 4 * (3.14 * 3.14 * data[0] / (T * T));
            a2 = g * data[0] / data[3];
            a3 = data[5] / data[4];
        }

        public static void Out(double[] data, double T, double a1, double a2, double a3, out string cT, out string cA1, out string cA2, out string cA3, out string conc)
        {
            cT = "T = \\frac{t}{N}" + " = \\frac{" + data[2] + "}" + "{" + data[1] + "} = " + T.ToString("0.###") + "C";
            cA1 = "a_{1} = " + "\\frac{4\\pi^2R}{T^2} " + " = \\frac{4 \\pi^2 *" + data[0].ToString("0.###") + "}{" + T.ToString("0.###") + "^{2}} = " + a1.ToString("0.###") + "\\frac{M}{C^2}";
            cA2 = "a_{2} = " + " \\frac{gR}{h}" + " = \\frac{g * " + data[0].ToString("0.###") + "}{" + data[3].ToString("0.###") + "} = " + a2.ToString("0.###") + "\\frac{M}{C^2}";
            cA3 = "a_{3} = \\frac {F_{1}}{m}" + " = \\frac{" + data[5].ToString() + "}{" + data[4].ToString("0.###") + "} =" + a3.ToString("0.###") + "\\frac{M}{C^2}";

            if (((Math.Abs(a1 - a2) / a1 * 100) <= 13.5) && ((Math.Abs(a1 - a3) / a1 * 100) <= 13.5))
                conc = "Сравнивая полученные три значения модуля центростремительного ускорения : a1 = " + a1.ToString("0.###") + "; a2 = " + a2.ToString("0.###") + "; a3 = " + a3.ToString("0.###") + ", убеждаемся, что они примерно одинаковы. Это подтверждает правильность ваших измерений.";
            else
                conc = "Сравнивая полученные три значения модуля центростремительного ускорения : a1 = " + a1.ToString("0.###") + "; a2 = " + a2.ToString("0.###") + "; a3 = " + a3.ToString("0.###") + ", убеждаемся, что они неравны. Проверьте точность и правильность своих измерений. Читайте справку по лабораторной.";
        }
    }
}
