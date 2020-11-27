using Model.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PPE3_SLAM_Thalia
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Dbal thedbal;
        private DAOtheme thedaotheme;
        private DAOavis thedaoavis;
        private DAOsalles thedaosalles;
        private DAOclients thedaoclient;
        private daoReservation thedaoreservation;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //C'est ici, dans la méthode Application_Startup, qu'on instancie nos objets Dbal et Dao
            thedbal = new Dbal("LSRGames");
            thedaotheme = new DAOtheme(thedbal);
            thedaoavis = new DAOavis(thedbal, thedaoclient, thedaosalles);
            thedaosalles = new DAOsalles(thedbal);
            thedaoclient = new DAOclients(thedbal);
            thedaoreservation = new daoReservation(thedbal);

            // Create the startup window
            //là, on lance la fenêtre souhaitée en instanciant la classe de notre fenêtre
            MainWindow wnd = new MainWindow();
            //et on utilise la méthode Show() de notre objet fenêtre pour afficher la fenêtre
            //exemple: MainWindow lafenetre = new MainWindow(); (et on y passe en paramètre Dbal et Dao au besoin)
            wnd.Show();

            //Méthode permettant d'afficher les exceptions non gérées (voir wpftutorial.com)
            //private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
            //{
            //    MessageBox.Show("An unhandled exception just occurred: " + e.Exception.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            //    e.Handled = true;
            //}
        }
    }
}
