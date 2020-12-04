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
using Model.Data;

namespace PPE3_SLAM_Thalia
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(DAOavis avis, DAOclients client, DAOsalles salle, DAOtheme theme, daoReservation reservation)
        {
            InitializeComponent();          
        }

        private void Window_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult mbr_confirmation;
            mbr_confirmation = MessageBox.Show("Êtes-vous sur de vouloir quitter ?", "Fermeture", MessageBoxButton.YesNo);
            if (mbr_confirmation == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btn_valider_Click(object sender, RoutedEventArgs e)
        {
            if (rdb_stat.IsChecked == true)
            {
                Statistiques Stat = new Statistiques();
                Stat.Show();
            }

            if (rdb_themeObs.IsChecked == true)
            {
                Theme_Obstacle T_O = new Theme_Obstacle();
                T_O.Show();
            }

            if (rdb_Avis.IsChecked == true)
            {
                Avis avis = new Avis() ;
                avis.Show();
            }
        }
    }
}
