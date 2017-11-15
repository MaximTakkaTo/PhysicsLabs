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
            MessageBox.Show(goal + equip + progr + inputdata + outputdata + "\n\nВы можете вызвать справку о лабараторной работе кнопкой,расположенной в нижнем правом углу.\nВернуться в меню выбора лабароторной можно соответствующей кнопкой(нажать ее можно только при редактировании данных).", "Изучение движения тел по окружности под действием силы упругости и тяжести");
        }

        private void referenceBtn_Click(object sender, RoutedEventArgs e) => reference();

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

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
                offComponents();
            }
            else
            {
                eror += ".";
                MessageBox.Show(eror, "Некорректно введенные данные");

            }

        }

        private void chngBtn_Click(object sender, RoutedEventArgs e)
        {
            onComponents();
        }

        private void output(double radius, double N, double time, double height, double weight, double F, double T, double a1, double a2, double a3)
        {
            string cT,cA1,cA2,cA3,conc ;
            cT = "T = \\frac{t}{N}" + " = \\frac{" + time + "}" + "{" + N + "} = " + T.ToString("0.###") + "C";
            cA1 = "a_{1} = " + "\\frac{4\\pi^2R}{T^2} " + " = \\frac{4 \\pi^2 *" + (radius / 100).ToString("0.###") + "}{" + T.ToString("0.###") + "^{2}} = " + a1.ToString("0.###") + "\\frac{M}{C^2}";
            cA2 = "a_{2} = " + " \\frac{gR}{h}" + " = \\frac{g * " + (radius / 100).ToString("0.###") + "}{" + (height / 100).ToString("0.###") + "} = " + a2.ToString("0.###") + "\\frac{M}{C^2}";
            cA3 = "a_{3} = \\frac {F_{1}}{m}" + " = \\frac{" + F.ToString() + "}{" + (weight / 1000).ToString("0.###") + "} =" + a3.ToString("0.###") + "\\frac{M}{C^2}";

            formula1.Formula = cT;
            formula2.Formula = cA1;
            formula3.Formula = cA2;
            formula4.Formula = cA3;
            if (a1.ToString()[0] == a2.ToString()[0] && a1.ToString()[0] == a3.ToString()[0])
                conc = "Вывод : сравнивая полученные три значения модуля центростремительного ускорения : a1 = " + a1.ToString("0.###") + ";a2 = " + a2.ToString("0.###") + "; a3 = " + a3.ToString("0.###") + ", убеждаемся, что они примерно одинаковы.Это подтверждает правильность ваших измерений.";
            else
                conc = "Вывод : сравнивая полученные три значения модуля центростремительного ускорения : a1 = " + a1.ToString("0.###") + ";\na2 = " + a2.ToString("0.###") + "; a3 = " + a3.ToString("0.###") +", убеждаемся, что они неравны => проверьте точность и правильность своих измерений.Читайте справку по лабараторной.";
            concTbl.Text = conc;
        }

        private void offComponents()
        {
            caclBtn.IsEnabled = false;
            radTb.IsEnabled = false;
            obTb.IsEnabled = false;
            timeTb.IsEnabled = false;
            heightTb.IsEnabled = false;
            weightTb.IsEnabled = false;
            forceTb.IsEnabled = false;
            chngBtn.IsEnabled = true;
            backBtn.IsEnabled = false;
            concTbl.Visibility = Visibility.Visible;
        }

        private void onComponents()
        {
            formula1.Formula = "";
            formula2.Formula = "";
            formula3.Formula = "";
            formula4.Formula = "";
            caclBtn.IsEnabled = true;
            radTb.IsEnabled = true;
            obTb.IsEnabled = true;
            timeTb.IsEnabled = true;
            heightTb.IsEnabled = true;
            weightTb.IsEnabled = true;
            forceTb.IsEnabled = true;
            chngBtn.IsEnabled = false;
            backBtn.IsEnabled = true;
            concTbl.Visibility = Visibility.Collapsed;
        }
    }
}
