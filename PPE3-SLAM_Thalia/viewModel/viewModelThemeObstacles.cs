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
        daoObstacle vmDaoObstacle;
        private ICommand updateCommandTh;
        private ICommand deleteCommandTh;
        private ICommand addCommandTh;
        private ICommand updateCommandObs;
        private ICommand deleteCommandObs;
        private ICommand addCommandObs;
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

        public viewModelThemeObstacles(DAOavis thedaoavis, DAOclients thedaoclient, DAOsalles thedaosalle, DAOtheme thedaotheme, daoReservation thedaoreservation, daoObstacle thedaoobstacle)
        {
            vmDaoSalle = thedaosalle;
            listSalle = new ObservableCollection<salle>(thedaosalle.SelectAll());

            vmDaoTheme = thedaotheme;
            listTheme = new ObservableCollection<theme>(thedaotheme.SelectAll());

            vmDaoObstacle = thedaoobstacle;
            listObstacle = new ObservableCollection<Obstacle>(thedaoobstacle.SelectAll());


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


        public theme Theme
        {
            get
            {
                if (selectedObstacle != null)
                    return selectedSalle.LeTheme;
                else
                    return null;
            }
            set
            {
                if (selectedSalle.LeTheme != value)
                {
                    selectedSalle.LeTheme = value;
                    //création d'un évènement si la propriété Name (bindée dans le XAML) change
                    OnPropertyChanged("Theme");
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
                    OnPropertyChanged("Theme");
                    OnPropertyChanged("listObstacle");
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
                    OnPropertyChanged("Salle");
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
                    activeTheme = value;
                    OnPropertyChanged("Theme");
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
                    OnPropertyChanged("NomObstacle");
                }
            }
        }

        public ICommand UpdateCommandTh
        {
            get
            {
                if (this.updateCommandTh == null)
                {
                    this.updateCommandTh = new RelayCommand(() => UpdateTheme(), () => true);
                }
                return this.updateCommandTh;
            }

        }

        public ICommand DeleteCommandTh
        {
            get
            {
                if (this.deleteCommandTh == null)
                {
                    this.deleteCommandTh = new RelayCommand(() => DeleteTheme(), () => true);
                }
                return this.deleteCommandTh;
            }
        }

        public ICommand AddCommandTh
        {
            get
            {
                if (this.addCommandTh == null)
                {
                    this.addCommandTh = new RelayCommand(() => AddTheme(), () => true);
                }
                return this.addCommandTh;
            }
        }

        public ICommand UpdateCommandObs
        {
            get
            {
                if (this.updateCommandObs == null)
                {
                    this.updateCommandObs = new RelayCommand(() => UpdateObstacle(), () => true);
                }
                return this.updateCommandObs;
            }

        }

        public ICommand DeleteCommandObs
        {
            get
            {
                if (this.deleteCommandObs == null)
                {
                    this.deleteCommandObs = new RelayCommand(() => DeleteObstacle(), () => true);
                }
                return this.deleteCommandObs;
            }
        }

        public ICommand AddCommandObs
        {
            get
            {
                if (this.addCommandObs == null)
                {
                    this.addCommandObs = new RelayCommand(() => AddObstacle(), () => true);
                }
                return this.addCommandObs;
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
            this.vmDaoTheme.Insert(this.ActiveTheme);
            listTheme.Add(this.ActiveTheme);
            select = this.ActiveTheme;
            SelectedTheme = select;
            MessageBox.Show("Thème ajouté");
        }

        private void DeleteTheme()
        {
            theme backup = new theme();
            backup = ActiveTheme;
            this.vmDaoTheme.Delete(this.ActiveTheme);
            int a = listTheme.IndexOf(SelectedTheme);
            listTheme.RemoveAt(a);
            MessageBox.Show("Thème supprimé");
        }

        private void UpdateObstacle()
        {
            Obstacle backup = new Obstacle();
            backup = ActiveObstacle;
            this.vmDaoObstacle.Update(this.ActiveObstacle);
            int a = listObstacle.IndexOf(SelectedObstacle);
            listObstacle.Insert(a, ActiveObstacle);
            listObstacle.RemoveAt(a + 1);
            SelectedObstacle = backup;
            MessageBox.Show("Mis à jour réussis");
        }

        private void AddObstacle()
        {
            Obstacle select = new Obstacle();
            this.vmDaoObstacle.Insert(this.ActiveObstacle);
            listObstacle.Add(this.ActiveObstacle);
            select = this.ActiveObstacle;
            SelectedObstacle = select;
            MessageBox.Show("Obstacle ajouté");
        }

        private void DeleteObstacle()
        {
            Obstacle backup = new Obstacle();
            backup = ActiveObstacle;
            this.vmDaoObstacle.Delete(this.ActiveObstacle);
            int a = listObstacle.IndexOf(SelectedObstacle);
            listObstacle.RemoveAt(a);
            MessageBox.Show("Obstacle supprimé");
        }
    }
}
