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
        private salle _laSalle;
        private string _avis;
        private int _note;
        #endregion

        #region Constructeurs

        public avis(int idAvis, Clients leClient, salle laSalle, string avis, int note)
        {
            _idAvis = idAvis;
            _leClient = leClient;
            _laSalle = laSalle;
            _avis = avis;
            _note = note;
        }

        public avis()
        {
            _idAvis = -1;
            _leClient = new Clients();
            _laSalle = new salle();
            _avis = "";
            _note = -1;
        }
        #endregion

        #region Accesseurs
        public int IdAvis { get => _idAvis; set => _idAvis = value; }
        public Clients LeClient { get => _leClient; set => _leClient = value; }
        public salle IdSalle { get => _laSalle; set => _laSalle = value; }
        public string Avis { get => _avis; set => _avis = value; }
        public int Note { get => _note; set => _note = value; }
        #endregion
    }
}
