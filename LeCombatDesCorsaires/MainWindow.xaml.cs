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
using System.Windows.Threading;

namespace LeCombatDesCorsaires
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private static DispatcherTimer minuterie;
        public MainWindow()
        {
            InitializeComponent();
            AfficheDemarrage();
            //InitializeTimer();
        }
        private void AfficheDemarrage()
        {
            UCDemarrage uc = new UCDemarrage();
            ZoneJeu.Content = uc;
            uc.ButDemarrer.Click += AfficheRegle;
        }

        private void AfficheRegle(object sender, RoutedEventArgs e)
        {
            UCRegle uc = new UCRegle();
            ZoneJeu.Content = uc;
            uc.btnContinué.Click += AfficheJeu;
        }

        private void AfficheJeu(object sender, RoutedEventArgs e)
        {
            UCJeu leJeu = new UCJeu();
            ZoneJeu.Content = leJeu;

        }


        /*private void InitializeTimer()
        {
            minuterie = new DispatcherTimer();
            // configure l'intervalle du Timer :62 images par s
            minuterie.Interval = TimeSpan.FromMilliseconds(16);
            // associe l’appel de la méthode Jeu à la fin de la minuterie
            minuterie.Tick += Jeu;
            // lancement du timer
            minuterie.Start();
        }
        private int nb = 0;
        private int nbTours = 0;
        private void Jeu(object? sender, EventArgs e)
        {

            Canvas.SetLeft(image, Canvas.GetLeft(imgFond1) - 2);
            if (Canvas.GetLeft(imgFond1) + imgFond1.Width <= 0)
                Canvas.SetLeft(imgFond1, canvasJeu.ActualWidth);

            Canvas.SetLeft(imgFond2, Canvas.GetLeft(imgFond2) - 2);
            if (Canvas.GetLeft(imgFond2) + imgFond2.Width <= 0)
                Canvas.SetLeft(imgFond2, canvasJeu.ActualWidth);

            Canvas.SetLeft(imgSol1, Canvas.GetLeft(imgSol1) - 5);
            if (Canvas.GetLeft(imgSol1) + imgSol1.Width <= 0)
                Canvas.SetLeft(imgSol1, canvasJeu.ActualWidth);

            Canvas.SetLeft(imgSol2, Canvas.GetLeft(imgSol2) - 5);
            if (Canvas.GetLeft(imgSol2) + imgSol2.Width <= 0)
                Canvas.SetLeft(imgSol2, canvasJeu.ActualWidth);

            nbTours++;
            if (nbTours == 4)
            {
                nb++;
                if (nb == persos.Length)
                    nb = 0;
                imgPerso.Source = persos[nb];
                nbTours = 0;
            }
        }
        private static int pasSol = 8;
        private static int pasFond = 2;
        public static int vitesse = 2;*/









    }
}
