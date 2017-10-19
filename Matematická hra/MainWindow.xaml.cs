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

namespace Matematická_hra
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rnd = new Random();
        public int pekne = 10;
        public int Level = 1;
        public int tlacitkoChange;

        public MainWindow()
        {
            InitializeComponent();
           
        }


        public void generovaniPrikladu()
        {
            int cislo1 = rnd.Next(1 + Level, 10 + Level);
            int cislo2 = rnd.Next(1, 10);
            int curect = cislo1 + cislo2;
            int fake = cislo1 + cislo2 + rnd.Next(1, 10);

            tlacitkoChange = rnd.Next(0,2);

            if (tlacitkoChange == 1)
            {
                Vysledek1.Content = curect;
                Vysledek2.Content = fake;
                
            } else
            {
                Vysledek2.Content = curect;
                Vysledek1.Content = fake;
            }
            
            


            string vysledek = cislo1 + "+" + cislo2;

            priklad.Text = vysledek;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            generovaniPrikladu();
            kontrolaPekneMinus();

            if (tlacitkoChange  == 1)
            {
                pekne = pekne + 10;
                Level = Level + 1;
            } else
            {
                pekne = pekne - 10;
            }
            progess.Value = pekne;
            Gay();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            generovaniPrikladu();
            kontrolaPekneMinus();
            if (tlacitkoChange == 0)
            {
                pekne = pekne + 10;
                Level = Level + 1;
            }
            else
            {
                pekne = pekne - 10;
            }
            progess.Value = pekne;



        }

         public void Gay()
         {
            if (progess.Value == 100)
            {
                priklad.Text = "Vyhrál jsi!";
            }
         }

        public void kontrolaPekneMinus()
        {
            if (pekne < 0)
            {
                pekne = 0;
            }
        }

        
    }
}
