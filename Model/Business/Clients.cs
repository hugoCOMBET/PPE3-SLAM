using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Business
{
    class Clients
    {
        #region attribut privé
        private int _idClient;
        private string _nomClient;
        private string _prenomClient;
        private string _photoClient;
        private string _adresseClient;
        private DateTime _dateNaissClient;
        private string _emailClient;
        private string _telPortableCLient;
        #endregion

        #region constructeurs
        public Clients(int UnIdClient, string UnClient, string UnPrenomClient, string UnePhotoClient, string UneAdresseClient, DateTime UneDateNaissClient, string unEmailClient, string unNumTelephoneClient)
        {
            _idClient = UnIdClient;
            _nomClient = UnClient;
            _prenomClient = UnPrenomClient;
            _photoClient = UnePhotoClient;
            _adresseClient = UneAdresseClient;
            _dateNaissClient = UneDateNaissClient;
            _emailClient = unEmailClient;
            _telPortableCLient = unNumTelephoneClient;
        }

        public Clients()
        {
            _idClient = 0;
            _nomClient = "";
            _prenomClient = "";
            _photoClient = "";
            _adresseClient = "";
            _dateNaissClient = new DateTime();
            _emailClient = "";
            _telPortableCLient = "";
        }
        #endregion

        #region getteurs/setteurs
        public int getIdClient()
        {
            return _idClient;
        }
        public void setIdClient(int unIdClient)
        {
            _idClient = unIdClient;
        }
        public string getNomClient()
        {
            return _nomClient;
        }
        public void setNomClient(string unNomClient)
        {
            _nomClient = unNomClient;
        }

        public string getPrenomClient()
        {
            return _prenomClient;
        }
        public void setPrenomClient(string unPrenomClient)
        {
            _prenomClient = unPrenomClient;
        }

        public string getPhotoClient()
        {
            return _photoClient;
        }
        public void setPhotoClient(string unePhotoClient)
        {
            _photoClient = unePhotoClient;
        }

        public string getAdresseClient()
        {
            return _adresseClient;
        }
        public void setAdresseClient(string uneAdresseClient)
        {
            _adresseClient = uneAdresseClient;
        }

        public DateTime getDateNaissanceClient()
        {
            return _dateNaissClient;
        }
        public void setDateNaissanceClient(DateTime uneDateNaissClient)
        {
            _dateNaissClient = uneDateNaissClient;
        }

        public string getEmailClient()
        {
            return _emailClient;
        }
        public void setEmailClient(string unEmailClient)
        {
            _emailClient = unEmailClient;
        }

        public string getTelPortableCLient()
        {
            return _telPortableCLient;
        }
        public void setTelPortableCLient(string unTelPortableClient)
        {
            _telPortableCLient = unTelPortableClient;
        }
        #endregion
    }
}
