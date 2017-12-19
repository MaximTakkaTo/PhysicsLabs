using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsLabs.Labs.ten.tenThree
{
    static class Calc
    {
        static bool f1 = false, f2 = false;

        public static void CalculPosl(double[] data, out double R1, out double R2, out double R, out double U, out double att1,out double att2)
        {
            R1 = data[0] / data[2];
            R2 = data[1] / data [2];
            R = R1 + R2;
            U = data[0] + data[1];
            att1 = data[0] / data[1];
            att2 = R1 / R2;

        }
        
        public static void CalculParl(double[] data, out double R1, out double R2, out double R, out double I, out double att1, out double att2)
        { 
            R1 = data[2]/data[0];
            R2 = data[2] / data[1];
            R = 1/R1 + 1/R2;
            R = 1 / R;
            I = data[0] + data[1];
            att1 = data[0] / data[1];
            att2 = R2 / R1;
        }

        public static void OutPosl(double[] data, double R1, double R2, double R, double U, double att1, double att2, out string cR1, out string cR2, out string cR, out string cU, out string cAtt)
        {
            cR1 = "R_{1} = \\frac{U_{1}}{I} = \\frac{" + data[0].ToString("0.###") + "}{" + data[2].ToString("0.###") + "} = " +  R1.ToString("0.###") + "(OM)";
            cR2 = "R_{2} = \\frac{U_{2}}{I} = \\frac{" + data[1].ToString("0.###") + "}{" + data[2].ToString("0.###") + "} = " + R2.ToString("0.###") + "(OM)";
            cR = "R = R_{1} + R_{2} = " + R1.ToString("0.###") + " + " + R2.ToString("0.###") + " = " + R.ToString("0.###") + "(OM)";
            cU = "U = U_{1} + U_{2} = " + data[0].ToString("0.###") + " + " + data[1].ToString("0.###") + " = " + U.ToString("0.###") + "V";
            if (att1 == att2)
            {
                cAtt = "\\frac{U_{1}}{U_{2}} = \\frac{R_{1}}{R_{2}} ; \\frac{" + data[0].ToString("0.###") + "}{" + data[1].ToString("0.######") + "} = \\frac{" + R1.ToString("0.######") + "}{" + R2.ToString("0.######") + "} = " + att1.ToString("0.######");
                f1 = true;
            }   
            else
                cAtt = "\\frac{U_{1}}{U_{2}} = \\frac{R_{1}}{R_{2}} ; \\frac{" + data[0].ToString("0.###") + "}{" + data[1].ToString("0.###") + "} \\neq \\frac{" + R1.ToString("0.###") + "}{" + R2.ToString("0.######") + "}";
        }
        
        public static void OutParl(double[] data, double R1, double R2, double R, double I, double att1, double att2, out string cR1, out string cR2, out string cR3, out string cR4, out string cI, out string cAtt, out string conc)
        {
            cR1 = "R_{1} = \\frac{U}{I_{1}} = \\frac{" + data[2].ToString("0.###") + "}{" + data[0].ToString("0.###") + "} = " + R1.ToString("0.###") + "(OM)" ;
            cR2 = "R_{2} = \\frac{U}{I_{2}} = \\frac{" + data[2].ToString("0.###") + "}{" + data[1].ToString("0.###") + "} = " + R2.ToString("0.###") + "(OM)";
            cR3 = "\\frac{1}{R} = \\frac{1}{R_{1}} + \\frac{1}{R_{2}} = \\frac{1}{" + R1.ToString("0.###") + "} + \\frac{1}{" + R2.ToString("0.###") + "} = " + (1/R).ToString("0.###") + "(OM)";
            cR4 =  "R = " + R.ToString("0.###") + "(OM)";
            cI = "I = I_{1} + I_{2} = " + data[0].ToString("0.###") + " + " + data[1].ToString("0.###") + " = " + I.ToString("0.###") + "A";
            if (att1 == att2)
            {
                cAtt = "\\frac{I_{1}}{I_{2}} = \\frac{R_{1}}{R_{2}} ; \\frac{" + data[0].ToString("0.###") + "}{" + data[1].ToString("0.###") + "} = \\frac{" + R1.ToString("0.########") + "}{" + R2.ToString("0.###") + "} = " + att1.ToString("0.######");
                f2 = true;
            }
            else
                cAtt = "\\frac{I_{1}}{U_{2}} = \\frac{I_{1}}{R_{2}} ; \\frac{" + data[0].ToString("0.###") + "}{" + data[1].ToString("0.###") + "} \\neq \\frac{" + R1.ToString("0.#######") + "}{" + R2.ToString("0.###") + "}";
            if (f1 && f2)
            {
                conc = "Сравнивая полученные отношения , подтверждаем справедливость законов последовательного и параллельного соединения проводников.";
            }
            else
            {
                conc = "Сравнивая полученные отношения, убеждаемся, что они неравны. Проверьте точность и правильность своих измерений.Читайте справку по лабораторной.";
            }

        }
    }
}
