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
using Model.Data;

namespace PPE3_SLAM_HUGO
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow( DAOtransactions laTransaction,DAOclients lesClient)
        {
            InitializeComponent();
            AppComptableSecretariat.DataContext = new viewModel.viewModelPPE3Hugo(laTransaction, lesClient);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Rbtn_AffichageTransactions.IsChecked == true)
            {
                FenetreTransactions Transaction = new FenetreTransactions();
                Transaction.Show();
                this.Close();
            }
            if (Rbtn_gérerClient.IsChecked == true)
            {
                GérerClients gererClient = new GérerClients();
                gererClient.Show();
                this.Close();
            }
            if (Rbtn_GérerCrédit.IsChecked == true)
            {
                GérerCréditClient gererCreditClient = new GérerCréditClient();
                gererCreditClient.Show();
                this.Close();
            }


        }
    }
}
