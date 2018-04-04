using System.Windows;
using System.Windows.Controls;
using System.Linq;
using System.Windows.Input;

namespace PhysicsLabs.Labs.ten.tenThree
{
    public partial class tenThree : Window
    {
        Button[] btn = new Button[4];
        TextBox[] tb1 = new TextBox[3];
        TextBox[] tb2 = new TextBox[3];
        Label[] lb1 = new Label[3];
        Label[] lb2 = new Label[3];

        double screnHeight = SystemParameters.FullPrimaryScreenHeight;
        double screenWidth = SystemParameters.FullPrimaryScreenWidth;
        double tbMar, lbMar, lbParlMar;

        public tenThree()
        {
            InitializeComponent();
            string[] bCont = { "Рассчитать", "Изменить данные", "Вернуться к выбору лаб.", "Справка" };
            string[] cont1 = { "Напряжение 1 - U1 , В :", "Напряжение 2 - U2, В :", "Сила тока - I, А :" };
            string[] cont2 = { "Сила тока 1 - I1, А :", "Сила тока 2 - I2, А :", "Напряжение - U, В :" };
            string[] hint1 = { "Напряжение 1 - U1", "Напряжение 2 - U2", "Сила тока - I" };
            string[] hint2 = { "Напряжение - U", "Сила тока 1 - I1", "Сила тока 2 - I2" };
            Form.InBtn(btn, bCont, Grid, 20);
            Form.InComp(tb1, lb1, cont1, hint1, Grid, 63, 35);
            Form.InComp(tb2, lb2, cont2, hint2, Grid, 263, 235);
            tbMar = tb2[0].Margin.Top;
            lbMar = lb2[0].Margin.Top;
            lbParlMar = parlLb.Margin.Top;
            reference();

            btn[0].Click += calcBtn_Click;
            btn[1].Click += chngBtn_Click;
            btn[2].Click += backBtn_Click;
            btn[3].Click += refBtn_Click;
        }

        private void reference()
        {
            string goal, equip, progr, inputdata, outputdata, refer;

            goal = "ЦЕЛЬ РАБОТЫ: \n Экспериментально изучить законы последовательного и параллельного соединения проводников.\nДля последовательного соединения : U = U1 + U2, R = R1 + R2, U1/U2 = R1/R2.\nДля параллельного соединения: I = I1 + I2, 1/R=1/R1 + 1/R2, I1/I2 = R2/R1.\n";
            equip = "\nОБОРУДОВАНИЕ:\n Источник тока, Два проволочных резистора, Амперметр, Вольтметр, Ключ замыкания ток, Реостат, Комплект соединительных проводников.\n";
            progr = "\nХОД РАБОТЫ:\nДля последовательного соединения проводников :\n1. Собрать цепь согласно сехме.\n2. Измерить напряжение на концах проводников(U1,U2).\n3. Измерить силу тока в цепи(I).\n\nДля параллельного соединения проводников:\n1. Собрать цепь согласно сехме.\n2. Измерить силу тока на разветвленных участках(I1, I2).\n3. Измерить напряжение в цепи(U).\n";
            inputdata = "\nВХОДНЫЕ ДАННЫЕ:\nДля последовательного соединения проводников :\n1. U1 - напряжение на концах первого проводника в ВОЛЬТАХ.\n2. U2 - напряжение на концах второго проводника в ВОЛЬТАХ.\n3. I - Сила тока в цепи в АМПЕРАХ.\n\nДля параллельного соединения проводников :\n1. I1 -  сила тока на 1 разветвленном участке в АМПЕРАХ.\n2. I2 - сила тока на 2 развлетвенном участке в АМПЕРАХ.\n3. Напряжение в цепи в ВОЛЬТАХ.";
            outputdata = "\n\nВЫХОДНЫЕ ДАННЫЕ:\nДля последовательного соединения:\n1. R1,R2 - сопротивления проводников.\n2. R - общее сопротивление в цепи.\n3. U - напряжение в цепи.\n4. Отношения U1/U2 и R1/R2.\n\nДля параллельного соединения проводников:\n1. R1,R2 - сопротивления проводников.\n2. R - общее сопротивление в цепи.\n3. I -  сила тока в цепи.\n4. Отношения I1/I2 и R2/R1";
            refer = "\n\nВы можете вызвать справку о лабораторной работе кнопкой,расположенной в нижнем правом углу.\nВернуться в меню выбора лабороторной можно соответствующей кнопкой(НАЖАТЬ ЕЁ МОЖНО ТОЛЬКО В РЕЖИМЕ РЕДАКТИРОВАНИЯ ДАННЫХ).";

            MessageBox.Show(goal + equip + progr + inputdata + outputdata + refer, "Изучение движения тел по окружности под действием силы упругости и тяжести");
        }

        private void calcBtn_Click(object sender, RoutedEventArgs e)
        {
            int er1 = 0, er2 = 0;
            string eror1, eror2;

            double[] data1 = new double[3];
            double[] data2 = new double[3];
            double pR1, pR2, pR, pU, pAtt1, pAtt2;
            double lR1, lR2, lR, lI, lAtt1, lAtt2;

            string pCR1, pCR2, pCR, pCU, pCAtt1;
            string lCR1, lCR2, lCR3, lCR4, lCI, lCAtt1, conc;

            Form.InData(tb1, lb1, data1, out eror1, out er1);
            Form.InData(tb2, lb2, data2, out eror2, out er2);


            if (er1 == 0 && er2 == 0)
            {
                offComponents();
                Calc.CalculPosl(data1, out pR1, out pR2, out pR, out pU, out pAtt1, out pAtt2);
                Calc.CalculParl(data2, out lR1, out lR2, out lR, out lI, out lAtt1, out lAtt2);
                Calc.OutPosl(data1, pR1, pR2, pR, pU, pAtt1, pAtt2, out pCR1, out pCR2, out pCR, out pCU, out pCAtt1);
                Calc.OutParl(data2, lR1, lR2, lR, lI, lAtt1, lAtt2, out lCR1, out lCR2, out lCR3, out lCR4, out lCI, out lCAtt1, out conc);
                output(pCR1, pCR2, pCR, pCU, pCAtt1, lCR1, lCR2, lCR3, lCR4, lCI, lCAtt1, conc);
            }
            if (er1 != 0 || er2 != 0)
            {
                if (er1 != 0 && er2 == 0)
                {
                    eror2 = null;
                    eror1 = "Для последовательного соединения :\n" + eror1;
                }

                else if (er2 != 0 && er1 == 0)
                {
                    eror1 = null;
                    eror2 = "Для параллельного соединения :\n" + eror2;
                }

                else if (er1 != 0 && er2 != 0)
                {
                    eror1 = "Для последовательного соединения :\n" + eror1;
                    eror2 = "\n\nДля параллельного соединения :\n" + eror2;
                }

                MessageBox.Show(eror1 + eror2);
            }
        }

        private void output(string pCR1, string pCR2, string pCR, string pCU, string pCAtt1,string lCR1, string lCR2, string lCR3, string lCR4, string lCI, string lCAtt1, string conc)
        {
                formula1.Formula = pCR1;
                formula2.Formula = pCR2;
                formula3.Formula = pCR;
                formula4.Formula = pCU;
                formula5.Formula = pCAtt1;
                formula6.Formula = lCR1;
                formula7.Formula = lCR2;
                formula8.Formula = lCR3;
                formula9.Formula = lCR4;
                formula10.Formula = lCI;
                formula11.Formula = lCAtt1;
                concTbl.Text = conc;
        }

        private void shiftDown()
        {
            this.Height += 245;
            this.Top = (screnHeight - this.Height) / 2;
            this.Left = (screenWidth - this.Width) / 2;

            foreach (TextBox tb in tb2)
            {
                tbMar += 45;
                tb.Margin = new Thickness(20, tbMar, 0, 0);
            }
            foreach (Label lb in lb2)
            {
                lbMar += 45;
                lb.Margin = new Thickness(15, lbMar, 0, 0);
            }

            lbParlMar += 45;
            parlLb.Margin = new Thickness(5, lbParlMar, 0, 0);
        }

        private void shiftUp()
        {
            this.Height -= 245;
            this.Top = (screnHeight - this.Height) / 2;
            this.Left = (screenWidth - this.Width) / 2;

            foreach(Label lb in lb2.Reverse().ToArray() )
            {
                lbMar -= 45;
                lb.Margin = new Thickness(15, lbMar, 0, 0);
            }

            foreach (TextBox tb in tb2.Reverse().ToArray())
            {
                tbMar -= 45;
                tb.Margin = new Thickness(20, tbMar, 0, 0);
            }

            lbParlMar -= 45;
            parlLb.Margin = new Thickness(5, lbParlMar, 0, 0);
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mW = new MainWindow(true);
            Form.Menu(mW, this);
        }

        private void chngBtn_Click(object sender, RoutedEventArgs e) =>
            onComponents();

        private void refBtn_Click(object sender,RoutedEventArgs e) =>
            reference();

        public void offComponents()
        {
            shiftDown();
            for (int i = 0; i < tb1.Length; i++)
                tb1[i].IsEnabled = false;
            for (int i = 0; i < tb2.Length; i++)
                tb2[i].IsEnabled = false;

            btn[0].IsEnabled = false;
            btn[1].IsEnabled = true;
            btn[2].IsEnabled = false;
            concTbl.Visibility = Visibility.Visible;
        }

        public void onComponents()
        {
            shiftUp();

            for (int i = 0; i < tb1.Length; i++)
                tb1[i].IsEnabled = true;
            for (int i = 0; i < tb2.Length; i++)
                tb2[i].IsEnabled = true;

            formula1.Formula = "";
            formula2.Formula = "";
            formula3.Formula = "";
            formula4.Formula = "";
            formula5.Formula = "";
            formula6.Formula = "";
            formula7.Formula = "";
            formula8.Formula = "";
            formula9.Formula = "";
            formula10.Formula = "";
            formula11.Formula = "";
            btn[0].IsEnabled = true;
            btn[1].IsEnabled = false;
            btn[2].IsEnabled = true;
            concTbl.Visibility = Visibility.Collapsed;
        }

        private void EnterClick(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                calcBtn_Click(new object(),new RoutedEventArgs());
        }
    }
}
