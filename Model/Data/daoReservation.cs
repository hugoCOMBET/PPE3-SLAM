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
    public class daoReservation
    {
        private Dbal _DBAL;
        private DAOclients _daoClient;
        private DAOsalles _DaoSalle;
        private DAOtransactions _DaoTransactions;
        private DAOtheme _DaoTheme;

        public daoReservation(Dbal unDBAL)
        {
            _DBAL = unDBAL;
            _DaoTheme = new DAOtheme(_DBAL);
            _DaoSalle = new DAOsalles(_DBAL,_DaoTheme);
            _daoClient = new DAOclients(_DBAL);
            _DaoTransactions = new DAOtransactions(_DBAL, _daoClient);
        }

        public void Insert(Reservation uneReservation)
        {
            _DBAL.Insert(" Reservation VALUES (" + uneReservation.IdReservation + "," + uneReservation.LeClient.getIdClient()+",'"+/*uneReservation.LaSalle.IdSalle*/uneReservation.DateReservation + "',"+/*uneReservation.LaTransaction.getIdTransactions()*/uneReservation.NbJoueurs + ","+/*uneReservation.DateReservation*/uneReservation.NbObstacles + ","+ uneReservation.LaSalle.IdSalle + ","+ uneReservation.LaTransaction.getIdTransactions() + ");");
        }

        public void Update(Reservation uneReservation)
        {
            _DBAL.Update(" Reservation SET id = "+uneReservation.IdReservation+",idClient = "+uneReservation.LeClient.getIdClient() + ",idSalle = "+uneReservation.LaSalle.IdSalle + ",idTransaction = "+uneReservation.LaTransaction.getIdTransactions() + ",DateReservation = '" + uneReservation.DateReservation + "', nbJoueurs = " + uneReservation.NbJoueurs + ", nbObstacle = " + uneReservation.NbObstacles + "  WHERE id = " + uneReservation.IdReservation + ";");
        }


        public void Delete(Reservation uneReservation)
        {
            _DBAL.Delete(" Reservation WHERE id = "+uneReservation.IdReservation + ";");
        }

        public List<Reservation> SelectAll()
        {
            List<Reservation> uneListeReservation = new List<Reservation>();
            DataTable uneDataTable = _DBAL.SelectAll("Reservation");
            foreach (DataRow dtr in uneDataTable.Rows)
            {
                
                Clients myclient = this._daoClient.SelectById((int)dtr["idClient"]);
                salles mysalle = this._DaoSalle.SelectById((int)dtr["idSalle"]);
                Transactions mytransactions = this._DaoTransactions.SelectById((int)dtr["idTransaction"]);
                Reservation uneReservation = new Reservation((int)dtr["id"], myclient, mysalle, mytransactions, (DateTime)dtr["DateReservation"], (int)dtr["nbJoueurs"], (int)dtr["nbObstacle"]);
                uneListeReservation.Add(uneReservation);
            }
            return uneListeReservation;
        }

        public Reservation SelectById(int idReservation)
        {
            DataRow UneDataRow = _DBAL.SelectById("Reservation", idReservation);
            
            Clients myclient = this._daoClient.SelectById((int)UneDataRow["idClient"]);
            salles mysalle = this._DaoSalle.SelectById((int)UneDataRow["idSalle"]);
            //int i = (int)UneDataRow["idTransaction"];
            Transactions mytransactions = this._DaoTransactions.SelectById((int)UneDataRow["idTransaction"]);
            Reservation uneReservation = new Reservation((int)UneDataRow["id"], myclient, mysalle, mytransactions, (DateTime)UneDataRow["DateReservation"], (int)UneDataRow["nbJoueurs"], (int)UneDataRow["nbObstacle"]);
            return uneReservation;
        }
    }
}
