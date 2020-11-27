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
            //private DAOclient _DAOclient;
            private DAOsalles _DAOsalles;
            #endregion

            #region Constructeur
            public void DAOAvis(Dbal dbal, DAOsalles DAOsalles)
            {
                _dbal = dbal;
                //_DAOclient = DAOclient;
                _DAOsalles = DAOsalles;
            }
            #endregion

            #region Autres méthodes
            public void insert(avis unavis)
            {
                string AvisInsert;

                AvisInsert = ("avis (idAvis, idClient, idSalle, avis) values (" + unavis.IdAvis + "," + unavis.LeClient + "," + unavis.IdSalle + ",'" + unavis.Avis.Replace("'", "''") + "')");
                _dbal.Insert(AvisInsert);
            }

            public void delete(avis unavis)
            {
                string AvisDelete;

                AvisDelete = ("avis where id ='" + unavis.IdAvis + "'");
                _dbal.Delete(AvisDelete);
            }

            public void update(avis unavis)
            {
                string AvisUpdate;

                AvisUpdate = ("avis set idAvis ='" + unavis.IdAvis + "', idClient = '" + unavis.LeClient + "', idSalle ='" + unavis.IdSalle + "', avis = '" + unavis.Avis.Replace("'", "''") + "'");
                _dbal.Update(AvisUpdate);
            }

            public List<avis> SelectAll()
            {
                List<avis> listAvis = new List<avis>();
                foreach (DataRow r in _dbal.SelectAll("avis").Rows)
                {
                    listAvis.Add(new avis((int)r["idAvis"], (Clients)r["idClient"], (salles)r["idSalle"], (string)r["avis"]));
                }
                return listAvis;
            }

            public avis SelectByName(string avis)
            {
                DataRow r = _dbal.SelectByField("avis", "avis like '" + avis + "'").Rows[0];
                return new avis((int)r["idAvis"], (Clients)r["idClient"], (salles)r["idSalle"], (string)r["avis"]);
            }

            public avis SelectById(int idAvis)
            {
                DataRow r = _dbal.SelectById("avis", idAvis);
                return new avis((int)r["idAvis"], (Clients)r["idClient"], (salles)r["idSalle"], (string)r["avis"]);
            }
            #endregion
        }
    }
