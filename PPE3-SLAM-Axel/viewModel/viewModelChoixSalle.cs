using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Model.Business;
using Model.Data;
using System.Windows;



namespace PPE3_SLAM_Axel.viewModel
{
    class viewModelChoixSalle : viewModelBase 
    {
        
        private DAOtheme vmdaotheme;
        private DAOsalles vmdaosalle;

        private DateTime laDateReservation;
        private salles selectedSalle;
        
        private ICommand choixCommand;

        private ObservableCollection<salles> listSalles;

        public ObservableCollection<salles> ListSalles { get => listSalles; set => listSalles = value; }

        public viewModelChoixSalle(DAOtheme unDaoTheme, DAOsalles unDaoSalle, DateTime LaDate)
        {
            laDateReservation = LaDate;
            vmdaotheme = unDaoTheme;
            vmdaosalle = unDaoSalle;
            listSalles = new ObservableCollection<salles>(unDaoSalle.SelectAllByFieldTestCondition("id not in (select count(id) from Reservation where dayofmonth(DateReservation)= "+LaDate.Day+" and month(DateReservation) = "+LaDate.Month+" and year(DateReservation) = "+LaDate.Year+" and hour(DateReservation) = '"+LaDate.Hour+"%');"));
        }

        public salles SelectedSalle
        {
            get => selectedSalle;
            set
            {
                if(selectedSalle!= value)
                {
                    selectedSalle = value;
                    OnPropertyChanged("SelectedSalle");
                    OnPropertyChanged("IdSalle");
                    OnPropertyChanged("LaVille");
                    OnPropertyChanged("LeTheme");
                }
            }
        }

        public int IdSalle
        {
            get
            {
                if(selectedSalle!= null)
                {
                    return selectedSalle.IdSalle;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                if(selectedSalle.IdSalle!=value)
                {
                    selectedSalle.IdSalle = value;
                    OnPropertyChanged("IdSalle");
                }
            }
        }

        public string LaVille
        {
            get
            {
                if(selectedSalle!= null)
                {
                    return selectedSalle.Ville;
                }
                else
                {
                    return null;
                }
            }

            set
            {
                if(selectedSalle.Ville!=value)
                {
                    selectedSalle.Ville = value;
                    OnPropertyChanged("LaVille");
                }
            }
        }

        public theme LeTheme
        {
            get
            {
                if(selectedSalle!=null)
                {
                    return selectedSalle.LeTheme;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if(selectedSalle.LeTheme!=value)
                {
                    selectedSalle.LeTheme = value;
                    OnPropertyChanged("LeTheme");
                }
            }
        }

        public ICommand ChoisirCommand
        {
            get
            {
                if (this.choixCommand == null)
                {
                    this.choixCommand = new RelayCommand(() => Choisir(), () => true);
                }
                return this.choixCommand;

            }

        }

        public void Choisir()
        {
            Dbal thedbal = new Dbal("LSRGames");
            DAOclients thedaoclients = new DAOclients(thedbal);
            daoObstacle thedaoobstacle = new daoObstacle(thedbal);
            MessageBoxResult msg;
            Window3 wnd = new Window3(thedaoclients, thedaoobstacle, laDateReservation, SelectedSalle);
            if (SelectedSalle != null)
            {
                wnd.Show();
            }
            else
            {
                msg = MessageBox.Show("Vous n'avez pas sélectionner de salle");

            }
        }







    }


}
