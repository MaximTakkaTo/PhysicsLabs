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
        TextBox[] tb = new TextBox[6];
        Label[] lb = new Label[6];

        public TenOne()
        {
            InitializeComponent();

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
                tb[i].Margin = new Thickness(20, t, 0, 0);
                t += 54;
            }

            lb[0].Content = "Радиус - r, СМ :";
            lb[1].Content = "Количество оборотов - N :";
            lb[2].Content = "Время - t, С :";
            lb[3].Content = "Высота - h, СМ :";
            lb[4].Content = "Масса - m, ГР :";
            lb[5].Content = "Сила - F1, Н :";

            lb[0].ToolTip = "Радиус - r";
            lb[1].ToolTip = "Количество оборотов - N";
            lb[2].ToolTip = "Время - t";
            lb[3].ToolTip = "Высота - h";
            lb[4].ToolTip = "Масса - m";
            lb[5].ToolTip = "Сила - F1";

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
                lb[i].Margin = new Thickness(15, l, 0, 0);
                l += 54;
            }

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
            int er = 0;
            string eror;
            string cT,cA1,cA2,cA3,conc;

            double[] data = new double[6];

            Calculator.inputData(tb, lb, data, out eror, out er);
            if (er == 0)
            {
                offComponents();
                Calculator.calcTenOne(data, out T, out a1, out a2, out a3);
                Calculator.tenOneOutput(data, T, a1, a2, a3,out cT,out cA1,out cA2,out cA3,out conc);
                formula1.Formula = cT;
                formula2.Formula = cA1;
                formula3.Formula = cA2;
                formula4.Formula = cA3;
                concTbl.Text = conc;
            }
            else
                MessageBox.Show(eror);
        }

        private void chngBtn_Click(object sender, RoutedEventArgs e)
        {
            onComponents();
        }

        private void offComponents()
        {
            for (int i = 0;i < tb.Length;i++)
                tb[i].IsEnabled = false;

            caclBtn.IsEnabled = false;
            chngBtn.IsEnabled = true;
            backBtn.IsEnabled = false;
            concTbl.Visibility = Visibility.Visible;
        }

        private void onComponents()
        {
            for (int i = 0; i < tb.Length; i++)
                tb[i].IsEnabled = true;

            formula1.Formula = "";
            formula2.Formula = "";
            formula3.Formula = "";
            formula4.Formula = "";
            caclBtn.IsEnabled = true;
            chngBtn.IsEnabled = false;
            backBtn.IsEnabled = true;
            concTbl.Visibility = Visibility.Collapsed;
        }
    }
}
