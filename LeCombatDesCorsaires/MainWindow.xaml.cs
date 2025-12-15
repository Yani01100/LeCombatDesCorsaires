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

namespace LeCombatDesCorsaires
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();
            AfficheDemarrage();
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

        // Ajoutez cette fonction pour que la ligne du dessus fonctionne
        private void AfficheJeu(object sender, RoutedEventArgs e)
        {
            UCJeu leJeu = new UCJeu();
            ZoneJeu.Content = leJeu;

        }

    

        private void AfficheUCMonde(object sender, RoutedEventArgs e)
        {
            UCMonde uc2 = new UCMonde();
            ZoneJeu.Content = uc2;
            uc2.butConfirmeChoix.Click += AfficheUCDisposition;
        }

        private void AfficheUCDisposition(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
