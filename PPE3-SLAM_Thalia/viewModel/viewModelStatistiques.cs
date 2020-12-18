using Model.Business;
using Model.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppDirecteur_PPE3.viewModel
{
    class viewModelStatistiques : viewModelBase
    {
        DAOavis vmDaoAvis;
        DAOclients vmDaoClient;
        DAOsalles vmDaoSalle;
        DAOtheme vmDaoTheme;
        daoObstacle vmDaoObstacle;
        private ICommand validCommand;
        daoReservation vmDaoReservation;
        private salle selectedSalle = new salle();
        private salle activeSalle = new salle();
        private ObservableCollection<salle> listSalle;
        private ObservableCollection<theme> listTheme;
        public ObservableCollection<salle> ListSalle { get => listSalle; set => listSalle = value; }
        public ObservableCollection<theme> ListTheme { get => listTheme; set => listTheme = value; }

        public string Ville
        {
            get => activeSalle.Ville;
            set
            {
                if (activeSalle.Ville != value)
                {
                    activeSalle.Ville = value;
                    //création d'un évènement si la propriété Name (bindée dans le XAML) change
                    OnPropertyChanged("Ville");
                }
            }
        }


        public salle SelectedSalle
        {
            get => selectedSalle;
            set
            {
                if (selectedSalle != value)
                {
                    selectedSalle = value;
                    //création d'un évènement si la propriété Name (bindée dans le XAML) change
                    OnPropertyChanged("SelectedSalle");
                    if (selectedSalle != null)
                    {
                        ActiveSalle = selectedSalle;
                    }
                }
            }
        }

        public salle ActiveSalle
        {
            get => activeSalle;
            set
            {
                if (activeSalle != value)
                {
                    activeSalle = value;
                    OnPropertyChanged("Ville");
                }
            }
        }

        public viewModelStatistiques(DAOavis thedaoavis, DAOclients thedaoclient, DAOsalles thedaosalle, DAOtheme thedaotheme, daoReservation thedaoreservation, daoObstacle thedaoobstacle)
        {         
            vmDaoSalle = thedaosalle;
            listSalle = new ObservableCollection<salle>(thedaosalle.SelectAll());

            vmDaoTheme = thedaotheme;
            listTheme = new ObservableCollection<theme>(thedaotheme.SelectAll());


            foreach (salle laSalle in ListSalle)
            {
                int i = 0;
                while (laSalle.LeTheme.IdTheme != listTheme[i].IdTheme)
                {
                    i++;
                }
                laSalle.LeTheme = listTheme[i];
            }
        }

        public ICommand ValidCommand
        {
            get
            {
                if (this.validCommand == null)
                {
                    this.validCommand = new RelayCommand(() => ValidInfo(), () => true);
                }
                return this.validCommand;
            }
        }

        private void ValidInfo()
        {
           
        }
    }
}
