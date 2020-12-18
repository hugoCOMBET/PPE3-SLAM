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
    /// Logique d'interaction pour Statistiques.xaml
    /// </summary>
    public partial class Statistiques : Window
    {
        private DAOavis undaoavis;
        private DAOclients undaoclient;
        private DAOsalles undaosalle;
        private DAOtheme undaotheme;
        private daoReservation undaoreservation;

        public Statistiques(DAOavis avis, DAOclients client, DAOsalles salle, DAOtheme theme, daoReservation reservation)
        {
            InitializeComponent();

            undaoavis = avis;
            undaoclient = client;
            undaosalle = salle;
            undaotheme = theme;
            undaoreservation = reservation;
            //on associe la grid principal mainGrid du XAML en initialisant son DataContext avec un objet viewModelFromage
            FntStat.DataContext = new AppDirecteur_PPE3.viewModel.viewModelStatistiques(undaoavis, undaoclient, undaosalle, undaotheme, undaoreservation);
        }

        private void btn_theme_pStat_Click(object sender, RoutedEventArgs e)
        {
            Theme_Obstacle T_O = new Theme_Obstacle(undaoavis, undaoclient, undaosalle, undaotheme, undaoreservation);
            T_O.Show();
        }

        private void btn_avis_pStat_Click(object sender, RoutedEventArgs e)
        {
            FenetreAvis avis = new FenetreAvis(undaoavis, undaoclient, undaosalle, undaotheme, undaoreservation);
            avis.Show();
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
    }
}
