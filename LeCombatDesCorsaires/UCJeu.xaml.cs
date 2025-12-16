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
        double vitesse = 5;       // Vitesse du bateau
        int directionX = 0;       // 0=stop, 1=droite, -1=gauche
        int directionY = 0;       // 0=stop, 1=bas, -1=haut
        int score = 0;
        Random rand = new Random(); // Pour placer le trésor au hasard

        public UCJeu()
        {
            InitializeComponent();
            InitJeu();
        }

        private void InitJeu()
        {
            // 1. On remet les scores et la vitesse à zéro
            score = 0;
            vitesse = 5;
            labScore.Content = "Trésors : " + score;

            // 2. IMPORTANT : On remet le bateau au MILIEU de l'écran
            Canvas.SetLeft(imgBateau, 350);
            Canvas.SetTop(imgBateau, 200);

            // 3. On arrête le mouvement (pour ne pas qu'il parte tout seul)
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
            if (fenetre != null) fenetre.KeyDown += GestionToucheAppuyee;
        }
        

        // Cette méthode tourne en boucle (toutes les 16ms)
        private void MoteurDuJeu(object sender, EventArgs e)
        {
            // --- A. DEPLACEMENT ---
            double x = Canvas.GetLeft(imgBateau);
            double y = Canvas.GetTop(imgBateau);
            if (x < 0 || x + imgBateau.Width > zoneDeJeu.ActualWidth || y < 0 || y + imgBateau.Height > zoneDeJeu.ActualHeight)
            {
                // Comme à la Page 9 du PDF Père Noël (point 24) : Game Over
                minuterie.Stop(); // On arrête le temps
                MessageBox.Show("Game Over ! Le bateau a coulé.");
                MessageBoxResult reponse = MessageBox.Show(
        "Tu as touché le bord !\nVeux-tu rejouer ?",
        "Game Over",
        MessageBoxButton.YesNo,
        MessageBoxImage.Question);

                // 3. Si le joueur clique sur OUI
                if (reponse == MessageBoxResult.Yes)
                {
                    InitJeu(); // On relance proprement
                }
                // 4. Si le joueur clique sur NON
                else
                {
                    Application.Current.Shutdown(); // On ferme le programme
                }
                return; // On arrête le code ici
            }
            
            // On applique la direction
            Canvas.SetLeft(imgBateau, x + (directionX * vitesse));
            Canvas.SetTop(imgBateau, y + (directionY * vitesse));

            // --- B. COLLISION AVEC LE TRESOR ---
            // On crée deux rectangles invisibles autour du bateau et du trésor
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
            if (e.Key == Key.Left) { directionX = -1; directionY = 0; }
            if (e.Key == Key.Right) { directionX = 1; directionY = 0; }
            if (e.Key == Key.Up) { directionX = 0; directionY = -1; }
            if (e.Key == Key.Down) { directionX = 0; directionY = 1; }
        }

        private void MangerTresor()
        {
            // 1. Augmenter le score
            score++;
            labScore.Content = "Trésors : " + score;
            vitesse = vitesse + 1;
            // 2. Déplacer le trésor au hasard
            // On s'assure qu'il reste dans la fenêtre (800x450 environ)
            double x = rand.Next(0, (int)(zoneDeJeu.ActualWidth - tresor.Width));
            double y = rand.Next(0, (int)(zoneDeJeu.ActualHeight - tresor.Height));

            Canvas.SetLeft(tresor, x);
            Canvas.SetTop(tresor, y);
        }
    }
}
    

