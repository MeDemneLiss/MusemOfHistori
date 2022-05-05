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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Museum_of_history
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 40);
            timer.Start();

        }

        List<History> historyLibrary = new List<History>()
        {
         new History() {Year = 476  , Event = "Вождь германцев Одоакр сверг последнего императора Западной Римской империи Ромула Августа.\nБыло много причин, которые привели к этому Демографический спад из-за войн, голода и эпидемий;\n экономический и производственный кризис как в деревне, так и в торговле;\n кризис и бегство населения из городов, которые все чаще разграблялись варварами; слишком сильное разделение между избранным, живущим в роскоши, и массой населения, живущей в бедности;\n отсутствие консенсуса в отношении центрального правительства и недостатки конституционной системы."},
         new History() {Year = 800 , Event = "Карл Великий был коронован императором Папой Львом III в канун Рождества 800 года (24 декабря 799 года) Многие историки относят рождение Священной Римской империи к этой дате"},
         new History() {Year = 1054 , Event = "Разделение церквей или Восточный раскол\nС Восточным расколом христианство было разделено между Римско-католической церковью и Православной церковью. \n Раскол был результатом большого различия между двумя Церквями."},
         new History() {Year = 1455 , Event = "Изобретение подвижной печати приписывают Иоганну Гутенбергу \nСуть изобретения состояла в том, что Иоганн Гутенберг предложил использовать для набора текста отдельные металлические буквы — литеры, которые располагали в нужном порядке в специальных ячейках. В итоге получается оттиск страницы книги. Каждая одностраничная матрица была покрыта чернилами и напечатана на прессе. Новая техника очень быстро распространилась по Европе."},
         new History() {Year = 5 , Event = ""},
         new History() {Year = 5 , Event = ""},
         new History() {Year = 5 , Event = ""},
         new History() {Year = 5 , Event = ""},
                                             new History() {Year = 5 , Event = ""},
                                                      new History() {Year = 5 , Event = ""},
                                                               new History() {Year = 5 , Event = ""},
                                                                        new History() {Year = 5 , Event = ""},
                                                                                 new History() {Year = 5 , Event = ""},
                                                                                 new History() {Year = 5 , Event = ""},        
         new History() {Year = 5 , Event = ""},
        };
        public int i = 0;
        public int d = 1;
        public string text;
        int h = 0;


        private void timerTick(object sender, EventArgs e)
        {
            switch (d)
            {
                case 1:
                    text = "it woud appear that you are quite the imbecile, i suppose";
                    break;
                case 2:
                    text= "just get out of here this instant";
                    break;
                case 3:
                    text= "what a profoundly irritating and aggravating man you are ... ";
                    break;
            }
            Random rnd = new Random();
            int cha = rnd.Next(0, 2);
            i += cha;
            if (i <= text.Length)
            {

                        textGif.Text = text.Substring(0, i);


            }
            else 
            {
                if (h < 35)
                {
                    h++;
                    return;
                }
                    i = 0; d++;
                    if (d == 4) { d = 1; }
                    h = 0;
            }


        }

        private void calculation_Click(object sender, RoutedEventArgs e)
        {
            if (firstNumber.Text != string.Empty && double.TryParse(firstNumber.Text, out double firstN) && secondNumber.Text != string.Empty && double.TryParse(secondNumber.Text, out double secondN))
            {
                double f = firstN + secondN;
                ansver.Text = Convert.ToString(f);
            }
            else
            {
                MessageBox.Show("Ты даже правильно ввести числа не можешь, я полагаю", "Тупица...", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(year.Text, out int yearg) && yearg > 0 && yearg < DateTime.Now.Year)
            {
                List<History> list = historyLibrary.Where(p => p.Year == yearg).ToList();
                if (list.Count == 0)
                {
                    MessageBox.Show("Данные по этому году вы не можете найти", "Плак-Плак", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                foreach (var item in list)
                {
                    executorResult.Text = item.Event;
                }

            }
            else
            {
                MessageBox.Show("Ты даже правильно год ввести не можешь, я полагаю", "Тупица...", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

        }

        private void fAndSNum_TextChanged(object sender, TextChangedEventArgs e)
        {
            ansver.Clear();
        }

        private void year_TextChanged(object sender, TextChangedEventArgs e)
        {
            executorResult.Clear();
        }
    }
}
