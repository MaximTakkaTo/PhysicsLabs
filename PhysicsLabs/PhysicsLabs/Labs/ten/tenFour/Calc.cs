using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsLabs.Labs.ten.tenFour
{
    static class Calc
    {
        public static void CalculPosl(double[]data, out double R1, out double R2, out double R, out double U, out double att1,out double att2)
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
            R = R1 + R2;
            I = data[0] + data[1];
            att1 = data[0] / data[1];
            att2 = R2 / R1;
        }
        public static void Out()
        {

        }
    }
}
