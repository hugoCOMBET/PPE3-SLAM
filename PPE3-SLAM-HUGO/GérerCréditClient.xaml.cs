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

namespace PPE3_SLAM_HUGO
{
    /// <summary>
    /// Logique d'interaction pour GérerCréditClient.xaml
    /// </summary>
    public partial class GérerCréditClient : Window
    {
        public GérerCréditClient()
        {
            InitializeComponent();
        }

        private void btn_afficherTrans_Click(object sender, RoutedEventArgs e)
        {
            FenetreTransactions Transaction = new FenetreTransactions();
            Transaction.Show();
            this.Close();
        }

        private void btn_gérerClient_Click(object sender, RoutedEventArgs e)
        {
            GérerClients gererClient = new GérerClients();
            gererClient.Show();
            this.Close();
        }
    }
}
