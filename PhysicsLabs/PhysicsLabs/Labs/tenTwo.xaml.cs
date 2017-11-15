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

namespace PhysicsLabs.Labs
{

    public partial class tenTwo : Window
    {
        public tenTwo()
        {
            InitializeComponent();
            reference();
        }

        private void reference()
        {
            string goal, equip, progr, inputdata, outputdata;
            goal = "ЦЕЛЬ РАБОТЫ: \n Научится измерять потенциальную энергию поднятого над землей тела и упруго деформированной пружины, сравнить два значения потенциальной энергии системы.\n";
            equip = "\nОБОРУДОВАНИЕ:\n Штатив с муфтой и лапкой, динамометр лабораторный с фиксатором, лента измерительная, груз на нити.\n";
            progr = "\nХОД РАБОТЫ:\n1. Определяем вес шарика(груза)(F1 = m*g).\n2. Измеряем длину нити L.\n3. Поднять груз до точки закрепления нити и отпустить до касания со столом,регулируя длину нити.\n4. Измерить максимальную силу упругости Fy.\n5. Измерить максимальное растяжение пружины ΔL.\n";
            inputdata = "\nВХОДНЫЕ ДАННЫЕ: \nF1 - вес шарика (груза) в НЬЮТОНАХ.\nL - длина нити в САНТИМЕТРАХ.\nFy - максимальная сила упругости в НЬЮТОНАХ.\nΔL - максимальное удлинеие пружины в САНТИМЕТРАХ.\n";
            outputdata = "\nВЫХОДНЫЕ ДАННЫЕ: \nEp1,Ep2 - потенциальные энергии.";
            MessageBox.Show(goal + equip + progr + inputdata + outputdata + "\n\nВы можете вызвать справку о лабараторной работе кнопкой,расположенной в нижнем правом углу.\nВернуться в меню выбора лабароторной можно соответствующей кнопкой(нажать ее можно только при редактировании данных).", "Экспериментальное изучение закона сохранения механической энергии.");
        }

        private void caclBtn_Click(object sender, RoutedEventArgs e)
        {
            double force1, len, dlen, forcey, Ep1, Ep2;

            string eror = "Некорректно введенные данные : ";
            int er = 0;

            //Проверка на корректность данных
            if (!double.TryParse(force1Tb.Text, out force1))
            {
                force1Lb.Foreground = System.Windows.Media.Brushes.Red;
                force1Tb.Clear();
                eror += "Вес шарика - F1";
                er++;
            }
            else
                force1Lb.Foreground = System.Windows.Media.Brushes.Black;

            if (!double.TryParse(lenTb.Text, out len))
            {
                lenLb.Foreground = System.Windows.Media.Brushes.Red;
                lenTb.Clear();
                if (er != 0)
                    eror += "  ,";
                eror += " Длина нити - L";
                er++;
            }
            else
                lenLb.Foreground = System.Windows.Media.Brushes.Black;

            if (!double.TryParse(dlenTb.Text, out dlen))
            {
                dlenLb.Foreground = System.Windows.Media.Brushes.Red;
                dlenTb.Clear();
                if (er != 0)
                    eror += "  ,";
                eror += " Макс. удлинение пружины - ΔL";
                er++;
            }
            else
                dlenLb.Foreground = System.Windows.Media.Brushes.Black;

            if (!double.TryParse(forceyTb.Text, out forcey))
            {
                forceyLb.Foreground = System.Windows.Media.Brushes.Red;
                forceyTb.Clear();
                if (er != 0)
                    eror += "  ,";
                eror += " Сила упругости - Fy";
                er++;
            }
            else
            {
                forceyLb.Foreground = System.Windows.Media.Brushes.Black;
            }

            if (er == 0)
            {
               
            }
            else
            {
                eror += ".";
                MessageBox.Show(eror, "Некорректно введенные данные");

            }

        }
    }
}
