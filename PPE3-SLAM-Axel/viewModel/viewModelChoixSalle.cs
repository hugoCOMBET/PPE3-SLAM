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
    class viewModelChoixSalle : viewModelBase 
    {

        private Dbal thedbal;
        private DAOtheme vmdaotheme;
        private DAOsalles vmdaosalle;
        

        private ObservableCollection<salles> listSalles;

        public ObservableCollection<salles> ListSalles { get => listSalles; set => listSalles = value; }
    }


}
