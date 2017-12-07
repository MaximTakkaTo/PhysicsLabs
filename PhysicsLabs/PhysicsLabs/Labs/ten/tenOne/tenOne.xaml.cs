using System.Windows;
using System.Windows.Controls;


namespace PhysicsLabs.Labs.ten.tenOne
{
    public partial class tenOne : Window
    {
        TextBox[] tb = new TextBox[6];
        Label[] lb = new Label[6];
        Button[] btn = new Button[4];

        public tenOne()
        {
            InitializeComponent();
            string[] bCont = { "Рассичтать", "Изменить данные", "Вернуться к выбору лаб.", "Справка" };
            string[] cont = { "Радиус - r, СМ :", "Количество оборотов - N :", "Время - t, С :", "Высота - h, СМ :", "Масса - m, ГР :", "Сила - F1, Н :" };
            string[] hint = { "Радиус - r", "Количество оборотов - N", "Время - t", "Высота - h", "Масса - m", "Сила - F1" };
            Form.InComp(tb, lb, btn, bCont, cont, hint, mGrid);

            btn[0].Click += calcBtn_Click;
            btn[1].Click += chngBtn_Click;
            btn[2].Click += backBtn_Click;
            btn[3].Click += refBtn_Click;

            reference();

        }

        private void reference()
        {
            string goal, equip, progr, inputdata, outputdata, refer ;

            goal = "ЦЕЛЬ РАБОТЫ: \n Определение центростремительного ускорения шарика при его равномерном движении по окружности.\n";
            equip = "\nОБОРУДОВАНИЕ:\n Штатив с муфтой и лапкой, лента измерительная, циркуль, динамометр лабораторный, весы с разновесами, шарик на нити, кусочек пробки с отверстием, лист бумаги, линейка.\n";
            progr = "\nХОД РАБОТЫ:\n1. Приведем груз во вращение по нарисованной окружности радиуса R.Измеряем радиус с точностью 1 см. Измерим время t, за которое тело совершит N оборотов.\n2. Определяем высоту конического маятника h по вертикали от центра шарика до точки подвеса.\n3. Оттягиваем горизонтально расположенным динамометром шарик на расстояние, равное радиусу окружности и измеряем модуль составляющей F1 , массу шарика.\n";
            inputdata = "\nВХОДНЫЕ ДАННЫЕ: \nr - радиус нарисованной окружности в САНТИМЕТРАХ.\nN - количество оборотов. \nt - время,за которое шарик совершит n оборотов,в СЕКУНДАХ. \nh - высота конеческого маятника в САНТИМЕТРАХ. \nm - масса шарика в ГРАММАХ.\nF1 - силла ,с которой оттянут шарик , в НЬЮТОНАХ.\n";
            outputdata = "\nВЫХОДНЫЕ ДАННЫЕ: \nT - период вращения шарика.\na1,a2,a3 - центростремительные ускорения, найденные 3-мя разными способами.";
            refer = "\n\nВы можете вызвать справку о лабораторной работе кнопкой,расположенной в нижнем правом углу.\nВернуться в меню выбора лабороторной можно соответствующей кнопкой(НАЖАТЬ ЕЁ МОЖНО ТОЛЬКО В РЕЖИМЕ РЕДАКТИРОВАНИЯ ДАННЫХ).";

            MessageBox.Show(goal + equip + progr + inputdata + outputdata + refer, "Изучение движения тел по окружности под действием силы упругости и тяжести");
        }

        private void calcBtn_Click(object sender, RoutedEventArgs e)
        {
            double a1, a2, a3, T;
            int er = 0;
            string eror;
            string cT, cA1, cA2, cA3, conc;
            double[] data = new double[6];

            Form.InData(tb, lb, data, out eror, out er);

            if (er == 0)
            {
                offComponents();

                Calc.Calcul(data, out T, out a1, out a2, out a3);
                Calc.Out(data, T, a1, a2, a3, out cT, out cA1, out cA2, out cA3, out conc);

                formula1.Formula = cT;
                formula2.Formula = cA1;
                formula3.Formula = cA2;
                formula4.Formula = cA3;
                concTbl.Text = conc;
            }
            else
                MessageBox.Show(eror);
        }

        private void chngBtn_Click(object sender, RoutedEventArgs e) => 
            onComponents();

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mW = new MainWindow(true);
            Form.Menu(mW, this);
        }

        private void refBtn_Click(object sender, RoutedEventArgs e) => 
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
            formula4.Formula = "";
            btn[0].IsEnabled = true;
            btn[1].IsEnabled = false;
            btn[2].IsEnabled = true;
            concTbl.Visibility = Visibility.Collapsed;
        }
    }
}
