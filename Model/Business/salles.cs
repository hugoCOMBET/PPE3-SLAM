﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Business
{
    public class salle
    {
        #region Attributs
        private int _idSalle;
        private string _ville;
        private theme _LeTheme;
        #endregion

        #region Constructeurs
        public salle(int idSalle, string ville, theme idTheme)
        {
            _idSalle = idSalle;
            _ville = ville;
            _LeTheme = idTheme;
        }

        public salle()
        {
            _idSalle = -1;
            _ville = "";
            _LeTheme = new theme();
        }
        #endregion

        #region Accesseurs
        public int IdSalle { get => _idSalle; set => _idSalle = value; }
        public string Ville { get => _ville; set => _ville = value; }
        public theme LeTheme { get => _LeTheme; set => _LeTheme = value; }
        #endregion

        public override string ToString()
        {
            return this.Ville;
        }
    }
}
