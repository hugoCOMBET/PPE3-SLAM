﻿using PPE3_SLAM_Thalia;
using Model.Business;
using Model.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDirecteur_PPE3.viewModel
{
    class viewModelAvis
    {
        DAOavis vmDaoAvis;
        DAOclients vmDaoClient;
        DAOsalles vmDaoSalle;
        DAOtheme vmDaoTheme;
        daoReservation vmDaoReservation;
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
                //int i = 0;
                //while (leAvis.salles.Id != listAvis[i].Id)
                //{
                //    i++;
                //}
                //lefromage.Origin = listPays[i];
            }
        }
    }
}