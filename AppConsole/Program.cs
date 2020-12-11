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
        private static Dbal mydbal;

        private static DAOavis myDaoAvis;
        private static avis myAvis;

        private static DAOsalles myDaoSalles;
        private static salle mySalle;

        private static DAOtheme myDaoTheme;
        private static theme myTheme;

        private static DAOclients myDaoClient;
        private static Clients myClient;

        static void Main(string[] args)
        {
            mydbal = new Dbal("LSRGames");

            myTheme = new theme(1, "Basique");
            myDaoTheme = new DAOtheme(mydbal);

            myClient = new Clients();
            myDaoClient = new DAOclients(mydbal);

            mySalle = new salle(5,"Annecyy", myTheme);
            myDaoSalles = new DAOsalles(mydbal, myDaoTheme);

            myAvis = new avis();
            myDaoAvis = new DAOavis(mydbal, myDaoClient, myDaoSalles);

            myDaoAvis.SelectAll();
            Console.WriteLine("ok");
            Console.ReadKey();
        }
    }
}
