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
            monClient = new Clients();
            myDaoClient = new DAOclients(monDbal);

        }
    }
}
