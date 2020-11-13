using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Business
{
    class Utilisateurs
    {
        #region attribut privé
        private string _login;
        private string _motDePasse;
        #endregion

        #region constructeur
        public Utilisateurs(string LeLogin, string LeMotDePasse)
        {
            _login = LeLogin;
            _motDePasse = LeMotDePasse;
        }
        #endregion

        #region getteurs/setteurs
        public string getLogin()
        {
            return _login;
        }
        public void setLogin(string unLogin)
        {
            _login = unLogin;
        }
        public string getMotDePasse()
        {
            return _motDePasse;
        }
        public void setMotDePasse(string unMotDePasse)
        {
            _motDePasse = unMotDePasse;
        }
        #endregion
    }
}
