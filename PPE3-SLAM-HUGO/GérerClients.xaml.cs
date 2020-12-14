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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PPE3_SLAM_HUGO
{
    /// <summary>
    /// Logique d'interaction pour GérerClients.xaml
    /// </summary>
    public partial class GérerClients : Window
    {
        public GérerClients()
        {
            InitializeComponent();
            mainGrid.DataContext = new viewModel.viewModelFromage(thedaopays, thedaofromage);
        }

        private void btn_gérerClient_Click(object sender, RoutedEventArgs e)
        {
            GérerCréditClient gererCreditClient = new GérerCréditClient();
            gererCreditClient.Show();
            this.Close();
        }

        private void btn_afficherTrans_Click(object sender, RoutedEventArgs e)
        {
            FenetreTransactions Transaction = new FenetreTransactions();
            Transaction.Show();
            this.Close();
        }
    }
}
