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
            
            Dbal monDbal = new Dbal("LSRGames");
            DAOsalles unDaoSalles = new DAOsalles(monDbal);
            theme untheme = new theme(1, "Basique");
            salles uneSalle = new salles(5,"Bonneville",untheme);
            //unDaoSalles.delete(uneSalle);
            //List<salles> ListSalles = unDaoSalles.SelectAll();
            //foreach(salles s in ListSalles)
            //{
            //    Console.WriteLine(s.IdSalle);
            //}
            uneSalle = unDaoSalles.SelectById(2);
            Console.WriteLine(uneSalle.IdSalle);
            monClient = new Clients();
            myDaoClient = new DAOclients(monDbal);

        }
    }
}
