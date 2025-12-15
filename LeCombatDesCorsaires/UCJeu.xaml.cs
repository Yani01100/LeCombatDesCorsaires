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

namespace LeCombatDesCorsaires
{
    /// <summary>
    /// Logique d'interaction pour UCJeu.xaml
    /// </summary>
    public partial class UCJeu : UserControl
    {

        // --- C'EST ICI QU'IL MANQUAIT VOTRE TABLEAU ---
        // Il doit être déclaré tout en haut pour être visible partout
        int[,] GrilleEnnemi = new int[5, 5];

        List<Button> mesBoutons = new List<Button>();
        Random rand = new Random();
        int pointsRestants = 3;

        public UCJeu()
        {
            InitializeComponent();
            GenererGrille();
            PlacerBateauAleatoire();
        }

        private void GenererGrille()
        {
            for (int i = 0; i < 25; i++)
            {
                Button btn = new Button();
                btn.Tag = i;
                btn.Background = Brushes.DeepSkyBlue;
                btn.Margin = new Thickness(1);
                btn.Click += Case_Click;

                // Assurez-vous d'avoir bien mis x:Name="GrilleEnnemiVisuel" dans le XAML !
                GrilleEnnemiVisuel.Children.Add(btn);
                mesBoutons.Add(btn);
            }
        }

        private void PlacerBateauAleatoire()
        {
            int start = rand.Next(0, 23);
            int x = start / 5;
            int y = start % 5;

            // Maintenant ça marche car GrilleEnnemi est déclaré en haut !
            GrilleEnnemi[x, y] = 1;
            GrilleEnnemi[x + 1, y] = 1;
            GrilleEnnemi[x + 2, y] = 1;
        }

        private void Case_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int index = (int)btn.Tag;

            int x = index / 5;
            int y = index % 5;

            if (GrilleEnnemi[x, y] >= 2) return;

            if (GrilleEnnemi[x, y] == 1)
            {
                btn.Background = Brushes.Red; // Touché
                GrilleEnnemi[x, y] = 3;
                pointsRestants--;

                if (pointsRestants == 0)
                {
                    MessageBox.Show("VICTOIRE ! Navire coulé !");
                }
            }
            else
            {
                btn.Background = Brushes.DarkBlue; // Loupé
                GrilleEnnemi[x, y] = 2;
            }
            btn.IsEnabled = false;
        }
    }
}
