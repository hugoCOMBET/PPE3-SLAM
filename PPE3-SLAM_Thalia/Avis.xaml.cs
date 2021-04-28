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
using Model.Data;

namespace PPE3_SLAM_Thalia
{
    /// <summary>
    /// Logique d'interaction pour Avis.xaml
    /// </summary>
    public partial class FenetreAvis : Window
    {
        private DAOavis undaoavis;
        private DAOclients undaoclient;
        private DAOsalles undaosalle;
        private DAOtheme undaotheme;
        private daoReservation undaoreservation;
        private daoObstacle undaoobstacle;

        public FenetreAvis(DAOavis avis, DAOclients client, DAOsalles salle, DAOtheme theme, daoReservation reservation, daoObstacle obstacle)
        {
            InitializeComponent();
            undaoavis = avis;
            undaoclient = client;
            undaosalle = salle;
            undaotheme = theme;
            undaoreservation = reservation;
            undaoobstacle = obstacle;
            string table = "avis";

            FntAvis.DataContext = new AppDirecteur_PPE3.viewModel.viewModelAvis(avis, client, salle, theme, reservation, obstacle);
            lbl_avg_note.Content = Convert.ToString(this.undaoavis.SelectAvg(table));
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

        private void btn_theme_pAvis_Click(object sender, RoutedEventArgs e)
        {
            Theme_Obstacle T_O = new Theme_Obstacle(undaoavis, undaoclient, undaosalle, undaotheme, undaoreservation, undaoobstacle);
            T_O.Show();
        }

        private void btn_Stat_pAvis_Click(object sender, RoutedEventArgs e)
        {
            Statistiques Stat = new Statistiques(undaoavis, undaoclient, undaosalle, undaotheme, undaoreservation, undaoobstacle);
            Stat.Show();
        }
    }
}
