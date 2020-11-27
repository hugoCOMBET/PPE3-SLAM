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

        public daoReservation(Dbal unDBAL)
        {
            _DBAL = unDBAL;
        }

        public void Insert(Reservation uneReservation)
        {
            _DBAL.Insert(" Reservation VALUES (" + uneReservation.IdReservation + "," + uneReservation.LeClient+","+uneReservation.LaSalle+","+uneReservation.LaTransaction+",'"+uneReservation.DateReservation+"',"+uneReservation.NbJoueurs+","+uneReservation.NbObstacles+");");
        }

        public void Update(Reservation uneReservation)
        {
            _DBAL.Update(" Reservation SET idReservation = "+uneReservation.IdReservation+",idClient = "+uneReservation.LeClient + ",idSalle = "+uneReservation.LaSalle + ",idTransaction = "+uneReservation.LaTransaction + ",dateReservation = " + uneReservation.DateReservation + ", nbJoueurs = " + uneReservation.NbJoueurs + ", nbObstacles = " + uneReservation.NbObstacles + "WHERE idReservation = " + uneReservation.IdReservation + ";");
        }


        public void Delete(Reservation uneReservation)
        {
            _DBAL.Delete(" Reservation WHERE idReservation = "+uneReservation.IdReservation + ";");
        }

        public List<Reservation> SelectAll()
        {
            List<Reservation> uneListeReservation = new List<Reservation>();
            DataTable uneDataTable = _DBAL.SelectAll("Reservation");
            foreach(DataRow dtr in uneDataTable.Rows )
            {
                Reservation uneReservation = new Reservation((int)dtr["idReservation"], (Clients)dtr["idClient"], (salles)dtr["idSalle"], (Transactions)dtr["idTransaction"], (DateTime)dtr["dateReservation"], (int)dtr["nbJoueurs"], (int)dtr["nbObstacles"]);
                uneListeReservation.Add(uneReservation);
            }
            return uneListeReservation;
        }

        public Reservation SelectById(int idReservation)
        {
            DataRow UneDataRow = _DBAL.SelectById("Reservation", idReservation);
            Reservation uneReservation = new Reservation((int)UneDataRow["idReservation"], (Clients)UneDataRow["idClient"], (salles)UneDataRow["idSalle"], (Transactions)UneDataRow["idTransaction"], (DateTime)UneDataRow["dateReservation"], (int)UneDataRow["nbJoueurs"], (int)UneDataRow["nbObstacles"]);
            return uneReservation;
        }
    }
}
