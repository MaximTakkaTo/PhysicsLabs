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
using System.Windows.Shapes;
using PhysicsLabs;
using WpfMath;

namespace PhysicsLabs.Labs
{
    public partial class TenOne : Window
    { 
        public TenOne()
        {
            InitializeComponent();
            reference();
        }

        private void reference()
        {
            string goal, equip, progr, inputdata,outputdata;
            goal = "ЦЕЛЬ РАБОТЫ: \n Определение центростремительного ускорения шарика при его равномерном движении по окружности.\n";
            equip = "\nОБОРУДОВАНИЕ:\n Штатив с муфтой и лапкой, лента измерительная, циркуль, динамометр лабораторный, весы с разновесами, шарик на нити, кусочек пробки с отверстием, лист бумаги, линейка.\n";
            progr = "\nХОД РАБОТЫ:\n1. Приведем груз во вращение по нарисованной окружности радиуса R.Измеряем радиус с точностью 1 см. Измерим время t, за которое тело совершит N оборотов.\n2. Определяем высоту конического маятника h по вертикали от центра шарика до точки подвеса.\n3. Оттягиваем горизонтально расположенным динамометром шарик на расстояние, равное радиусу окружности и измеряем модуль составляющей F1 , массу шарика.\n";
            inputdata = "\nВХОДНЫЕ ДАННЫЕ: \nr - радиус нарисованной окружности в САНТИМЕТРАХ.\nN - количество оборотов. \nt - время,за которое шарик совершит n оборотов,в СЕКУНДАХ. \nh - высота конеческого маятника в САНТИМЕТРАХ. \nm - масса шарика в ГРАММАХ.\nF1 - силла ,с которой оттянут шарик , в НЬЮТОНАХ.\n";
            outputdata = "\nВЫХОДНЫЕ ДАННЫЕ: \nT - период вращения шарика.\na1,a2,a3 - центростремительные ускорения, найденные 3-мя разными способами.";
            MessageBox.Show(goal + equip + progr + inputdata + outputdata + "\n\nВы можете вызвать справку о лабараторной работе кнопкой,расположенной в нижнем правом углу.", "Изучение движения тел по окружности под действием силы упругости и тяжести");
        }

        private void referenceBtn_Click(object sender, RoutedEventArgs e) => reference();

        private void caclBtn_Click(object sender, RoutedEventArgs e)
        {
            double radius, N, time, height, weight, force, a1, a2, a3, T;

            string eror = "Некорректно введенные данные : ";
            int er = 0;

            //Проверка на корректность данных
            if (!double.TryParse(radTb.Text, out radius))
            {
                radLb.Foreground = System.Windows.Media.Brushes.Red;
                radTb.Clear();
                eror += "Радиус - r";
                er++;
            }
            else
                radLb.Foreground = System.Windows.Media.Brushes.Black;

            if (!double.TryParse(obTb.Text, out N))
            {
                obLb.Foreground = System.Windows.Media.Brushes.Red;
                obTb.Clear();
                if (er != 0)
                    eror += "  ,";
                eror += " Количество оборотов - N";
                er++;
            }
            else
                obLb.Foreground = System.Windows.Media.Brushes.Black;

            if (!double.TryParse(timeTb.Text, out time))
            {
                timeLb.Foreground = System.Windows.Media.Brushes.Red;
                timeTb.Clear();
                if (er != 0)
                    eror += "  ,";
                eror += " Время - t";
                er++;
            }
            else
                timeLb.Foreground = System.Windows.Media.Brushes.Black;

            if (!double.TryParse(heightTb.Text, out height))
            {
                heightLb.Foreground = System.Windows.Media.Brushes.Red;
                heightTb.Clear();
                if (er != 0)
                    eror += "  ,";
                eror += " Высота - h";
                er++;
            }
            else
            {
                heightLb.Foreground = System.Windows.Media.Brushes.Black;
            }

            if (!double.TryParse(weightTb.Text, out weight))
            {
                weightLb.Foreground = System.Windows.Media.Brushes.Red;
                weightTb.Clear();
                if (er != 0)
                    eror += "  ,";
                eror += " Масса - m";
                er++;
            }
            else
            {
                weightLb.Foreground = System.Windows.Media.Brushes.Black;
            }

            if (!double.TryParse(forceTb.Text, out force))
            {
                forceLb.Foreground = System.Windows.Media.Brushes.Red;
                forceTb.Clear();
                if (er != 0)
                    eror += "  ,";
                eror += " Сила - F";
                er++;
            }
            else
            {
                forceLb.Foreground = System.Windows.Media.Brushes.Black;
            }


            if (er == 0 )
            {
                Calculator.calcTenOne(radius,N,time,height,weight,force,out T, out a1, out a2, out a3);
                output(radius, N, time, height, weight, force ,T, a1, a2, a3);
                Console.WriteLine(radius.ToString(),"    ", height,"   ",a1);
            }
            else
            {
                eror += ".";
                MessageBox.Show(eror, "Некорректно введенные данные");

            }

        }

        private void output (double radius, double N, double time, double height, double weight, double F,double T, double a1,double a2,double a3)
        {
            formula1.Formula = "T = \\frac{"+ time + "}" + "{"+ N +"} = " + T + "C";
            formula2.Formula = "a_{1} = \\frac{4 \\pi^2" + radius + "}{" + T + "^{2}} = " + a1.ToString("#.##") + "\\frac{M}{C^2}";
        }


    }
}
