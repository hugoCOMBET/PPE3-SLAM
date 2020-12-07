using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Model.Business;
using Model.Data;
using PPE3_SLAM_HUGO.viewModel;
using System.Windows;

namespace PPE3_SLAM_HUGO.viewModel
{
    class viewModelPPE3Hugo : viewModelBase
    {
        private DAOtransactions vmDaoTransaction;
        private DAOclients vmDaoClients;

        private ObservableCollection<Transactions> listTransactions;
        private ObservableCollection<Clients> listClient;

        public ObservableCollection<Clients> ListClient { get => listClient; set => listClient = value; }
        public ObservableCollection<Transactions> ListTransactions { get => listTransactions; set => listTransactions = value; }

        private ICommand updateCommand;
        private ICommand supprimerCommand;
        private ICommand ajouterCommand;

        public viewModelPPE3Hugo(DAOtransactions thedaoTransaction, DAOclients thedaoClient)
        {
            vmDaoTransaction = thedaoTransaction;
            ListTransactions = new ObservableCollection<Transactions>(thedaoTransaction.SelectAll());
            vmDaoClients = thedaoClient;
            listClient = new ObservableCollection<Clients>(thedaoClient.SelectAll());
        }
    }
}
