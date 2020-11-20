using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Business;

namespace Model.Business
{
    public class Reservation
    {
        private int _idReservation;
        private Clients _monClient;
        private Salle _idSalle;
        private int _idTransaction;
        private DateTime _dateReservation;
        private int _nbJoueurs;
        private int _nbObstacles;

        public Reservation()
        {
            _idReservation = 0;
            _monClient = new Clients();
            _idSalle = 0;
            _idTransaction = 0;
            _dateReservation = new DateTime();
            _nbJoueurs = 0;
            _nbObstacles = 0;
        }

        public Reservation (int unIdReservation, Clients unIdClient, int unIdSalle, int unIdTransaction, DateTime uneDateReservation,int unNbJoueurs, int unNbObstacle)
        {
            _idReservation = unIdReservation;
            _monClient = unIdClient;
            _idSalle = unIdSalle;
            _idTransaction = unIdTransaction;
            _dateReservation = uneDateReservation;
            _nbJoueurs = unNbJoueurs;
            _nbObstacles = unNbObstacle;
        }

        public int IdReservation { get => _idReservation; set => _idReservation = value; }

        public Clients MonClient { get => _monClient; set => _monClient = value; }

        public int IdSalle { get => _idSalle; set => _idSalle = value; }

        public int IdTransaction { get => _idTransaction; set => _idTransaction = value; }

        public DateTime DateReservation { get => _dateReservation; set => _dateReservation = value; }
        public int NbJoueurs { get => _nbJoueurs; set => _nbJoueurs = value; }

        public int NbObstacle { get => _nbObstacles; set => _nbObstacles = value; }
    }
}
