using CsvHelper;
using Model.Business;
using Model.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Model.Data
{
    public class DAOtransactions
    {
        private Dbal _dbal;

        private DAOclients TheDaoCLient;

        public DAOtransactions(Dbal dbal)
        {
            _dbal = dbal;
        }

        public void Insert(Transactions uneTransaction,Clients unClient)
        {
            string query = " Transactions VALUES " 
                + "(" + uneTransaction.getIdTransactions()
                + ",'" + unClient.getIdClient()
                + ",'" + uneTransaction.getMontantTransaction();
            this._dbal.Insert(query);
        }
        public void Update(Transactions uneTransaction,Clients unClient)
        {
            string query = "Transactions SET idTransaction = " 
                + uneTransaction.getIdTransactions()
                + ", idClient = '" + unClient.getIdClient()
                + ", MontantTransaction = '" + uneTransaction.getMontantTransaction()
                + "' WHERE idTransaction = " + uneTransaction.getIdTransactions();
            this._dbal.Update(query);
        }

        public void Delete(Transactions uneTransaction)
        {
            string query = "Transactions WHERE idTransaction = " + uneTransaction.getIdTransactions() + ";";
            this._dbal.Delete(query);
        }
        
        public List<Transactions> SelectAll()
        {
            List<Transactions> listeAll = new List<Transactions>();
            foreach (DataRow r in _dbal.SelectAll("Transactions").Rows)
            {
                Clients monClient = this.TheDaoCLient.SelectById((int)r["id"]);
                listeAll.Add
                    (new Transactions
                    ((int)r["idTransaction"],
                    monClient,
                    (double)r["MontantTransaction"]));
            }
            return listeAll;
        }
        
        public Transactions SelectById(int id)
        {    
            DataRow r = _dbal.SelectById("Utilisateur", id);
            Clients monClient = this.TheDaoCLient.SelectById((int)r["id"]);
            return new Transactions
                ((int)r["idTransaction"],
                monClient,
                (double)r["MontantTransaction"]); 
        }
    }
}
