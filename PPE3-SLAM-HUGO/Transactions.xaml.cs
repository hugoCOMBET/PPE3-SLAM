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

namespace PPE3_SLAM_HUGO
{
    /// <summary>
    /// Logique d'interaction pour Transactions.xaml
    /// </summary>
    public partial class FenetreTransactions : Window
    {
        public FenetreTransactions()
        {
            InitializeComponent();
        }

        private void btn_GérerlesCrédits_Click(object sender, RoutedEventArgs e)
        {
            GérerCréditClient gererCreditClient = new GérerCréditClient();
            gererCreditClient.Show();
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
