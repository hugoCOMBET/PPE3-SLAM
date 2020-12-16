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
        
        private DAOtheme vmdaotheme;
        private DAOsalles vmdaosalle;

        private salles selectedSalle;
        private ICommand retourCommand;
        private ICommand choixCommand;

        private ObservableCollection<salles> listSalles;

        public ObservableCollection<salles> ListSalles { get => listSalles; set => listSalles = value; }

        public viewModelChoixSalle(DAOtheme unDaoTheme, DAOsalles unDaoSalle, DateTime LaDate)
        {
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



        public ICommand RetourCommand
        {
            get
            {
                if (this.retourCommand == null)
                {
                    this.retourCommand = new RelayCommand(() => Retour(), () => true);
                }
                return this.retourCommand;

            }

        }

        public ICommand ChoixCommand
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

        

        public static void Retour()
        {
            
            
        }

        public static void Choisir()
        {
            Window3 wnd = new Window3();
            wnd.Show();
        }

    }


}
