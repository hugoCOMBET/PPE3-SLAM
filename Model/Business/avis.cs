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
        private Clients _leClient;
        private salles _laSalle;
        private string _avis;
        #endregion

        #region Constructeurs
        public avis(int idAvis, Clients leClient, salles laSalle, string avis)
        {
            _idAvis = idAvis;
            _leClient = leClient;
            _laSalle = laSalle;
            _avis = avis;
        }

        public avis()
        {
            _idAvis = -1;
            _leClient = leClient;
            _laSalle = laSalle;
            _avis = "";
        }
        #endregion

        #region Accesseurs
        public int IdAvis { get => _idAvis; set => _idAvis = value; }
        public Clients leClient { get => _leClient; set => _leClient = value; }
        public salles laSalle { get => _laSalle; set => _laSalle = value; }
        public string Avis { get => _avis; set => _avis = value; }
        #endregion
    }
}
