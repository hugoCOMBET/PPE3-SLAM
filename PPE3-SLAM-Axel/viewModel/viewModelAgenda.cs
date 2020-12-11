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

        public static DateTime dateEnFonctionDuBouton(string nomBouton )
        {
            const int annee = 2020;
            int position =0;
            string extraction;
            DateTime DateReservation = new DateTime();
            position = nomBouton.IndexOf('_');
            extraction = nomBouton.Substring(0, position);
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
