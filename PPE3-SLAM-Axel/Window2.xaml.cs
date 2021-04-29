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
using Model.Business;
using PPE3_SLAM_Axel.viewModel;

namespace PPE3_SLAM_Axel
{
    /// <summary>
    /// Logique d'interaction pour Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        

        public Window2(DAOsalles unDaoSalle, DAOtheme unDaoTheme,DateTime uneDate)
        {
            InitializeComponent();
            ChoixSallesGrid.DataContext = new viewModel.viewModelChoixSalle(unDaoTheme, unDaoSalle, uneDate);
        }

        private void btn_retour_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //private void btn_Selection_Click(object sender, RoutedEventArgs e)
        //{
        //    Dbal thedbal = new Dbal("LSRGames");
        //    DAOtheme thedaotheme = new DAOtheme(thedbal);
        //    DAOclients thedaoclients = new DAOclients(thedbal);
        //    daoObstacle thedaoobstacle = new daoObstacle(thedbal);
        //    daoReservation thedaoreservation = new daoReservation(thedbal);
        //    DAOsalles thedaosalle = new DAOsalles(thedbal, thedaotheme);
        //    MessageBoxResult msg;

        //    Window1 wnd1 = new Window1(thedaoreservation,thedaosalle);
        //    viewModelChoixSalle vmcs = new viewModelChoixSalle(thedaotheme, thedaosalle, wnd1.DateChoixSalle);
        //    Window3 wnd = new Window3(thedaoclients, thedaoobstacle,wnd1.DateChoixSalle,vmcs.SelectedSalle);
        //    if(listSallesView.SelectedIndex!=-1)
        //    {
        //        wnd.Show();
        //    }
        //    else
        //    {
        //        msg = MessageBox.Show("Vous n'avez pas sélectionner de salle");

        //    }
        //}
    }
}
