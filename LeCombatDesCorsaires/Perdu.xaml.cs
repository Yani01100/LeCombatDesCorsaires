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
    /// Logique d'interaction pour Perdu.xaml
    /// </summary>
    public partial class Perdu : Window
    {
        public Perdu()
        {
            InitializeComponent();
        }

        private void ButRejouer_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.rejouer = true;
        }

        private void ButQuitter_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
