using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsLabs
{
    public static class Calculator
    {

        const double g = 10;

        static public void calcTenOne (double radius,double N,double time,double height,double weight,double F,out double T,out double a1,out double a2,out double a3)
        {
            T = time / N;
            a1 = 4 * (3.14 * 3.14 * (radius / 100) / (T * T));
            a2 = g * (radius / 100) / (height / 100);
            a3 = F / (weight / 1000);
        }


    }
}
