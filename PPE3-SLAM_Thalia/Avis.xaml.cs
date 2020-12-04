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
    public partial class Avis : Window
    {
        public Avis(DAOavis avis, DAOclients client, DAOsalles salle, DAOtheme theme, daoReservation reservation)
        {
            InitializeComponent();
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
