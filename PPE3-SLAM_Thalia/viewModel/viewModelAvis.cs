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
        daoObstacle vmDaoObstacle;
        daoReservation vmDaoReservation;
        private ICommand validCommand;
        private salle activeSalle = new salle();
        private theme activeTheme = new theme();
        private avis activeAvis = new avis();
        private avis selectedAvis = new avis();
        private theme selectedTheme = new theme();
        private salle selectedSalle = new salle();

        private ObservableCollection<avis> listAvis;
        private ObservableCollection<theme> listTheme;
        private ObservableCollection<salle> listSalle;

        public ObservableCollection<avis> ListAvis { get => listAvis; set => listAvis = value; }
        public ObservableCollection<theme> ListTheme { get => listTheme; set => listTheme = value; }
        public ObservableCollection<salle> ListSalle { get => listSalle; set => listSalle = value; }

        public viewModelAvis(DAOavis thedaoavis, DAOclients thedaoclient, DAOsalles thedaosalle, DAOtheme thedaotheme, daoReservation thedaoreservation, daoObstacle thedaoobstacle)
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
                       ActiveAvis = selectedAvis;
                    }
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
                    if (selectedAvis != null)
                    {
                        ActiveSalle = selectedSalle;
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
                }
            }
        }

        public avis ActiveAvis
        {
            get => activeAvis;
            set
            {
                if (activeAvis != value)
                {
                    activeAvis = value;
                    //création d'un évènement si la propriété Name (bindée dans le XAML) change
                }
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
            salle LaSalle = this.ActiveSalle;
            theme LeTheme = this.ActiveTheme;

            foreach (salle laSalle in ListSalle)
            {
                if (LeTheme.IdTheme != laSalle.LeTheme.IdTheme)
                {
                    listSalle.Remove(laSalle);
                }
            }

            foreach (avis leAvis in ListAvis)
            {
                if (LaSalle.IdSalle != leAvis.IdSalle.IdSalle)
                {
                    listAvis.Remove(leAvis);
                }
            }
        }
    }
}
