using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Business
{
    public class Clients
    {
        #region attribut privé
        private int _id;
        private string _nom;
        private string _prenom;
        private string _photo;
        private string _adresse;
        private DateTime _DateNaissance;
        private string _Email;
        private string _TelephonePortable;
        private double _credit;
        #endregion

        #region constructeurs
        public Clients(int UnIdClient, string UnClient, string UnPrenomClient, string UnePhotoClient, string UneAdresseClient, DateTime UneDateNaissClient, string unEmailClient, string unNumTelephoneClient,double uncredit)
        {
            _id = UnIdClient;
            _nom = UnClient;
            _prenom = UnPrenomClient;
            _photo = UnePhotoClient;
            _adresse = UneAdresseClient;
            _DateNaissance = UneDateNaissClient;
            _Email = unEmailClient;
            _TelephonePortable = unNumTelephoneClient;
            _credit = uncredit;
        }

        public Clients()
        {
            _id = 0;
            _nom = "";
            _prenom = "";
            _photo = "";
            _adresse = "";
            _DateNaissance = new DateTime();
            _Email = "";
            _TelephonePortable = "";
            _credit = 0;
        }
        #endregion

        #region getteurs/setteurs
        public int IdClient { get => _id; set => _id = value; }
        public string NomClient { get => _nom; set => _nom = value; }

        public string PrenomClient { get => _prenom; set => _prenom = value; }

        public string getPhotoClient()
        {
            return _photo;
        }
        public void setPhotoClient(string unePhotoClient)
        {
            _photo = unePhotoClient;
        }

        public string AdresseClient { get => _adresse; set => _adresse = value; }

        public DateTime DateNaissanceClient { get => _DateNaissance; set => _DateNaissance = value; }

        public string EmailClient { get => _Email; set => _Email = value; }

        public string TelPortableCLient { get => _TelephonePortable; set => _TelephonePortable = value; }

        public double CreditCLient { get => _credit; set => _credit = value; }
        #endregion

        public override string ToString()
        {
            return this.NomClient + " "+this.PrenomClient;
        }
    }
}
