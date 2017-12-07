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

namespace PhysicsLabs.Labs.ten.tenFour
{
    public partial class tenFour : Window
    {
        Button[] btn = new Button[4];
        TextBox[] tb1 = new TextBox[4];
        TextBox[] tb2 = new TextBox[4];
        Label[] lb1 = new Label[4];
        Label[] lb2 = new Label[4];

        public tenFour()
        {
            InitializeComponent();
            string[] bCont = { "Рассичтать", "Изменить данные", "Вернуться к выбору лаб.", "Справка" };
            string[] cont = { "Напряжение 1 - U1, В","Напряжение 2 - U2, В", "Сила тока 1 - I1, А","Сила тока 2 - I2, А"};
            string[] hint = { "Напряжение 1 - U1", "Напряжение 2 - U2", "Сила тока 1 - I1", "Сила тока 2 - I2" };
            Form.InComp(tb1, lb1, btn, bCont, cont, hint, Grid);
            Form.InComp(tb2, lb2, cont, hint, Grid, 200, 195);
            reference();

            btn[0].Click += calcBtn_Click;
            btn[2].Click += backBtn_Click;
        }

        private void reference()
        {
            string goal, equip, progr, inputdata, outputdata, refer;

            goal = "ЦЕЛЬ РАБОТЫ: \n Экспериментально изучить законы последовательного и параллельного соединения проводников.\n  Для последовательного соединения : U = U1 + U2, R = R1 + R2, U1/U2 = R1/R2.\n  Для параллельного соединения: I = I1 + I2, 1/R=1/R1 + 1/R2, I1/I2 = R2/R1.\n";
            equip = "\nОБОРУДОВАНИЕ:\n Nсточник тока; Два проволочных резистора; Амперметр; Вольтметр, Ключ замыкания ток; Реостат; Комплект соединительных проводников.\n";
            progr = "\nХОД РАБОТЫ:\n\n";
            inputdata = "\nВХОДНЫЕ ДАННЫЕ:\n";
            outputdata = "\nВЫХОДНЫЕ ДАННЫЕ: \n\n";
            refer = "\n\nВы можете вызвать справку о лабораторной работе кнопкой,расположенной в нижнем правом углу.\nВернуться в меню выбора лабороторной можно соответствующей кнопкой(НАЖАТЬ ЕЁ МОЖНО ТОЛЬКО В РЕЖИМЕ РЕДАКТИРОВАНИЯ ДАННЫХ).";

            MessageBox.Show(goal + equip + progr + inputdata + outputdata + refer, "Изучение движения тел по окружности под действием силы упругости и тяжести");
        }

        private void calcBtn_Click(object sender, RoutedEventArgs e)
        {
            int er1 = 0, er2= 0;
            string eror1,eror2;
            double[] data = new double[4];

            Form.InData(tb1, lb1, data, out eror1, out er1);
            Form.InData(tb2, lb2, data, out eror2, out er2);

            if (er1 == 0 && er2 == 0)
            {

            }
            if(er1 != 0 || er2 != 0)
            {
                if (er1 != 0 && er2 == 0)
                {
                    eror2 = null;
                    eror1 = "Для последовательного соединения :\n" + eror1;
                }
                    
                else if(er2 != 0 && er1 == 0)
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

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mW = new MainWindow(true);
            Form.Menu(mW, this);
        }
    }
}
