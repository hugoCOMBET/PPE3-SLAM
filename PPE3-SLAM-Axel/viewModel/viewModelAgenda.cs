using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Model.Business;
using Model.Data;



namespace PPE3_SLAM_Axel.viewModel
{
    class viewModelAgenda : viewModelBase 
    {
        private ICommand un_unCommand;
        private Dbal unDBAL;
        private daoReservation unDaoReservation;
        private DAOsalles unDaoSalle;

        public static DateTime dateEnFonctionDuBouton(string nomBouton , daoReservation unDaoReservation, DAOsalles unDaoSalle)
        {
          

            DateTime DateReservation = new DateTime();
            ;
            return DateReservation;
        }

        public ICommand ClickCommand
        {
            get
            {
                if (this.un_unCommand == null)
                {
                    this.un_unCommand = new RelayCommand(() => ClickTest(unDaoReservation,unDaoSalle ), () => true);
                }
                return this.un_unCommand;

            }

        }

        public static void ClickTest(daoReservation unDaoReservation, DAOsalles unDaoSalle)
        {

            Window1 wnd = new Window1(unDaoReservation, unDaoSalle);
            
        }

    }

    
}
