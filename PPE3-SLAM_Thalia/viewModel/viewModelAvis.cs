using PPE3_SLAM_Thalia;
using Model.Business;
using Model.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System;

namespace AppDirecteur_PPE3.viewModel
{
    class viewModelAvis : viewModelBase
    {
        DAOavis vmDaoAvis;
        DAOclients vmDaoClient;
        DAOsalles vmDaoSalle;
        DAOtheme vmDaoTheme;
        daoReservation vmDaoReservation;
        private salle activeSalle = new salle();
        private theme activeTheme = new theme();
        private avis selectedAvis = new avis();
        private ObservableCollection<avis> listAvis;
        private ObservableCollection<theme> listTheme;
        private ObservableCollection<salle> listSalle;

        public ObservableCollection<avis> ListAvis { get => listAvis; set => listAvis = value; }
        public ObservableCollection<theme> ListTheme { get => listTheme; set => listTheme = value; }
        public ObservableCollection<salle> ListSalle { get => listSalle; set => listSalle = value; }

        public viewModelAvis(DAOavis thedaoavis, DAOclients thedaoclient, DAOsalles thedaosalle, DAOtheme thedaotheme, daoReservation thedaoreservation)
        {
            vmDaoAvis = thedaoavis;
            listAvis = new ObservableCollection<avis>(thedaoavis.SelectAll());

            vmDaoSalle = thedaosalle;
            listSalle = new ObservableCollection<salle>(thedaosalle.SelectAll());

            vmDaoTheme = thedaotheme;
            listTheme = new ObservableCollection<theme>(thedaotheme.SelectAll());

            
            foreach (avis leAvis in ListAvis)
            {                
                int i = 0;
                while (leAvis.IdSalle.IdSalle != listSalle[i].IdSalle)
                {
                    i++;
                }
                leAvis.IdSalle = listSalle[i];
            }

            foreach (salle laSalle in ListSalle)
            {
                int i = 0;
                while (laSalle.LeTheme.IdTheme != ListTheme[i].IdTheme)
                {
                    i++;
                }
                laSalle.LeTheme = listTheme[i];
            }
        }


        public avis SelectedAvis
        {
            get => selectedAvis;
            set
            {
                if (selectedAvis != value)
                {
                    selectedAvis = value;
                    //création d'un évènement si la propriété Name (bindée dans le XAML) change
                    OnPropertyChanged("SelectedAvis");
                    if (selectedAvis != null)
                    {
                        ActiveTheme = selectedAvis;
                        ActiveSalle = selectedAvis;
                    }
                }
            }
        }

        public theme ActiveTheme
        {
            get => activeTheme;
            set
            {
                if (activeTheme != value)
                {
                    activeTheme = value;
                    //création d'un évènement si la propriété Name (bindée dans le XAML) change
                    OnPropertyChanged("Name");
                    OnPropertyChanged("Origin");
                    OnPropertyChanged("Creation");
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
                    //création d'un évènement si la propriété Name (bindée dans le XAML) change
                    OnPropertyChanged("Name");
                    OnPropertyChanged("Origin");
                    OnPropertyChanged("Creation");
                }
            }
        }
    }
}
