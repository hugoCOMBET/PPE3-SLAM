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
using Model.Business;
using Model.Data;

namespace PPE3_SLAM_Axel
{
    /// <summary>
    /// Logique d'interaction pour Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {

        private List<ComboBox> uneListeComboBox;
        public int NBobstacles;
        public Window3(DAOclients unDaoClient, daoObstacle unDaoObstacle)
        {
            InitializeComponent();
            uneListeComboBox = new List<ComboBox>();
            uneListeComboBox.Add(cbx_position_un);
            uneListeComboBox.Add(cbx_position_deux);
            uneListeComboBox.Add(cbx_position_trois);
            uneListeComboBox.Add(cbx_position_quatre);
            uneListeComboBox.Add(cbx_position_cinq);
            uneListeComboBox.Add(cbx_position_six);
            uneListeComboBox.Add(cbx_position_sept);
            uneListeComboBox.Add(cbx_position_huit);
            uneListeComboBox.Add(cbx_position_neuf);
            uneListeComboBox.Add(cbx_position_dix);
            uneListeComboBox.Add(cbx_position_onze);
            uneListeComboBox.Add(cbx_position_douze);
            NBobstacles = RetourneNbObstacle(uneListeComboBox);
            
            

            SelectionClient.DataContext = new viewModel.viewModelSelectionClient(unDaoClient);
            lst_clients.Visibility = Visibility.Hidden;
            ConfigurationReservation.DataContext = new viewModel.viewModelPositionObstacle(unDaoObstacle);
        }

        private void txt_nom_GotFocus(object sender, RoutedEventArgs e)
        {
            lst_clients.Visibility = Visibility.Visible;
        }

        private void txt_nom_LostFocus(object sender, RoutedEventArgs e)
        {
            lst_clients.Visibility = Visibility.Hidden;
        }

        private void btn_suivant_Click(object sender, RoutedEventArgs e)
        {
            
                int newIndex = tabReservation.SelectedIndex + 1;
                if (newIndex >= tabReservation.Items.Count)
                    newIndex = 0;
                tabReservation.SelectedIndex = newIndex;
            

        }

        private static int RetourneNbObstacle(List<ComboBox> uneListCombobox)
        {
            int i = 0;
            foreach(ComboBox cbx in uneListCombobox)
            {
                if(cbx.SelectedItem!= null)
                {
                    i = i + 1;
                }
            }
            return i;
        }
    }
}
