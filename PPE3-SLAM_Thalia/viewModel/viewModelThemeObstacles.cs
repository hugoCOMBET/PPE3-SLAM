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

namespace AppDirecteur_PPE3.viewModel
{
    class viewModelThemeObstacles : viewModelBase
    {
        DAOavis vmDaoAvis;
        DAOclients vmDaoClient;
        DAOsalles vmDaoSalle;
        DAOtheme vmDaoTheme;
        private ICommand updateCommand;
        private ICommand deleteCommand;
        private ICommand addCommand;
        daoReservation vmDaoReservation;
        private salle selectedSalle = new salle();
        private salle activeSalle = new salle();
        private theme selectedTheme = new theme();
        private theme activeTheme = new theme();
        private Obstacle selectedObstacle = new Obstacle();
        private Obstacle activeObstacle = new Obstacle();
        private ObservableCollection<salle> listSalle;
        private ObservableCollection<theme> listTheme;
        private ObservableCollection<Obstacle> listObstacle;
        public ObservableCollection<Obstacle> ListObstacle { get => listObstacle; set => listObstacle = value; }
        public ObservableCollection<salle> ListSalle { get => listSalle; set => listSalle = value; }
        public ObservableCollection<theme> ListTheme { get => listTheme; set => listTheme = value; }

        public viewModelThemeObstacles(DAOavis thedaoavis, DAOclients thedaoclient, DAOsalles thedaosalle, DAOtheme thedaotheme, daoReservation thedaoreservation)
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

        public string NomTheme
        {
            get => activeTheme.Theme;
            set
            {
                if (activeTheme.Theme != value)
                {
                    activeTheme.Theme = value;
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

        public theme SelectedTheme
        {
            get => selectedTheme;
            set
            {
                if (selectedTheme != value)
                {
                    selectedTheme = value;
                    //création d'un évènement si la propriété Name (bindée dans le XAML) change
                    OnPropertyChanged("SelectedTheme");
                    if (selectedTheme != null)
                    {
                        ActiveTheme = selectedTheme;
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
                    activeTheme= value;
                    OnPropertyChanged("NomTheme");
                }
            }
        }

        public Obstacle SelectedObstacle
        {
            get => selectedObstacle;
            set
            {
                if (selectedObstacle != value)
                {
                    selectedObstacle = value;
                    //création d'un évènement si la propriété Name (bindée dans le XAML) change
                    OnPropertyChanged("SelectedTheme");
                    if (selectedObstacle != null)
                    {
                        ActiveObstacle = selectedObstacle;
                    }
                }
            }
        }

        public Obstacle ActiveObstacle
        {
            get => activeObstacle;
            set
            {
                if (activeObstacle != value)
                {
                    activeObstacle = value;
                    OnPropertyChanged("NomTheme");
                }
            }
        }

        public ICommand UpdateCommand
        {
            get
            {
                if (this.updateCommand == null)
                {
                    this.updateCommand = new RelayCommand(() => UpdateFromage(), () => true);
                }
                return this.updateCommand;
            }

        }

        public ICommand DeleteCommand
        {
            get
            {
                if (this.deleteCommand == null)
                {
                    this.deleteCommand = new RelayCommand(() => DeleteFromage(), () => true);
                }
                return this.deleteCommand;
            }
        }

        public ICommand AddCommand
        {
            get
            {
                if (this.addCommand == null)
                {
                    this.addCommand = new RelayCommand(() => AddFromage(), () => true);
                }
                return this.addCommand;
            }
        }


        private void UpdateTheme()
        {
            theme backup = new theme();
            backup = ActiveTheme;
            this.vmDaoTheme.Update(this.ActiveTheme);
            int a = listTheme.IndexOf(SelectedTheme);
            listTheme.Insert(a, ActiveTheme);
            listTheme.RemoveAt(a + 1);
            SelectedTheme = backup;
            MessageBox.Show("Mis à jour réussis");
        }

        private void AddTheme()
        {
            theme select = new theme();
            this.vmDaoTheme.Insert(this.ActiveTheme();
            listFromages.Add(this.ActiveFromage);
            select = this.ActiveFromage;
            SelectedFromage = select;
            MessageBox.Show("Fromage ajouté");
        }

        private void DeleteTheme()
        {
            Fromage backup = new Fromage();
            backup = ActiveFromage;
            this.vmDaoFromage.Delete(this.ActiveFromage);
            int a = listFromages.IndexOf(SelectedFromage);
            listFromages.RemoveAt(a);
            MessageBox.Show("Fromage supprimé");
        }
    }
}
