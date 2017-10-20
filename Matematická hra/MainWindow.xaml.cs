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
        int tlacitkoChange = 2;

        public MainWindow()
        {
            InitializeComponent();
           
        }


       
        

        //přiklad
        public void generovaniPrikladu()
        {
            int cislo1 = rnd.Next(1 + Level, 10 + Level);
            int cislo2 = rnd.Next(1 + Level, 10 + Level);
            int curect = cislo1 * cislo2;
            int fake = cislo1 * cislo2 + rnd.Next(1, 10);
   
            tlacitkoChange = rnd.Next(0,2);
            level.Text = "Level " + Level;

            if (tlacitkoChange == 1)
            {
                Vysledek1.Content = curect;
                Vysledek2.Content = fake;
                
            }
            else
            {
                Vysledek1.Content = fake;
                Vysledek2.Content = curect;
                
            }

            string vysledek = cislo1 + "*" + cislo2;

            priklad.Text = vysledek;
        }

        //tlacitka
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GameStart();            
            kontrolaPekne();
            level.Text = "Level " + Level;

            if (tlacitkoChange  == 1)
            {
                pekne = pekne + 10;
                Level = Level + 1;
                
            }
            else if (tlacitkoChange == 0)
            {
                pekne = pekne - 10;
                Level = Level - 1;
            }

            kontrolaLevel();
            generovaniPrikladu();
            progess.Value = pekne;
            Win();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            GameEnde();          
            kontrolaPekne();

            if (tlacitkoChange == 1)
            {
                pekne = pekne - 10;
                Level = Level - 1;
            }
            else if (tlacitkoChange == 0)
            {
                pekne = pekne + 10;
                Level = Level + 1;

            }
            
            generovaniPrikladu();
            kontrolaLevel();
            progess.Value = pekne;
            Win();
            




        }
        
        //funkce
        public void Win()
         {
            if (progess.Value == 100)
            {
                level.Text = "WIN";
                priklad.Text = "";
                Vysledek1.Content = "NEW GAME";
                Vysledek2.Content = "QUIT";
                tlacitkoChange = 3;

            }
         }

        public void kontrolaLevel()
        {      
            if (Level < 1)
            {
                Level = 1;
            }

            if (Level > 10)
            {
                Level = 10;
            }
            
        }

        public void kontrolaPekne()
        {
            if (pekne > 100)
            {
                pekne = 100;
            }

            if (pekne < 0)
            {
                pekne = 0;
            }

            
        }

        public void GameEnde()
        {
            if (tlacitkoChange == 3 | tlacitkoChange == 2)
            {
                Close();
            }
            
        }

        public void GameStart()
        {
            if (tlacitkoChange == 3 | tlacitkoChange == 2)
            {
                pekne = 0;
                Level = 1;
               
            }
        }




    }
}
