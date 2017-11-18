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
            double a1, a2, a3, T;

            string eror;
            int er = 0;
            TextBox[] tb ={radTb,obTb,timeTb,heightTb,weightTb,forceTb };
            Label[] lb = { radLb, obLb, timeLb, heightLb, weightLb, forceLb }; 
            double[] data = new double[6];

            Calculator.inputData(tb, lb, data, out eror, out er);
            if (er == 0)
            {
                Calculator.calcTenOne(data, out T, out a1, out a2, out a3);
                output(data, T, a1, a2, a3);
            }
            else
            {
                
                MessageBox.Show(eror);
            }



        }

        private void chngBtn_Click(object sender, RoutedEventArgs e)
        {
            onComponents();
        }

        private void output(double[]data,double T, double a1, double a2, double a3)
        {
            offComponents();
            string cT,cA1,cA2,cA3,conc ;
            cT = "T = \\frac{t}{N}" + " = \\frac{" + data[2]+ "}" + "{" + data[1] + "} = " + T.ToString("0.###") + "C";
            cA1 = "a_{1} = " + "\\frac{4\\pi^2R}{T^2} " + " = \\frac{4 \\pi^2 *" + (data[0] / 100).ToString("0.###") + "}{" + T.ToString("0.###") + "^{2}} = " + a1.ToString("0.###") + "\\frac{M}{C^2}";
            cA2 = "a_{2} = " + " \\frac{gR}{h}" + " = \\frac{g * " + (data[0] / 100).ToString("0.###") + "}{" + (data[3]/ 100).ToString("0.###") + "} = " + a2.ToString("0.###") + "\\frac{M}{C^2}";
            cA3 = "a_{3} = \\frac {F_{1}}{m}" + " = \\frac{" + data[5].ToString() + "}{" + (data[4] / 1000).ToString("0.###") + "} =" + a3.ToString("0.###") + "\\frac{M}{C^2}";

            formula1.Formula = cT;
            formula2.Formula = cA1;
            formula3.Formula = cA2;
            formula4.Formula = cA3;
            if (a1.ToString()[0] == a2.ToString()[0] && a1.ToString()[0] == a3.ToString()[0])
                conc = "Вывод : сравнивая полученные три значения модуля центростремительного ускорения : a1 = " + a1.ToString("0.###") + ";a2 = " + a2.ToString("0.###") + "; a3 = " + a3.ToString("0.###") + ", убеждаемся, что они примерно одинаковы.Это подтверждает правильность ваших измерений.";
            else
                conc = "Вывод : сравнивая полученные три значения модуля центростремительного ускорения : a1 = " + a1.ToString("0.###") + ";\na2 = " + a2.ToString("0.###") + "; a3 = " + a3.ToString("0.###") +", убеждаемся, что они неравны => проверьте точность и правильность своих измерений.Читайте справку по лабораторной.";
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
