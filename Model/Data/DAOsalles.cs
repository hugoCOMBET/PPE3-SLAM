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
    public class DAOsalles
    {
        #region Attributs
        public Dbal _dbal;
        #endregion

        #region Constructeurs
        public DAOsalles(Dbal dbal)
        {
            _dbal = dbal;
        }
        #endregion


        #region Autres méthodes
        public void insert(salles unesalle)
        {
            string SalleInsert;

            SalleInsert = ("salle (id, ville, idTheme) values (" + unesalle.IdSalle + ",'" + unesalle.Ville.Replace("'", "''") + "'," + unesalle.LeTheme.IdTheme + ")");
            _dbal.Insert(SalleInsert);
        }

        public void delete(salles unesalle)
        {
            string SalleDelete;

            SalleDelete = ("salle where id ='" + unesalle.IdSalle + "'");
            _dbal.Delete(SalleDelete);
        }

        public void update(salles unesalle)
        {
            string SalleUpdate;

            SalleUpdate = ("Salle set id = '" + unesalle.IdSalle + "' , ville = '" + unesalle.Ville.Replace("'", "''")+"', idTheme = '" + unesalle.LeTheme.IdTheme + "' WHERE id = " + unesalle.IdSalle );
            _dbal.Update(SalleUpdate);
        }

        public List<salles> SelectAll()
        {
            List<salles> listSalles = new List<salles>();
            foreach (DataRow r in _dbal.SelectAll("Salle").Rows)
            {
                listSalles.Add(new salles((int)r["id"], (string)r["ville"], (theme)r["idTheme"]));
            }
            return listSalles;
        }

        public salles SelectByName(string salle)
        {
            DataRow r = _dbal.SelectByField("salles", "nom like '" + salle + "'").Rows[0];
            return new salles((int)r["id"], (string)r["ville"], (theme)r["idSalle"]);
        }

        public salles SelectById(int idSalle)
        {
            DataRow r = _dbal.SelectById("salle", idSalle);
            return new salles((int)r["id"], (string)r["ville"], (theme)r["idSalle"]);
        }

        public long SelectCount(string attribut,string fieldtestcondition)
        {
            long i = 0;
            DataRow uneDataRow = _dbal.SelectCount(attribut,"Salle", fieldtestcondition);
            i = (long)uneDataRow["NbSalles"];
            return i;
        }
        #endregion
    }
}
