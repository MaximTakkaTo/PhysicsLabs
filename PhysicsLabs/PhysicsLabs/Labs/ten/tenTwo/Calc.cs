using System;

namespace PhysicsLabs.Labs.ten.tenTwo
{
    static class Calc
    {
        public static void Calcul(double[] data, out double h, out double Ep1, out double Ep2)
        {
            data[1] /= 100;
            data[2] /= 100;

            h = (data[1] + data[2]);
            h = Math.Round(h, 3);

            Ep1 = data[0] * h;
            Ep2 = (data[3] / 2) * data[2];
        }

        public static void Out(double[] data, double h, double Ep1, double Ep2, out string cH, out string cEp1, out string cEp2, out string cTbl)
        {
            cH = "h = l + \\triangle l = " + data[1].ToString("0.###") + " + " + data[2].ToString("0.###") + " = " + h.ToString("0.###") + " M";
            cEp1 = "E_{p_{1}} = F_{1} * h = " + data[0].ToString("0.###") + " * " +  h.ToString("0.###") + " = " + Ep1.ToString("0.###") + " Dg";
            cEp2 = "E_{p_{2}} = \\frac{F_{y}}{2}\\triangle l" + " = " + "\\frac{" + data[3].ToString("0.###") + "}{2} * " + data[2].ToString("0.###") + " = " + Ep2.ToString("0.###") + " Dg";

            if ((Math.Abs(Ep1 - Ep2) / Ep1 * 100) <= 13)
                cTbl = "Выполняя лабораторную работу, мы научились измерять потенциальную энергию поднятого над землей тела и упруго деформированной пружины. Сравнивая полученные потенциальные энергии Ep1 = " + Ep1.ToString("0.###") + " и Ep2 = " + Ep2.ToString("0.###") + " , убеждаемся, что они примерно одинаковы. Это подтверждает закон сохранения энергии.";
            else
                cTbl = "Сравнивая полученные потенциальные энергии Ep1 = " + Ep1.ToString("0.###") + " и Ep2 = " + Ep2.ToString("0.###") + " , убеждаемся, что они неравны. Проверьте точность и правильность своих измерений. Читайте справку по лабораторной.";
        }
    }
}
