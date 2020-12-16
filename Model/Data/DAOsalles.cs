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
        public DAOtheme undaoTheme;
        #endregion

        #region Constructeurs
        public DAOsalles(Dbal dbal, DAOtheme undaoTheme)
        {
            _dbal = dbal;
            this.undaoTheme = undaoTheme;
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

            SalleUpdate = ("Salle set id = '" + unesalle.IdSalle + "' , ville = '" + unesalle.Ville.Replace("'", "''") + "', idTheme = '" + unesalle.LeTheme.IdTheme + "' WHERE id = " + unesalle.IdSalle);
            _dbal.Update(SalleUpdate);
        }

        public List<salles> SelectAll()
        {
            List<salles> listSalles = new List<salles>();
            DataTable myTable = this._dbal.SelectAll("salle");

            foreach (DataRow r in myTable.Rows)
            {
                theme monTheme = this.undaoTheme.SelectById((int)r["idTheme"]);
                listSalles.Add(new salles((int)r["id"], (string)r["ville"], monTheme));
            }
            return listSalles;
        }

        public salles SelectByName(string salle)
        {
            DataRow r = _dbal.SelectByField("salle", "ville like '" + salle + "'").Rows[0];
            theme monTheme = this.undaoTheme.SelectById((int)r["idTheme"]);
            return new salles((int)r["id"], (string)r["ville"], monTheme);
        }

        public salles SelectById(int idSalle)
        {
            DataRow r = _dbal.SelectById("salle", idSalle);
            theme monTheme = this.undaoTheme.SelectById((int)r["idTheme"]);
            return new salles((int)r["id"], (string)r["ville"], monTheme);
        }

        public long SelectCount(string attribut, string fieldtestcondition)
        {
            long i = 0;
            DataRow uneDataRow = _dbal.SelectCount(attribut, "Salle", fieldtestcondition);
            i = (long)uneDataRow["NbSalles"];
            return i;
        }

        public List<salles> SelectAllByFieldTestCondition(string fieldtestcondition)
        {
            List<salles> listSalles = new List<salles>();
            
            DataTable myTable = this._dbal.SelectByField("salle",fieldtestcondition);

            foreach (DataRow r in myTable.Rows)
            {
                theme monTheme = this.undaoTheme.SelectById((int)r["idTheme"]);
                listSalles.Add(new salles((int)r["id"], (string)r["ville"], monTheme));
            }
            return listSalles;
        }
        #endregion
    }
}
