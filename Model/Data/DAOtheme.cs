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
    public class DAOtheme
    {
        #region Attributs
        private Dbal _dbal;
        #endregion

        #region contructeurs
        public DAOtheme(Dbal dbal)
        {
            _dbal = dbal;
        }
        #endregion

        #region Autres méthodes
        public void insert(theme untheme)
        {
            string ThemeInsert;

            ThemeInsert = ("Themes (id, theme) values (" + untheme.IdTheme + ",'" + untheme.Theme.Replace("'", "''") + "');");
            _dbal.Insert(ThemeInsert);
        }

        public void delete(theme untheme)
        {
            string ThemeDelete;

            ThemeDelete = ("Themes where id =" + untheme.IdTheme + ";");
            _dbal.Delete(ThemeDelete);
        }

        public void update(theme untheme)
        {
            string ThemeUpdate;

            ThemeUpdate = ("themes set id = '" + untheme.IdTheme + "', theme = '" + untheme.Theme.Replace("'", "''") + "' WHERE id = '" + untheme.IdTheme + "';");
            _dbal.Update(ThemeUpdate);
        }

        public List<theme> SelectAll()
        {
            List<theme> listFromage = new List<theme>();
            foreach (DataRow r in _dbal.SelectAll("Themes").Rows)
            {
                listFromage.Add(new theme((int)r["id"], (string)r["theme"]));
            }
            return listFromage;
        }

        public theme SelectByName(string theme)
        {
            DataRow r = _dbal.SelectByField("Themes", "theme like '" + theme + "'").Rows[0];
            return new theme((int)r["id"], (string)r["theme"]);
        }

        public theme SelectById(int idTheme)
        {
            DataRow r = _dbal.SelectById("Themes", idTheme);
            return new theme((int)r["id"], (string)r["theme"]);
        }
        #endregion
    }
}
