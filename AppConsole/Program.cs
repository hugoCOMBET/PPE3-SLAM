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
        public static DateTime[] RetourneSemaine(DateTime uneDate)
        {
            DateTime[] Semaine = new DateTime[7];
            DayOfWeek jourSemaine = uneDate.DayOfWeek;
            switch (jourSemaine)
            {
                case DayOfWeek.Monday:
                    Semaine[0] = uneDate;
                    Semaine[1] = uneDate.AddDays(1);
                    Semaine[2] = uneDate.AddDays(2);
                    Semaine[3] = uneDate.AddDays(3);
                    Semaine[4] = uneDate.AddDays(4);
                    Semaine[5] = uneDate.AddDays(5);
                    Semaine[6] = uneDate.AddDays(6);
                    break;

                case DayOfWeek.Tuesday:
                    Semaine[0] = uneDate.AddDays(-1);
                    Semaine[1] = uneDate;
                    Semaine[2] = uneDate.AddDays(1);
                    Semaine[3] = uneDate.AddDays(2);
                    Semaine[4] = uneDate.AddDays(3);
                    Semaine[5] = uneDate.AddDays(4);
                    Semaine[6] = uneDate.AddDays(5);
                    break;

                case DayOfWeek.Wednesday:
                    Semaine[0] = uneDate.AddDays(-2);
                    Semaine[1] = uneDate.AddDays(-1);
                    Semaine[2] = uneDate;
                    Semaine[3] = uneDate.AddDays(3);
                    Semaine[4] = uneDate.AddDays(4);
                    Semaine[5] = uneDate.AddDays(5);
                    Semaine[6] = uneDate.AddDays(6);
                    break;

                case DayOfWeek.Thursday:
                    Semaine[0] = uneDate.AddDays(-3);
                    Semaine[1] = uneDate.AddDays(-2);
                    Semaine[2] = uneDate.AddDays(-1);
                    Semaine[3] = uneDate;
                    Semaine[4] = uneDate.AddDays(1);
                    Semaine[5] = uneDate.AddDays(2);
                    Semaine[6] = uneDate.AddDays(3);
                    break;

                case DayOfWeek.Friday:
                    Semaine[0] = uneDate.AddDays(-4);
                    Semaine[1] = uneDate.AddDays(-3);
                    Semaine[2] = uneDate.AddDays(-2);
                    Semaine[3] = uneDate.AddDays(-1);
                    Semaine[4] = uneDate;
                    Semaine[5] = uneDate.AddDays(1);
                    Semaine[6] = uneDate.AddDays(2);
                    break;

                case DayOfWeek.Saturday:
                    Semaine[0] = uneDate.AddDays(-5);
                    Semaine[1] = uneDate.AddDays(-4);
                    Semaine[2] = uneDate.AddDays(-3);
                    Semaine[3] = uneDate.AddDays(-2);
                    Semaine[4] = uneDate.AddDays(-1);
                    Semaine[5] = uneDate;
                    Semaine[6] = uneDate.AddDays(1);
                    break;

                case DayOfWeek.Sunday:
                    Semaine[0] = uneDate.AddDays(-6);
                    Semaine[1] = uneDate.AddDays(-5);
                    Semaine[2] = uneDate.AddDays(-4);
                    Semaine[3] = uneDate.AddDays(-3);
                    Semaine[4] = uneDate.AddDays(-2);
                    Semaine[5] = uneDate.AddDays(-1);
                    Semaine[6] = uneDate;
                    break;

                default:
                    break;
            }
            return Semaine;
        }
        private static DAOclients myDaoClient;
        private static Clients monClient;
        static void Main(string[] args)
        {
            Dbal monDbal = new Dbal("LSRGames");
            myDaoClient = new DAOclients(monDbal);
            DAOtransactions dAOtransactions = new DAOtransactions(monDbal, myDaoClient);
            DateTime uneDateNaissance = new DateTime(1999, 10, 27);
            DateTime uneDateReservation = new DateTime(2020, 12, 13, 10, 0, 0);
            Clients unClient = new Clients(1, "GROUSSAUD", "Axel", "dnfjhvh", "14 rue de la paix", uneDateNaissance, "axel.groussaud@saintmichelannecy.fr", "0125489446",12.5);
            Transactions uneTransaction = new Transactions(5, unClient, 25.50);
            dAOtransactions.Insert(uneTransaction);
            //uneTransaction = dAOtransactions.SelectById(1);
            //Console.WriteLine(uneTransaction.getIdTransactions());
            //DAOsalles unDaoSalles = new DAOsalles(monDbal);
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
            DateTime test = new DateTime(2020, 12, 25);
            daoReservation unDaoReservation = new daoReservation(monDbal);
            Reservation uneReservation = new Reservation(5, unClient,uneSalle,uneTransaction,test,3,5);
            //unDaoReservation.Delete(uneReservation);
            //Console.WriteLine(unDaoReservation.SelectById(2).NbObstacles);
            //List<Reservation> listReservation = unDaoReservation.SelectAll();
            //foreach(Reservation r in listReservation)
            //{
            //    Console.WriteLine(r.IdReservation);
            //}
            //unObstacle = unDaoObstacle.SelectByName("Barrière de force");
            //Console.WriteLine(unObstacle.TypeObstacle);
            //monClient = new Clients();
            //myDaoClient = new DAOclients(monDbal);
            //daoPositionObstacle unDaoPositionObstacle = new daoPositionObstacle(monDbal);
            //PositionObstacle unePositionObstacle = new PositionObstacle(1, unObstacle, uneReservation, 6);
            //List<PositionObstacle> uneListePositionObstacle = unDaoPositionObstacle.SelectAll();
            //foreach(PositionObstacle po in uneListePositionObstacle)
            //{
             //   Console.WriteLine(po.unObstacle.NomObstacle);
            //}
            //unDaoPositionObstacle.Delete(unePositionObstacle);
            //DateTime selectedate = new DateTime(2020,5,27);
            //DayOfWeek jour = selectedate.DayOfWeek;
            //Console.WriteLine(jour);
            //DateTime[] unTabDate = RetourneSemaine(selectedate);
            //foreach(DateTime d in unTabDate)
            //{
            //    Console.WriteLine(d.Day);
            //}

        }
    }
}
