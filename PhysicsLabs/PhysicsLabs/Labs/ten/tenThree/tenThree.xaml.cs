﻿using System;
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

namespace PhysicsLabs.Labs.ten.tenThree
{
    public partial class tenThree : Window
    {
        Button[] btn = new Button[4];
        public tenThree()
        {
            string[] bCont = { "Рассичтать", "Изменить данные", "Вернуться к выбору лаб.", "Справка" };
            reference();
            InitializeComponent();
        }

        private void reference()
        {
            string goal, equip, progr, inputdata, outputdata, refer;

            goal = "ЦЕЛЬ РАБОТЫ: \n Экспериментально проверить справедливость соотношения V1/T1 = V2/T2\n";
            equip = "\nОБОРУДОВАНИЕ:\n Стеклянная трубка,запаянная с одного конца,длинной 600мм и диаметром 8-10мм; Цилиндрический сосуд высотой 600мм и диаметром 40-50мм,наполененный горячей водой(60°С); Стакан с водой комнатной температуры; пластилин .\n";
            progr = "\nХОД РАБОТЫ:\n1. Стеклянная трубка длиной 600 мм и диаметром 40 - 50 мм помещается на 3 - 5 минут в цилиндрический сосуд с горячей водой.При этом объем воздуха V, равен объему стеклянной трубки, а температура-температуре горячей воды Т. Это первое состояние.Чтобы масса воздуха осталась постоянной, открытый конец стеклянной трубки, находящийся в горячей воде, замазываем пластилином.\n2. Через 3-5 минут трубку вынимаем из сосуда с горячей водой и быстро опускаем в стакан комнатной температуры (рис. б) и под водой снимаем пластилин. После прекращения подъема воды в трубке объем воздуха станет равным V2 < V1, а давление Р2=Ратм - pgh.\n3. Чтобы давление вновь стало равным атмосферному, необходимо погружать трубку в стакан до тех пор, пока уровни воды в стакане и в трубке не выровняются.Это будет вторым состоянием.\n3.Отношение объемов в трубках можно заменить длинами столбов воздуха ( V1/V2=Sl1/Sl2=l1/l2 ).Поэтому в работе необходимо проверить равенство l1/l2=T1/T2.\n";
            inputdata = "\nВХОДНЫЕ ДАННЫЕ: \n\n";
            outputdata = "\nВЫХОДНЫЕ ДАННЫЕ: \n\n";
            refer = "\n\nВы можете вызвать справку о лабораторной работе кнопкой,расположенной в нижнем правом углу.\nВернуться в меню выбора лабороторной можно соответствующей кнопкой(НАЖАТЬ ЕЁ МОЖНО ТОЛЬКО В РЕЖИМЕ РЕДАКТИРОВАНИЯ ДАННЫХ).";

            MessageBox.Show(goal + equip + progr + inputdata + outputdata + refer, "Изучение движения тел по окружности под действием силы упругости и тяжести");
        }
    }
}