using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Model.Business;
using Model.Data;

namespace PPE3_SLAM_Axel.viewModel
{
    class viewModelPositionObstacle
    {
        private daoObstacle vmdaoobstacle;
        private ICommand validerCommand;
        private ObservableCollection<Obstacle> listObstacles;

        public ObservableCollection<Obstacle> ListObstacles { get => listObstacles; set => listObstacles = value; }

        public viewModelPositionObstacle(daoObstacle unDaoObstacle)
        {
            vmdaoobstacle = unDaoObstacle;
            listObstacles = new ObservableCollection<Obstacle>(vmdaoobstacle.SelectAll());
        }

        public ICommand ValiderCommand
        {
            get
            {
                if (this.validerCommand == null)
                {
                    this.validerCommand = new RelayCommand(() => Valider(), () => true);
                }
                return this.validerCommand;

            }

        }


        public void Valider()
        {
            int n = 6;
            Dbal thedbal = new Dbal("LSRGames");
            
            vmdaoobstacle = new daoObstacle(thedbal);
            daoPositionObstacle thedaopositionobstacle = new daoPositionObstacle(thedbal);
            daoReservation thedaoreservation = new daoReservation(thedbal);
            DAOtheme thedaotheme = new DAOtheme(thedbal);
            daoObstacle thedaoobstacle = new daoObstacle(thedbal);
            DAOclients thedaoclient = new DAOclients(thedbal);
            DAOsalles thedaosalles = new DAOsalles(thedbal, thedaotheme);
            Window1 wnd = new Window1(thedaoreservation,thedaosalles);
            viewModelSelectionClient unviewmodelclients = new viewModelSelectionClient(thedaoclient);
            DAOtransactions thedaotransactions = new DAOtransactions(thedbal,thedaoclient);
            Window3 wnd3 = new Window3(thedaoclient, thedaoobstacle);

            unviewmodelclients.SelectedClient =(Clients)wnd3.lst_clients.SelectedItem;

            viewModelChoixSalle unviewmodelsalles = new viewModelChoixSalle(thedaotheme, thedaosalles, new DateTime());
            Transactions uneTransaction = new Transactions(n, unviewmodelclients.SelectedClient, 5.25);
            n = n + 1;
            thedaotransactions.Insert(uneTransaction);
            Reservation thereservation = new Reservation(n, unviewmodelclients.SelectedClient, unviewmodelsalles.SelectedSalle,uneTransaction, wnd.DateChoixSalle, (int)wnd3.cbx_nbjoueurs.SelectedItem, wnd3.NBobstacles);
            thedaoreservation.Insert(thereservation);
        }
    }
}
