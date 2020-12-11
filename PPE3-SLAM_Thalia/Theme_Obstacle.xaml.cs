using Model.Data;
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

namespace PPE3_SLAM_Thalia
{
    /// <summary>
    /// Logique d'interaction pour Theme_Obstacle.xaml
    /// </summary>
    public partial class Theme_Obstacle : Window
    {
        private DAOavis undaoavis;
        private DAOclients undaoclient;
        private DAOsalles undaosalle;
        private DAOtheme undaotheme;
        private daoReservation undaoreservation;

        public Theme_Obstacle(DAOavis avis, DAOclients client, DAOsalles salle, DAOtheme theme, daoReservation reservation)
        {
            InitializeComponent();
            undaoavis = avis;
            undaoclient = client;
            undaosalle = salle;
            undaotheme = theme;
            undaoreservation = reservation;
            //on associe la grid principal mainGrid du XAML en initialisant son DataContext avec un objet viewModelFromage
            FntT_O.DataContext = new AppDirecteur_PPE3.viewModel.viewModelThemeObstacles();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult mbr_confirmation;
            mbr_confirmation = MessageBox.Show("Êtes-vous sur de vouloir quitter ?", "Fermeture", MessageBoxButton.YesNo);
            if (mbr_confirmation == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btn_stat_pTheme_Click(object sender, RoutedEventArgs e)
        {
            Statistiques Stat = new Statistiques(undaoavis, undaoclient, undaosalle, undaotheme, undaoreservation);
            Stat.Show();
        }

        private void btn_avis_pTheme_Click(object sender, RoutedEventArgs e)
        {
            FenetreAvis avis = new FenetreAvis(undaoavis, undaoclient, undaosalle, undaotheme, undaoreservation);
            avis.Show();
        }
    }
}
