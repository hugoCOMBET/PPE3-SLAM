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
        daoReservation vmDaoReservation;
        private Reservation activeReservation = new Reservation();
        private salle selectedSalle = new salle();
        private Reservation selectedReservation = new Reservation();
        private ObservableCollection<salle> listSalle;
        private ObservableCollection<theme> listTheme;
        private ObservableCollection<Reservation> listReservation;
        public ObservableCollection<salle> ListSalle { get => listSalle; set => listSalle = value; }
        public ObservableCollection<theme> ListTheme { get => listTheme; set => listTheme = value; }
        public ObservableCollection<Reservation> ListReservation { get => listReservation; set => listReservation = value; }

        public salle Salle
        {
            get
            {
                if (selectedReservation != null)
                    return selectedReservation.LaSalle;
                else
                    return null;
            }
            set
            {
                if (selectedReservation.LaSalle != value)
                {
                    selectedReservation.LaSalle = value;
                    //création d'un évènement si la propriété Name (bindée dans le XAML) change
                    OnPropertyChanged("Salle");
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
                }
            }
        }

        public Reservation SelectedReservation
        {
            get => selectedReservation;
            set
            {
                if (selectedReservation != value)
                {
                    selectedReservation = value;
                    //création d'un évènement si la propriété Name (bindée dans le XAML) change
                    OnPropertyChanged("SelectedReservation");
                    OnPropertyChanged("Salle");
                    if (selectedReservation != null)
                    {
                        ActiveReservation = selectedReservation;
                    }
                }
            }
        }

        public Reservation ActiveReservation
        {
            get => activeReservation;
            set
            {
                if (activeReservation != value)
                {
                    activeReservation = value;
                    //création d'un évènement si la propriété Name (bindée dans le XAML) change
                    OnPropertyChanged("Salle");
                }
            }
        }

        public viewModelStatistiques(DAOavis thedaoavis, DAOclients thedaoclient, DAOsalles thedaosalle, DAOtheme thedaotheme, daoReservation thedaoreservation, daoObstacle thedaoobstacle)
        {         
            vmDaoSalle = thedaosalle;
            listSalle = new ObservableCollection<salle>(thedaosalle.SelectAll());

            vmDaoTheme = thedaotheme;
            listTheme = new ObservableCollection<theme>(thedaotheme.SelectAll());

            vmDaoReservation = thedaoreservation;
            listReservation = new ObservableCollection<Reservation>(thedaoreservation.SelectAll());


            foreach (salle laSalle in ListSalle)
            {
                int i = 0;
                while (laSalle.LeTheme.IdTheme != listTheme[i].IdTheme)
                {
                    i++;
                }
                laSalle.LeTheme = listTheme[i];
            }

            foreach (Reservation laReservation in ListReservation)
            {
                int i = 0;
                while (laReservation.LaSalle.IdSalle != listSalle[i].IdSalle)
                {
                    i++;
                }
                laReservation.LaSalle = listSalle[i];
            }
        }
    }
}
