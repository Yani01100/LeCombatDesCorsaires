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

namespace LeCombatDesCorsaires
{
    /// <summary>
    /// Logique d'interaction pour UCJeu.xaml
    /// </summary>
    public partial class UCJeu : UserControl
    {

        DispatcherTimer minuterie;
        double vitesse = 5;
        int directionX = 0;
        int directionY = 0;
        int score = 0;
        Random rand = new Random();

        public UCJeu()
        {
            InitializeComponent();
            InitJeu();
        }

        private void InitJeu()
        {

            score = 0;
            vitesse = 5;
            labScore.Content = "Trésors : " + score;

            // bateau au MILIEU de l'écran
            Canvas.SetLeft(imgBateau, 350);
            Canvas.SetTop(imgBateau, 200);
            directionX = 0;
            directionY = 0;

            // 4. On lance le timer si ce n'est pas déjà fait
            if (minuterie == null)
            {
                minuterie = new DispatcherTimer();
                minuterie.Interval = TimeSpan.FromMilliseconds(16);
                minuterie.Tick += MoteurDuJeu;
            }
            minuterie.Start();

            // 5. On active le clavier
            Window fenetre = Application.Current.MainWindow;
            if (fenetre != null) fenetre.KeyDown += zoneDeJeu_KeyDown;
        }


        private void MoteurDuJeu(object sender, EventArgs e)
        {
            //DEPLACEMENT 
            double x = Canvas.GetLeft(imgBateau);
            double y = Canvas.GetTop(imgBateau);
            /*if (x < 0 || x + imgBateau.Width > zoneDeJeu.ActualWidth || y < 0 || y + imgBateau.Height > zoneDeJeu.ActualHeight)
            {
                MainWindow.rejouer = true;
                minuterie.Stop();
                // ouvrir UCJeu.xaml lorsque bors img mer touchée
                Window fenetre = Application.Current.MainWindow;


                else
                {
                    Application.Current.Shutdown();
                }
                return;
            }*/
            }


            Canvas.SetLeft(imgBateau, x + (directionX * vitesse));
            Canvas.SetTop(imgBateau, y + (directionY * vitesse));

            //COLLISION AVEC LE TRESOR 
            Rect rectBateau = new Rect(Canvas.GetLeft(imgBateau), Canvas.GetTop(imgBateau), imgBateau.Width, imgBateau.Height);
            Rect rectTresor = new Rect(Canvas.GetLeft(tresor), Canvas.GetTop(tresor), tresor.Width, tresor.Height);

            // Si les rectangles se touchent...
            if (rectBateau.IntersectsWith(rectTresor))
            {
                MangerTresor();
            }
        }

        private void GestionToucheAppuyee(object sender, KeyEventArgs e)
        {
            // Logique type "Snake" : on appuie une fois, ça part dans la direction
            if (e.Key == Key.Left) 
            { directionX = -1; directionY = 0; }
            if (e.Key == Key.Right) 
            { directionX = 1; directionY = 0; }
            if (e.Key == Key.Up) 
            { directionX = 0; directionY = -1; }
            if (e.Key == Key.Down) 
            { directionX = 0; directionY = 1; }
        }
        

        private void MangerTresor()
        {

            score++;
            labScore.Content = "Trésors : " + score;
            vitesse = vitesse + 1;


            double x = rand.Next(0, (int)(zoneDeJeu.ActualWidth - tresor.Width));
            double y = rand.Next(0, (int)(zoneDeJeu.ActualHeight - tresor.Height));

            Canvas.SetLeft(tresor, x);
            Canvas.SetTop(tresor, y);
        }

        private void zoneDeJeu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left) { directionX = -1; directionY = 0; imgBateau.Source = new BitmapImage(new Uri("pack://application:,,,/Images/bateauSunnyGauche.png")); imgBateau.Width = 195; imgBateau.Height = 60; }
            if (e.Key == Key.Right) { directionX = 1; directionY = 0; imgBateau.Source = new BitmapImage(new Uri("pack://application:,,,/Images/bateauSunnyDroite.png")); imgBateau.Width = 195; imgBateau.Height = 60; }
            if (e.Key == Key.Up) { directionX = 0; directionY = -1; imgBateau.Source = new BitmapImage(new Uri("pack://application:,,,/Images/bateauSunnyBas.png")); imgBateau.Width = 60; imgBateau.Height = 195; }
            if (e.Key == Key.Down) { directionX = 0; directionY = 1; imgBateau.Source = new BitmapImage(new Uri("pack://application:,,,/Images/bateauSunnyHaut.png")); imgBateau.Width = 60; imgBateau.Height = 195; }
        }
    }
}


