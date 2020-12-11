using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Business;
using Model.Data;
namespace AppConsole
{
    public class Program
    {
        private static DAOclients myDaoClient;
        private static Clients monClient;
        static void Main(string[] args)
        {
            DateTime uneDateNaissance = new DateTime(1999, 10, 27);
            DateTime uneDateReservation = new DateTime(2020, 12, 13, 10, 0, 0);
            Clients unClient = new Clients(1, "GROUSSAUD", "Axel", "dnfjhvh", "14 rue de la paix", uneDateNaissance, "axel.groussaud@saintmichelannecy.fr", "0125489446");
            Transactions uneTransaction = new Transactions(1, unClient, 25.50);
            Dbal monDbal = new Dbal("LSRGames");
            DAOsalles unDaoSalles = new DAOsalles(monDbal);
            theme untheme = new theme(1, "Basique");
            salles uneSalle = new salles(2,"Annecy",untheme);
            Obstacle unObstacle = new Obstacle("Barrière de lumière", "une barrière avec beaucoup trop de lumière  ", "jhsdbchjdsb", "Barrière");
            daoObstacle unDaoObstacle = new daoObstacle(monDbal);
            //unDaoObstacle.Delete(unObstacle);
            //unDaoSalles.delete(uneSalle);
            //List<salles> ListSalles = unDaoSalles.SelectAll();
            //foreach(salles s in ListSalles)
            //{
            //    Console.WriteLine(s.IdSalle);
            //}
            //uneSalle = unDaoSalles.SelectById(2);
            //Console.WriteLine(uneSalle.IdSalle);
            //List<Obstacle> ListObstacle = unDaoObstacle.SelectAll();
            //foreach(Obstacle o in ListObstacle)
            //{
            //    Console.WriteLine( o.unObstacle );
            //}
           
            
            Reservation uneReservation = new Reservation(1, unClient,uneSalle,uneTransaction,uneDateReservation,5,5);
            unObstacle = unDaoObstacle.SelectByName("Barrière de force");
            Console.WriteLine(unObstacle.TypeObstacle);
            monClient = new Clients();
            myDaoClient = new DAOclients(monDbal);
            daoPositionObstacle unDaoPositionObstacle = new daoPositionObstacle(monDbal);
            PositionObstacle unePositionObstacle = new PositionObstacle(1, unObstacle, uneReservation, 6);
            //List<PositionObstacle> uneListePositionObstacle = unDaoPositionObstacle.SelectAll();
            //unDaoPositionObstacle.Delete(unePositionObstacle);
        }
    }
}
