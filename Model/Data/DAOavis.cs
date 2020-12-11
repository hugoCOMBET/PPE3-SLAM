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
                Clients unClient = this._DAOclient.SelectById((int)r["id"]);
                salle uneSalle = this._DAOsalles.SelectById((int)r["id"]);
                listAvis.Add(new avis((int)r["id"], unClient, uneSalle, (string)r["avis"], (int)r["note"]));
                }
                return listAvis;
            }

            public avis SelectByName(string avis)
            {
                DataRow r = _dbal.SelectByField("avis", "avis like '" + avis + "'").Rows[0];
                Clients unClient = this._DAOclient.SelectById((int)r["id"]);
                salle uneSalle = this._DAOsalles.SelectById((int)r["id"]);
                return new avis((int)r["id"], unClient, uneSalle, (string)r["avis"], (int)r["note"]);
            }

            public avis SelectById(int idAvis)
            {
                DataRow r = _dbal.SelectById("avis", idAvis);
                Clients unClient = this._DAOclient.SelectById((int)r["id"]);
                salle uneSalle = this._DAOsalles.SelectById((int)r["id"]);
                return new avis((int)r["id"], unClient, uneSalle, (string)r["avis"], (int)r["note"]);
            }
            #endregion
        }
    }
