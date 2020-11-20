using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Business
{
    public class salles
    {
        #region Attributs
        private int _idSalle;
        private string _ville;
        private theme _leTheme;
        #endregion

        #region Constructeurs
        public salles(int idSalle, string ville, theme leTheme)
        {
            _idSalle = idSalle;
            _ville = ville;
            _leTheme = leTheme;
        }

        public salles()
        {
            _idSalle = -1;
            _ville = "";
            _leTheme = leTheme;
        }
        #endregion

        #region Accesseurs
        public int IdSalle { get => _idSalle; set => _idSalle = value; }
        public string Ville { get => _ville; set => _ville = value; }
        public theme leTheme { get => _leTheme; set => _leTheme = value; }
        #endregion
    }
}
