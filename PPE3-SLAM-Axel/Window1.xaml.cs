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

        //Création d'une liste de bouton
        List<Button> uneListebouton = new List<Button>();

        public Window1(daoReservation unDaoReservation, DAOsalles unDaoSalles)
        {
            
            InitializeComponent();
            #region Ajout des boutons
            //Ajout des boutons dans la liste
            uneListebouton.Add(un_un);
            uneListebouton.Add(un_deux);
            uneListebouton.Add(un_trois);
            uneListebouton.Add(un_quatre);
            uneListebouton.Add(un_cinq);
            uneListebouton.Add(un_six);
            uneListebouton.Add(un_sept);
            uneListebouton.Add(un_huit);
            uneListebouton.Add(un_neuf);
            uneListebouton.Add(un_dix);
            uneListebouton.Add(un_onze);
            uneListebouton.Add(un_douze);
            uneListebouton.Add(deux_un);
            uneListebouton.Add(deux_deux);
            uneListebouton.Add(deux_trois);
            uneListebouton.Add(deux_quatre);
            uneListebouton.Add(deux_cinq);
            uneListebouton.Add(deux_six);
            uneListebouton.Add(deux_sept);
            uneListebouton.Add(deux_huit);
            uneListebouton.Add(deux_neuf);
            uneListebouton.Add(deux_dix);
            uneListebouton.Add(deux_onze);
            uneListebouton.Add(deux_douze);
            uneListebouton.Add(trois_un);
            uneListebouton.Add(trois_deux);
            uneListebouton.Add(trois_trois);
            uneListebouton.Add(trois_quatre);
            uneListebouton.Add(trois_cinq);
            uneListebouton.Add(trois_six);
            uneListebouton.Add(trois_sept);
            uneListebouton.Add(trois_huit);
            uneListebouton.Add(trois_neuf);
            uneListebouton.Add(trois_dix);
            uneListebouton.Add(trois_onze);
            uneListebouton.Add(trois_douze);
            uneListebouton.Add(quatre_un);
            uneListebouton.Add(quatre_deux);
            uneListebouton.Add(quatre_trois);
            uneListebouton.Add(quatre_quatre);
            uneListebouton.Add(quatre_cinq);
            uneListebouton.Add(quatre_six);
            uneListebouton.Add(quatre_sept);
            uneListebouton.Add(quatre_huit);
            uneListebouton.Add(quatre_neuf);
            uneListebouton.Add(quatre_dix);
            uneListebouton.Add(quatre_onze);
            uneListebouton.Add(quatre_douze);
            uneListebouton.Add(cinq_un);
            uneListebouton.Add(cinq_deux);
            uneListebouton.Add(cinq_trois);
            uneListebouton.Add(cinq_quatre);
            uneListebouton.Add(cinq_cinq);
            uneListebouton.Add(cinq_six);
            uneListebouton.Add(cinq_sept);
            uneListebouton.Add(cinq_huit);
            uneListebouton.Add(cinq_neuf);
            uneListebouton.Add(cinq_dix);
            uneListebouton.Add(cinq_onze);
            uneListebouton.Add(cinq_douze);
            uneListebouton.Add(six_un);
            uneListebouton.Add(six_deux);
            uneListebouton.Add(six_trois);
            uneListebouton.Add(six_quatre);
            uneListebouton.Add(six_cinq);
            uneListebouton.Add(six_six);
            uneListebouton.Add(six_sept);
            uneListebouton.Add(six_huit);
            uneListebouton.Add(six_neuf);
            uneListebouton.Add(six_dix);
            uneListebouton.Add(six_onze);
            uneListebouton.Add(six_douze);
            uneListebouton.Add(sept_un);
            uneListebouton.Add(sept_deux);
            uneListebouton.Add(sept_trois);
            uneListebouton.Add(sept_quatre);
            uneListebouton.Add(sept_cinq);
            uneListebouton.Add(sept_six);
            uneListebouton.Add(sept_sept);
            uneListebouton.Add(sept_huit);
            uneListebouton.Add(sept_neuf);
            uneListebouton.Add(sept_dix);
            uneListebouton.Add(sept_onze);
            uneListebouton.Add(sept_douze); 
            #endregion
            long n = unDaoSalles.SelectCount("idSalle","idSalle not in (select sum(idSalle) from Reservation where dayofweek(DateReservation) = 5 and hour(DateReservation) = '10 % ');");
            quatre_un.Content = Convert.ToString(n);
            if ((string)quatre_un.Content == "3")
            {
                quatre_un.Background = Brushes.Yellow;
                quatre_un.Foreground = Brushes.Black;
            }

        }

        public static void InitialiserFenêtre(List<Button> uneListedeBouton)
        {
            //premier chiffre = colonne = jour , deuxième chiffre = ligne = heure
            string extraction;
            int position;
            foreach(Button btn in uneListedeBouton)
            {
                position = btn.Content.ToString().IndexOf('_');
                extraction = btn.Content.ToString().Substring(0, 2);
                switch(extraction)
                {
                    case "un":
                        extraction = btn.Content.ToString().Substring(position+1);
                        switch(extraction)
                        {
                            default:

                                break;
                        }
                        break;

                    default:

                        break;
                }
            }

        }
    }

    
}
