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
        public static bool rejouer=true;
        public MainWindow()
        {
            InitializeComponent();
            AfficheDemarrage();
            InitMusique();
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
            
            if (rejouer)
            {
                rejouer = false;
                UCJeu leJeu = new UCJeu();
                ZoneJeu.Content = leJeu;

            }

        }

        private void AfficheDefaite(object sender, RoutedEventArgs e)
        {
            Perdu perdu = new Perdu();
            ZoneJeu.Content = perdu;
            perdu.ButRejouer.Click += AfficheJeu;
        }


        private static MediaPlayer musique;

        private void InitMusique()
        {
            musique = new MediaPlayer();
            musique.Open(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Assets/MusiquePirate.mp3"));
            musique.MediaEnded += RelanceMusique;
            musique.Volume = 0.5;
            musique.Play();
        }

        private void RelanceMusique(object? sender, EventArgs e)
        {
            musique.Position = TimeSpan.Zero;
            musique.Play();
        }
    }
}
