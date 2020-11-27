using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Business
{
    public class avis
    {
        #region Attributs
        private int _idAvis;
        private Clients _idClient;
        private salles _idSalle;
        private string _avis;
        #endregion

        #region Constructeurs

        public avis(int idAvis, Clients idClient, salles idSalle, string avis)
        {
            _idAvis = idAvis;
            _leClient = leClient;
            _laSalle = laSalle;
            _avis = avis;
        }

        public avis()
        {
            _idAvis = -1;
            _idClient = new Clients();
            _idSalle = new salles();
            _avis = "";
        }
        #endregion

        #region Accesseurs
        public int IdAvis { get => _idAvis; set => _idAvis = value; }
        public Clients IdClient { get => _idClient; set => _idClient = value; }
        public salles IdSalle { get => _idSalle; set => _idSalle = value; }
        public string Avis { get => _avis; set => _avis = value; }
        #endregion
    }
}
