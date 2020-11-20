using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Business
{
    public class PositionObstacle
    {
        private int _idPositionObstacle;
        private Obstacle _monObstacle;
        private int _idReservation;
        private int _positionObstacle;

        public PositionObstacle()
        {
            _idPositionObstacle = 0;
            _monObstacle = new Obstacle();
            _idReservation = 0;
            _positionObstacle = 0;
        }

        public PositionObstacle(int unIdPositionObstacle , Obstacle unNomObstacle, int unIdReservation, int unePositionObstacle)
        {
            _idPositionObstacle = unIdPositionObstacle;
            _monObstacle = unNomObstacle;
            _idReservation = unIdReservation;
            _positionObstacle = unePositionObstacle;
        }

        public int IdPositionObstacle { get => _idPositionObstacle; set => _idPositionObstacle = value; }
        public Obstacle MonObstacle { get => _monObstacle; set => _monObstacle = value; }

        public int IdReservation { get => _idReservation; set => _idReservation = value; }

        public int unePositionObstacle { get => _positionObstacle; set => _positionObstacle = value; }
    }
}
