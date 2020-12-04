using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Model.Business;
using Model.Data;

namespace PPE3_SLAM_Axel
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        
        
        public Window1(daoReservation unDaoReservation, DAOsalles unDaoSalles)
        {
            
            InitializeComponent();
            long n = unDaoSalles.SelectCount("idSalle not in (select sum(idSalle) from Reservation where dayofweek(DateReservation) = 5 and hour(DateReservation) = '10 % ');");
            if ((string)quatre_un.Content == "4")
            {
                quatre_un.Foreground = Brushes.Yellow;
            }

        }

       
    }
}
