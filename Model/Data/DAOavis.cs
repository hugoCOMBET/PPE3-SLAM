using Model.Business;
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
        public class DAOavis
        {
            #region Attributs
            private Dbal _dbal;
            private DAOclients _DAOclient;
            private DAOsalles _DAOsalles;
            #endregion

            #region Constructeur
            public DAOavis(Dbal dbal, DAOclients DAOclient, DAOsalles DAOsalles)
            {
                _dbal = dbal;
                _DAOclient = DAOclient;
                _DAOsalles = DAOsalles;
            }
            #endregion

            #region Autres méthodes
            public List<avis> SelectAll()
            {
                List<avis> listAvis = new List<avis>();
                DataTable myTable = this._dbal.SelectAll("avis");

                foreach (DataRow r in _dbal.SelectAll("avis").Rows)
                {
                Clients unClient = this._DAOclient.SelectById((int)r["idClient"]);
                salle uneSalle = this._DAOsalles.SelectById((int)r["idSalle"]);
                listAvis.Add(new avis((int)r["id"], unClient, uneSalle, (string)r["avis"], (int)r["note"]));
                }
                return listAvis;
            }

            public string SelectAvg(string table)
            {
                DataRow r = _dbal.SelectAvg(table);
                string note = Convert.ToString(r);
                return note;
            }
            #endregion
    }
}
