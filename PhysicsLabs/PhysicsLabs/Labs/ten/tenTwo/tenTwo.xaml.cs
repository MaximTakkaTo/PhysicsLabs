using System.Windows;
using System.Windows.Controls;

namespace PhysicsLabs.Labs.ten.tenTwo
{

    public partial class tenTwo : Window
    {
        TextBox[] tb = new TextBox[4];
        Label[] lb = new Label[4];
        Button[] btn = new Button[4];

        public tenTwo()
        {
            InitializeComponent();
            string[] bCont = { "Рассчитать", "Изменить данные", "Вернуться к выбору лаб.", "Справка" };
            string[] cont = { "Вес шарика - F1, Н :", "L - длина нити , СМ :", "Макс.удлинение - ΔL, СМ :", "Макс.сила упругости - Fy, Н :"};
            string[] hint = { "Вес шарика - F1", "L - длина нити", "Макс.удлинение - ΔL", "Макс.сила упругости - Fy", };

            Form.InComp(tb, lb, cont, hint, g,33,5);
            Form.InBtn(btn, bCont, g,20);

            btn[0].Click += calcBtn_Click;
            btn[1].Click += chngBtn_Click;
            btn[2].Click += backBtn_Click;
            btn[3].Click += refBtn_Click;

            reference();
        }

        private void reference()
        {
            string goal, equip, progr, inputdata, outputdata,condit,refer;

            goal = "ЦЕЛЬ РАБОТЫ: \n Научится измерять потенциальную энергию поднятого над землей тела и упруго деформированной пружины, сравнить два значения потенциальной энергии системы.\n";
            equip = "\nОБОРУДОВАНИЕ:\n Штатив с муфтой и лапкой, динамометр лабораторный с фиксатором, лента измерительная, груз на нити.\n";
            progr = "\nХОД РАБОТЫ:\n1. Определить вес шарика(груза)(F1 = m*g).\n2. Измерить длину нити L.\n3. Поднять груз до точки закрепления нити и отпустить до касания со столом,регулируя длину нити.\n4. Измерить максимальную силу упругости Fy.\n5. Измерить максимальное растяжение пружины ΔL.\n";
            inputdata = "\nВХОДНЫЕ ДАННЫЕ: \nF1 - вес шарика (груза) в НЬЮТОНАХ.\nL - длина нити в САНТИМЕТРАХ.\nΔL - максимальное удлинеие пружины в САНТИМЕТРАХ.\nFy - максимальная сила упругости в НЬЮТОНАХ.\n";
            outputdata = "\nВЫХОДНЫЕ ДАННЫЕ: \nh- высота падения.\nEp1,Ep2 - потенциальные энергии.\n";
            condit = "\nУСЛОВНЫЕ ОБОЗНАЧЕНИЯ:\nDg - Джоулей.";
            refer = "\n\nВы можете вызвать справку о лабораторной работе кнопкой,расположенной в нижнем правом углу.\nВернуться в меню выбора лабороторной можно соответствующей кнопкой(НАЖАТЬ ЕЁ МОЖНО ТОЛЬКО В РЕЖИМЕ РЕДАКТИРОВАНИЯ ДАННЫХ).";

            MessageBox.Show(goal + equip + progr + inputdata + outputdata + condit + refer ,"Экспериментальное изучение закона сохранения механической энергии.");
        }

        private void calcBtn_Click(object sender, RoutedEventArgs e)
        {
            string eror = "Некорректно введенные данные : ";
            int er = 0;
            double h, Ep1, Ep2;
            string cH, cEp1, cEp2, cTbl;
            double[] data = new double[4];

            Form.InData(tb, lb, data, out eror, out er);

            if (er == 0)
            {
                offComponents();

                Calc.Calcul(data, out h, out Ep1, out Ep2);
                Calc.Out(data, h, Ep1, Ep2, out cH, out cEp1, out cEp2, out cTbl);
                Window.Height += 70;

                formula1.Formula = cH;
                formula2.Formula = cEp1;
                formula3.Formula = cEp2;
                concTbl.Text = cTbl;
            }
            else
                MessageBox.Show(eror, "Некорректно введенные данные");
        }

        private void chngBtn_Click(object sender, RoutedEventArgs e) =>
            onComponents();

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mW = new MainWindow(true);
            Form.Menu(mW, this);
        }

        private void refBtn_Click(object sedner, RoutedEventArgs e) => 
            reference();

        public void offComponents()
        {
            for (int i = 0; i < tb.Length; i++)
                tb[i].IsEnabled = false;

            btn[0].IsEnabled = false;
            btn[1].IsEnabled = true;
            btn[2].IsEnabled = false;
            concTbl.Visibility = Visibility.Visible;
        }

        public void onComponents()
        {
            for (int i = 0; i < tb.Length; i++)
                tb[i].IsEnabled = true;

            formula1.Formula = "";
            formula2.Formula = "";
            formula3.Formula = "";
            Window.Height -= 70;
            btn[0].IsEnabled = true;
            btn[1].IsEnabled = false;
            btn[2].IsEnabled = true;
            concTbl.Visibility = Visibility.Collapsed;
        }
    }
}
