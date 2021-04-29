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
    class viewModelSelectionClient : viewModelBase
    {

        private DAOclients vmdaoclient;
        private daoObstacle vmdaoobstacle;
        private ICommand validerCommand;
        private ObservableCollection<Obstacle> listObstacles;
        private Clients selectedClient = new Clients();
        private ObservableCollection<Clients> listClients;
        private salles laSalle;
        private DateTime DateReservation;
        private int nbJoueurs;
        private int nbObstacles;

        public ObservableCollection<Clients> ListClients { get => listClients; set => listClients = value; }
        public ObservableCollection<Obstacle> ListObstacles { get => listObstacles; set => listObstacles = value; }
        public viewModelSelectionClient( daoObstacle unDaoObstacle,DAOclients unDaoClient,DateTime laDateReservation,salles uneSalle,int unNbJoueur, int unNbObstacle)
        {
            vmdaoclient = unDaoClient;
            listClients = new ObservableCollection<Clients>(vmdaoclient.SelectAll());
            vmdaoobstacle = unDaoObstacle;
            listObstacles = new ObservableCollection<Obstacle>(vmdaoobstacle.SelectAll());
            DateReservation = laDateReservation;
            laSalle = uneSalle;
            nbJoueurs = unNbJoueur;
            nbObstacles = unNbObstacle;
        }

        public Clients SelectedClient
        {
            get => selectedClient;
            set
            {
                if(selectedClient!=value)
                {
                    selectedClient = value;
                    OnPropertyChanged("SelectedClient");
                    OnPropertyChanged("Nom");
                    OnPropertyChanged("Prenom");
                    OnPropertyChanged("DateNaissance");
                    OnPropertyChanged("Adresse");
                    OnPropertyChanged("Telephone");
                    OnPropertyChanged("Email");
                    OnPropertyChanged("Id");
                    OnPropertyChanged("Credit");
                }
            }
        }

        public string Nom
        {
            get
            {
                if(selectedClient.NomClient!=null)
                {
                    return selectedClient.NomClient;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if(selectedClient.NomClient!= value)
                {
                    selectedClient.NomClient = value;
                    OnPropertyChanged("Nom");
                }
            }
        }

        public string Prenom
        {
            get
            {
                if(selectedClient.PrenomClient!=null)
                {
                    return selectedClient.PrenomClient;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if(selectedClient.PrenomClient != value)
                {
                    selectedClient.PrenomClient = value;
                    OnPropertyChanged("Prenom");
                }
            }
        }

        public string DateNaissance
        {
            get
            {
                if(selectedClient.DateNaissanceClient!=null)
                {
                    return selectedClient.DateNaissanceClient.ToString("f");
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if(selectedClient.DateNaissanceClient.ToString("f")!=value)
                {
                    selectedClient.DateNaissanceClient = DateTime.Parse(value);
                    OnPropertyChanged("DateNaissance");
                }
            }
        }

        public string Adresse
        {
            get
            {
                if(selectedClient.AdresseClient!=null)
                {
                    return selectedClient.AdresseClient;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if(selectedClient.AdresseClient!=value)
                {
                    selectedClient.AdresseClient = value;
                    OnPropertyChanged("Adresse");
                }
            }
        }

        public string Telephone
        {
            get
            {
                if(selectedClient.TelPortableCLient!=null)
                {
                    return selectedClient.TelPortableCLient;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if(selectedClient.TelPortableCLient!=value)
                {
                    selectedClient.TelPortableCLient = value;
                    OnPropertyChanged("Telephone");
                }
            }
        }

        public string Email
        {
            get
            {
                if(selectedClient.EmailClient!=null)
                {
                    return selectedClient.EmailClient;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if(selectedClient.EmailClient!=value)
                {
                    selectedClient.EmailClient = value;
                    OnPropertyChanged("Email");
                }
            }
        }

        public string Id
        {
            get
            {
                if(selectedClient.IdClient!=0)
                {
                    return selectedClient.IdClient.ToString();
                }
                else
                {
                    return "0";
                }
            }
            set
            {
                if(selectedClient.IdClient.ToString()!=value)
                {
                    selectedClient.IdClient = int.Parse(value);
                    OnPropertyChanged("Id");
                }
            }
        }
        public string Credit
        {
            get
            {
                if(selectedClient.CreditCLient!=0)
                {
                    return selectedClient.CreditCLient.ToString();
                }
                else
                {
                    return "0";
                }
            }
            set
            {
                if(selectedClient.CreditCLient.ToString()!=value)
                {
                    selectedClient.CreditCLient = double.Parse(value);
                    OnPropertyChanged("Credit");
                }
            }
        }

        public ICommand ValiderCommand
        {
            get
            {
                if (this.validerCommand == null)
                {
                    this.validerCommand = new RelayCommand(() => Valider(), () => true);
                }
                return this.validerCommand;

            }

        }


        public void Valider()
        {
            int n = 24;
            Dbal thedbal = new Dbal("LSRGames");
            
            
            daoReservation thedaoreservation = new daoReservation(thedbal);
           
            DAOtransactions thedaotransactions = new DAOtransactions(thedbal, vmdaoclient);
            
            Clients leClient = SelectedClient;
            
            Transactions uneTransaction = new Transactions(n, leClient, 5.25);
            
            thedaotransactions.Insert(uneTransaction);
            n = n + 1;
            Reservation uneReservation = new Reservation(42, leClient, laSalle, uneTransaction, DateReservation, nbJoueurs, nbObstacles);
            thedaoreservation.Insert(uneReservation);
        }

    }

}
