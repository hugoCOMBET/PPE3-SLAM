using AppDirecteur_PPE3.viewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Model.Data;

namespace PPE3_SLAM_Thalia.viewModel
{
    class viewModelMainWindow : viewModelBase
    {
        private ICommand avisCommand;
        private ICommand statCommand;
        private ICommand themeCommand;
        private DAOavis vmdaoavis;
        private DAOclients vmdaoclient;
        private DAOsalles vmdaosalle;
        private DAOtheme vmdaotheme;
        private daoReservation vmdaoreservation;

        //déclaration du contructeur de viewModelMainWindow
        public viewModelMainWindow(DAOavis unavis, DAOclients unclient, DAOsalles unesalle, DAOtheme untheme, daoReservation unereservation)
        {
            vmdaoavis = unavis;
            vmdaoclient = unclient;
            vmdaosalle = unesalle;
            vmdaotheme = untheme;
            vmdaoreservation = unereservation;
        }

        public ICommand AvisCommand
        {
            get
            {
                if (this.avisCommand == null)
                {
                    this.avisCommand = new RelayCommand(() => AvisPage(), () => true);
                }
                return this.avisCommand;
            }
        }

        public ICommand StatCommand
        {
            get
            {
                if (this.statCommand == null)
                {
                    this.statCommand = new RelayCommand(() => StatPage(), () => true);
                }
                return this.statCommand;
            }
        }

        public ICommand ThemeCommand
        {
            get
            {
                if (this.themeCommand == null)
                {
                    this.themeCommand = new RelayCommand(() => ThemePage(), () => true);
                }
                return this.themeCommand;
            }
        }

        private void AvisPage()
        {
            Avis wndAvis = new Avis();
            wndAvis.Show();
        }

        private void StatPage()
        {
            Statistiques wndStat = new Statistiques();
            wndStat.Show();
        }
        private void ThemePage()
        {
            Theme_Obstacle wndThemes = new Theme_Obstacle();
            wndThemes.Show();
        }
    }
}
