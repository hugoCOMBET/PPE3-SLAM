using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Business;

namespace Model.Data
{
    public class daoPositionObstacle
    {
        private Dbal _DBAL;
        private daoObstacle thedaoobstacle;
        private daoReservation thedaoreservation;

        public daoPositionObstacle(Dbal unDBAL)
        {
            _DBAL = unDBAL;
            thedaoobstacle = new daoObstacle(_DBAL);
            thedaoreservation = new daoReservation(_DBAL);
        }

        public void Insert(PositionObstacle unePositionObstacle)
        {
            string query = " PositionObstacle values ('" + unePositionObstacle.IdPositionObstacle + "','" + unePositionObstacle.unObstacle.NomObstacle + "', " + unePositionObstacle.LaReservation.IdReservation + "," + unePositionObstacle.Position + ");";
            Console.WriteLine(query);
            _DBAL.Insert(query);
        }

        public void Update(PositionObstacle unePositionObstacle)
        {
            string query = "  PositionObstacle SET id = " + unePositionObstacle.IdPositionObstacle + ",nomObstacle = '" + unePositionObstacle.unObstacle.NomObstacle + "', idReservation = " + unePositionObstacle.LaReservation.IdReservation + " , positionObstacle = " + unePositionObstacle.Position + " WHERE nomObstacle = '" + unePositionObstacle.unObstacle.NomObstacle + "';";
            Console.WriteLine(query);
            _DBAL.Update(query);
        }

        public void Delete(PositionObstacle unePositionObstacle)
        {
            _DBAL.Delete(" PositionObstacle WHERE id = '" + unePositionObstacle.IdPositionObstacle + "' ;");
        }

        public List<PositionObstacle> SelectAll()
        {

            
            List<PositionObstacle> uneListePositionObstacle = new List<PositionObstacle>();
            DataTable uneDataTable = _DBAL.SelectAll("PositionObstacle");
            foreach (DataRow dtr in uneDataTable.Rows)
            {
                Reservation myreservation = this.thedaoreservation.SelectById((int)dtr["idReservation"]);
                Obstacle myObstacle = this.thedaoobstacle.SelectByName((string)dtr["nomObstacle"]);
                
                PositionObstacle unePositionObstacle = new PositionObstacle((int)dtr["id"],myObstacle,myreservation, (int)dtr["positionObstacle"]);
                uneListePositionObstacle.Add(unePositionObstacle);
            }
            return uneListePositionObstacle;
        }

        public PositionObstacle SelectById(int idPositionObstacle)
        {
            DataRow UneDataRow = _DBAL.SelectById("PositionObstacle", idPositionObstacle);
            Obstacle myObstacle = this.thedaoobstacle.SelectByName((string)UneDataRow["nomObstacle"]);
            PositionObstacle unePositionObstacle = new PositionObstacle((int)UneDataRow["idPositionObstacle"], myObstacle, (Reservation)UneDataRow["idReservation"], (int)UneDataRow["PositionObstacle"]);
            return unePositionObstacle;
        }
    }
}
