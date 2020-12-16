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
        
        private List<Button> uneListebouton = new List<Button>();
        private DateTime DateJour = new DateTime();
        private DAOtheme thedaotheme;
        private DAOsalles thedaosalles;
        private Dbal thedbal;


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
            thedbal = new Dbal("LSRGames");
            thedaotheme = new DAOtheme(thedbal);
            thedaosalles = new DAOsalles(thedbal, thedaotheme);
            lbl_datejour.Content = lbl_datejour.Content + Convert.ToString(dpk_datejour.SelectedDate);
            DateJour = DateTime.Now;
            
            dpk_datejour.SelectedDate = DateJour;
            lbl_datejour.Content = lbl_datejour.Content + DateJour.ToString("f");
            InitialiserFenêtre(uneListebouton, unDaoSalles,(DateTime)dpk_datejour.SelectedDate);

        }

        public static void InitialiserFenêtre(List<Button> uneListedeBouton, DAOsalles unDaoSalles,DateTime uneDate)
        {
            //premier chiffre = colonne = jour , deuxième chiffre = ligne = heure
            string extraction;
            int position;
            string debutRequete ;
            DateTime[] uneListeDate = RetourneSemaine(uneDate);
            foreach (Button btn in uneListedeBouton)
            {
                
                position = btn.Name.ToString().IndexOf('_');
                extraction = btn.Name.ToString().Substring(0, position);

                switch (extraction)
                {
                    case "un":
                        // btn.Content = position.ToString();
                        debutRequete = "id not in (select count(id) from Reservation where dayofmonth(DateReservation)= "+uneListeDate[0].Day+" and month(DateReservation) = "+uneListeDate[0].Month+" and year(DateReservation) = "+uneListeDate[0].Year ;
                        RequeteSQLCount(btn, unDaoSalles, debutRequete);
                        break;

                    case "deux":
                        //btn.Content = position.ToString();
                        debutRequete = "id not in (select count(id) from Reservation where dayofmonth(DateReservation)= " + uneListeDate[1].Day + " and month(DateReservation) = " + uneListeDate[1].Month + " and year(DateReservation) = " + uneListeDate[1].Year;
                        RequeteSQLCount(btn, unDaoSalles, debutRequete);
                        break;

                    case "trois":
                        debutRequete = "id not in (select count(id) from Reservation where dayofmonth(DateReservation)= " + uneListeDate[2].Day + " and month(DateReservation) = " + uneListeDate[2].Month + " and year(DateReservation) = " + uneListeDate[3].Year;
                        //btn.Content = position.ToString();
                        RequeteSQLCount(btn, unDaoSalles, debutRequete);
                        break;

                    case "quatre":
                        debutRequete = "id not in (select count(id) from Reservation where dayofmonth(DateReservation)= " + uneListeDate[3].Day + " and month(DateReservation) = " + uneListeDate[3].Month + " and year(DateReservation) = " + uneListeDate[3].Year;
                        //btn.Content = position.ToString();
                        RequeteSQLCount(btn, unDaoSalles, debutRequete);
                        break;

                    case "cinq":
                        //btn.Content = position.ToString();
                        debutRequete = "id not in (select count(id) from Reservation where dayofmonth(DateReservation)= " + uneListeDate[4].Day + " and month(DateReservation) = " + uneListeDate[4].Month + " and year(DateReservation) = " + uneListeDate[4].Year;
                        RequeteSQLCount(btn, unDaoSalles, debutRequete);
                        break;

                    case "six":
                        debutRequete = "id not in (select count(id) from Reservation where dayofmonth(DateReservation)= " + uneListeDate[5].Day + " and month(DateReservation) = " + uneListeDate[5].Month + " and year(DateReservation) = " + uneListeDate[5].Year;
                        //btn.Content = position.ToString();
                        RequeteSQLCount(btn, unDaoSalles, debutRequete);
                        break;

                    case "sept":
                        //btn.Content = position.ToString();
                        debutRequete = "id not in (select count(id) from Reservation where dayofmonth(DateReservation)= " + uneListeDate[6].Day + " and month(DateReservation) = " + uneListeDate[6].Month + " and year(DateReservation) = " + uneListeDate[6].Year;
                        RequeteSQLCount(btn, unDaoSalles, debutRequete);
                        break;

                    default:

                        break;
                }
            }

        }

        public static void ChangerEtat(Button unBouton)
        {
            if ((string)unBouton.Content == "0")
            {
                unBouton.IsEnabled = false;
            }
            if ((string)unBouton.Content == "1")
            {
                unBouton.Background = Brushes.Red;
                unBouton.Foreground = Brushes.White;
            }
            if ((string)unBouton.Content == "2")
            {
                unBouton.Background = Brushes.Orange;
                unBouton.Foreground = Brushes.White;
            }
            if ((string)unBouton.Content == "3")
            {
                unBouton.Background = Brushes.Yellow;
                unBouton.Foreground = Brushes.Black;
            }
            if ((string)unBouton.Content == "4")
            {
                unBouton.Background = Brushes.Green;
                unBouton.Foreground = Brushes.White;
            }

        }

        public static void RequeteSQLCount(Button unBouton, DAOsalles unDaoSalles, string debRequete)
        {
            long n = 0;
            int position = 0;
            string extraction = "";

            position = unBouton.Name.ToString().IndexOf('_');
            extraction = unBouton.Name.ToString().Substring(position + 1);
            switch (extraction)
            {
                case "un":
                    n = unDaoSalles.SelectCount("id", debRequete + " and hour(DateReservation) = '10%');");
                    unBouton.Content = Convert.ToString(n);
                    ChangerEtat(unBouton);
                    break;

                case "deux":
                    n = unDaoSalles.SelectCount("id", debRequete + " and hour(DateReservation) = '11%');");
                    unBouton.Content = Convert.ToString(n);
                    ChangerEtat(unBouton);
                    break;

                case "trois":
                    n = unDaoSalles.SelectCount("id", debRequete + " and hour(DateReservation) = '12%');");
                    unBouton.Content = Convert.ToString(n);
                    ChangerEtat(unBouton);
                    break;

                case "quatre":
                    n = unDaoSalles.SelectCount("id", debRequete + " and hour(DateReservation) = '13%');");
                    unBouton.Content = Convert.ToString(n);
                    ChangerEtat(unBouton);
                    break;

                case "cinq":
                    n = unDaoSalles.SelectCount("id", debRequete + " and hour(DateReservation) = '14%');");
                    unBouton.Content = Convert.ToString(n);
                    ChangerEtat(unBouton);
                    break;

                case "six":
                    n = unDaoSalles.SelectCount("id", debRequete + " and hour(DateReservation) = '15%');");
                    unBouton.Content = Convert.ToString(n);
                    ChangerEtat(unBouton);
                    break;

                case "sept":
                    n = unDaoSalles.SelectCount("id", debRequete + " and hour(DateReservation) = '16%');");
                    unBouton.Content = Convert.ToString(n);
                    ChangerEtat(unBouton);
                    break;
                case "huit":
                    n = unDaoSalles.SelectCount("id", debRequete + " and hour(DateReservation) = '17%');");
                    unBouton.Content = Convert.ToString(n);
                    ChangerEtat(unBouton);
                    break;

                case "neuf":
                    n = unDaoSalles.SelectCount("id", debRequete + " and hour(DateReservation) = '18%');");
                    unBouton.Content = Convert.ToString(n);
                    ChangerEtat(unBouton);
                    break;

                case "dix":
                    n = unDaoSalles.SelectCount("id", debRequete + " and hour(DateReservation) = '19%');");
                    unBouton.Content = Convert.ToString(n);
                    ChangerEtat(unBouton);
                    break;

                case "onze":
                    n = unDaoSalles.SelectCount("id", debRequete + " and hour(DateReservation) = '20%');");
                    unBouton.Content = Convert.ToString(n);
                    ChangerEtat(unBouton);
                    break;

                case "douze":
                    n = unDaoSalles.SelectCount("id", debRequete + " and hour(DateReservation) = '21%');");
                    unBouton.Content = Convert.ToString(n);
                    ChangerEtat(unBouton);
                    break;

                default:

                    break;
            }


        }


         
        public static DateTime[] RetourneSemaine(DateTime uneDate)
        {
            DateTime[] Semaine = new DateTime[7];
            DayOfWeek jourSemaine = uneDate.DayOfWeek;
            switch(jourSemaine)
            {
                case DayOfWeek.Monday:
                    Semaine[0] = uneDate;
                    Semaine[1] = uneDate.AddDays(1);
                    Semaine[2] = uneDate.AddDays(2);
                    Semaine[3] = uneDate.AddDays(3);
                    Semaine[4] = uneDate.AddDays(4);
                    Semaine[5] = uneDate.AddDays(5);
                    Semaine[6] = uneDate.AddDays(6);
                    break;

                case DayOfWeek.Tuesday:
                    Semaine[0] = uneDate.AddDays(-1);
                    Semaine[1] = uneDate;
                    Semaine[2] = uneDate.AddDays(1);
                    Semaine[3] = uneDate.AddDays(2);
                    Semaine[4] = uneDate.AddDays(3);
                    Semaine[5] = uneDate.AddDays(4);
                    Semaine[6] = uneDate.AddDays(5);
                    break;

                case DayOfWeek.Wednesday:
                    Semaine[0] = uneDate.AddDays(-2);
                    Semaine[1] = uneDate.AddDays(-1);
                    Semaine[2] = uneDate;
                    Semaine[3] = uneDate.AddDays(1);
                    Semaine[4] = uneDate.AddDays(2);
                    Semaine[5] = uneDate.AddDays(3);
                    Semaine[6] = uneDate.AddDays(4);
                    break;

                case DayOfWeek.Thursday:
                    Semaine[0] = uneDate.AddDays(-3);
                    Semaine[1] = uneDate.AddDays(-2);
                    Semaine[2] = uneDate.AddDays(-1);
                    Semaine[3] = uneDate;
                    Semaine[4] = uneDate.AddDays(1);
                    Semaine[5] = uneDate.AddDays(2);
                    Semaine[6] = uneDate.AddDays(3);
                    break;

                case DayOfWeek.Friday:
                    Semaine[0] = uneDate.AddDays(-4);
                    Semaine[1] = uneDate.AddDays(-3);
                    Semaine[2] = uneDate.AddDays(-2);
                    Semaine[3] = uneDate.AddDays(-1);
                    Semaine[4] = uneDate;
                    Semaine[5] = uneDate.AddDays(1);
                    Semaine[6] = uneDate.AddDays(2);
                    break;

                case DayOfWeek.Saturday:
                    Semaine[0] = uneDate.AddDays(-5);
                    Semaine[1] = uneDate.AddDays(-4);
                    Semaine[2] = uneDate.AddDays(-3);
                    Semaine[3] = uneDate.AddDays(-2);
                    Semaine[4] = uneDate.AddDays(-1);
                    Semaine[5] = uneDate;
                    Semaine[6] = uneDate.AddDays(1);
                    break;

                case DayOfWeek.Sunday:
                    Semaine[0] = uneDate.AddDays(-6);
                    Semaine[1] = uneDate.AddDays(-5);
                    Semaine[2] = uneDate.AddDays(-4);
                    Semaine[3] = uneDate.AddDays(-3);
                    Semaine[4] = uneDate.AddDays(-2);
                    Semaine[5] = uneDate.AddDays(-1);
                    Semaine[6] = uneDate;
                    break;

                default:
                    break;
            }
            return Semaine;
        }

        private void dpk_datejour_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Dbal thedbal = new Dbal("LSRGames");
            DAOtheme thedaotheme = new DAOtheme(thedbal);
            DAOsalles unDaoSalles = new DAOsalles(thedbal, thedaotheme);
            InitialiserFenêtre(uneListebouton, unDaoSalles, (DateTime)dpk_datejour.SelectedDate);
        }

        private void un_un_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("un_un", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            un_un.BorderBrush = Brushes.Blue;
            un_un.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
            
            
        }

        private void un_deux_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("un_deux", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            un_deux.BorderBrush = Brushes.Blue;
            un_deux.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void un_trois_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("un_trois", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            un_trois.BorderBrush = Brushes.Blue;
            un_trois.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void un_quatre_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("un_quatre", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            un_quatre.BorderBrush = Brushes.Blue;
            un_quatre.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void un_cinq_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("un_cinq", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            un_cinq.BorderBrush = Brushes.Blue;
            un_cinq.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void un_six_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("un_six", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            un_six.BorderBrush = Brushes.Blue;
            un_six.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void un_sept_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("un_sept", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            un_sept.BorderBrush = Brushes.Blue;
            un_sept.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void un_huit_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("un_huit", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            un_huit.BorderBrush = Brushes.Blue;
            un_huit.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void un_neuf_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("un_neuf", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            un_neuf.BorderBrush = Brushes.Blue;
            un_neuf.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void un_dix_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("un_dix", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            un_dix.BorderBrush = Brushes.Blue;
            un_dix.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void un_onze_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("un_onze", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            un_onze.BorderBrush = Brushes.Blue;
            un_onze.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void un_douze_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("un_douze", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            un_douze.BorderBrush = Brushes.Blue;
            un_douze.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void deux_un_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("deux_un", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            deux_un.BorderBrush = Brushes.Blue;
            deux_un.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void deux_deux_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("deux_deux", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            deux_deux.BorderBrush = Brushes.Blue;
            deux_deux.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void deux_trois_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("deux_trois", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            deux_trois.BorderBrush = Brushes.Blue;
            deux_trois.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void deux_quatre_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("deux_quatre", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            deux_quatre.BorderBrush = Brushes.Blue;
            deux_quatre.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void deux_cinq_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("deux_cinq", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            deux_cinq.BorderBrush = Brushes.Blue;
            deux_cinq.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void deux_six_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("deux_six", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            deux_six.BorderBrush = Brushes.Blue;
            deux_six.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void deux_sept_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("deux_sept", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            deux_sept.BorderBrush = Brushes.Blue;
            deux_sept.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void deux_huit_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("deux_huit", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            deux_huit.BorderBrush = Brushes.Blue;
            deux_huit.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void deux_neuf_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("deux_neuf", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            deux_neuf.BorderBrush = Brushes.Blue;
            deux_neuf.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void deux_dix_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("deux_dix", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            deux_dix.BorderBrush = Brushes.Blue;
            deux_dix.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void deux_onze_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("deux_onze", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            deux_onze.BorderBrush = Brushes.Blue;
            deux_onze.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void deux_douze_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("deux_douze", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            deux_douze.BorderBrush = Brushes.Blue;
            deux_douze.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void trois_un_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("trois_un", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            trois_un.BorderBrush = Brushes.Blue;
            trois_un.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void trois_deux_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("trois_deux", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            trois_deux.BorderBrush = Brushes.Blue;
            trois_deux.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void trois_trois_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("trois_trois", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            trois_trois.BorderBrush = Brushes.Blue;
            trois_trois.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void trois_quatre_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("trois_quatre", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            trois_quatre.BorderBrush = Brushes.Blue;
            trois_quatre.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void trois_cinq_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("trois_cinq", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            trois_cinq.BorderBrush = Brushes.Blue;
            trois_cinq.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void trois_six_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("trois_six", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            trois_six.BorderBrush = Brushes.Blue;
            trois_six.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void trois_sept_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("trois_sept", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            trois_sept.BorderBrush = Brushes.Blue;
            trois_sept.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void trois_huit_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("trois_huit", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            trois_huit.BorderBrush = Brushes.Blue;
            trois_huit.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void trois_neuf_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("trois_neuf", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            trois_neuf.BorderBrush = Brushes.Blue;
            trois_neuf.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void trois_dix_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("trois_dix", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            trois_dix.BorderBrush = Brushes.Blue;
            trois_dix.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void trois_onze_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("trois_onze", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            trois_onze.BorderBrush = Brushes.Blue;
            trois_onze.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void trois_douze_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("trois_douze", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            trois_douze.BorderBrush = Brushes.Blue;
            trois_douze.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void quatre_un_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("quatre_un", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            quatre_un.BorderBrush = Brushes.Blue;
            quatre_un.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void quatre_deux_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("quatre_deux", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            quatre_deux.BorderBrush = Brushes.Blue;
            quatre_deux.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void quatre_trois_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("quatre_trois", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            quatre_trois.BorderBrush = Brushes.Blue;
            quatre_trois.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void quatre_quatre_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("quatre_quatre", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            quatre_quatre.BorderBrush = Brushes.Blue;
            quatre_quatre.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void quatre_cinq_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("quatre_cinq", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            quatre_cinq.BorderBrush = Brushes.Blue;
            quatre_cinq.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void quatre_six_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("quatre_six", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            quatre_six.BorderBrush = Brushes.Blue;
            quatre_six.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void quatre_sept_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("quatre_sept", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            quatre_sept.BorderBrush = Brushes.Blue;
            quatre_sept.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void quatre_huit_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("quatre_huit", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            quatre_huit.BorderBrush = Brushes.Blue;
            quatre_huit.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void quatre_neuf_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("quatre_neuf", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            quatre_neuf.BorderBrush = Brushes.Blue;
            quatre_neuf.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void quatre_dix_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("quatre_dix", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            quatre_dix.BorderBrush = Brushes.Blue;
            quatre_dix.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void quatre_onze_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("quatre_onze", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            quatre_onze.BorderBrush = Brushes.Blue;
            quatre_onze.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void quatre_douze_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("quatre_douze", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            quatre_douze.BorderBrush = Brushes.Blue;
            quatre_douze.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void cinq_un_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("cinq_un", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            cinq_un.BorderBrush = Brushes.Blue;
            cinq_un.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void cinq_deux_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("cinq_deux", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            cinq_deux.BorderBrush = Brushes.Blue;
            cinq_deux.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void cinq_trois_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("cinq_trois", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            cinq_trois.BorderBrush = Brushes.Blue;
            cinq_trois.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void cinq_quatre_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("cinq_quatre", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            cinq_quatre.BorderBrush = Brushes.Blue;
            cinq_quatre.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void cinq_cinq_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("cinq_cinq", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            cinq_cinq.BorderBrush = Brushes.Blue;
            cinq_cinq.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void cinq_six_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("cinq_six", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            cinq_six.BorderBrush = Brushes.Blue;
            cinq_six.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void cinq_sept_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("cinq_sept", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            cinq_sept.BorderBrush = Brushes.Blue;
            cinq_sept.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void cinq_huit_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("cinq_huit", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            cinq_huit.BorderBrush = Brushes.Blue;
            cinq_huit.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void cinq_neuf_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("cinq_neuf", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            cinq_neuf.BorderBrush = Brushes.Blue;
            cinq_neuf.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void cinq_dix_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("cinq_dix", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            cinq_dix.BorderBrush = Brushes.Blue;
            cinq_dix.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void cinq_onze_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("cinq_onze", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            cinq_onze.BorderBrush = Brushes.Blue;
            cinq_onze.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void cinq_douze_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("cinq_douze", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            cinq_douze.BorderBrush = Brushes.Blue;
            cinq_douze.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void six_un_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("six_un", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            six_un.BorderBrush = Brushes.Blue;
            six_un.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void six_deux_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("six_deux", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            six_deux.BorderBrush = Brushes.Blue;
            six_deux.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void six_trois_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("six_trois", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            six_trois.BorderBrush = Brushes.Blue;
            six_trois.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void six_quatre_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("six_quatre", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            six_quatre.BorderBrush = Brushes.Blue;
            six_quatre.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void six_cinq_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("six_cinq", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            six_cinq.BorderBrush = Brushes.Blue;
            six_cinq.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void six_six_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("six_six", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            six_six.BorderBrush = Brushes.Blue;
            six_six.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void six_sept_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("six_sept", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            six_sept.BorderBrush = Brushes.Blue;
            six_sept.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void six_huit_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("six_huit", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            six_huit.BorderBrush = Brushes.Blue;
            six_huit.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void six_neuf_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("six_neuf", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            six_neuf.BorderBrush = Brushes.Blue;
            six_neuf.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void six_dix_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("six_dix", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            six_dix.BorderBrush = Brushes.Blue;
            six_dix.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void six_onze_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("six_onze", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            six_onze.BorderBrush = Brushes.Blue;
            six_onze.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void six_douze_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("six_douze", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            six_douze.BorderBrush = Brushes.Blue;
            six_douze.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void sept_un_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("sept_un", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            sept_un.BorderBrush = Brushes.Blue;
            sept_un.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void sept_deux_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("sept_deux", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            sept_deux.BorderBrush = Brushes.Blue;
            sept_deux.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void sept_trois_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("sept_trois", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            sept_trois.BorderBrush = Brushes.Blue;
            sept_trois.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void sept_quatre_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("sept_quatre", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            sept_quatre.BorderBrush = Brushes.Blue;
            sept_quatre.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void sept_cinq_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("sept_cinq", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            sept_cinq.BorderBrush = Brushes.Blue;
            sept_cinq.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void sept_six_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("sept_six", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            sept_six.BorderBrush = Brushes.Blue;
            sept_six.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void sept_sept_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("sept_sept", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            sept_sept.BorderBrush = Brushes.Blue;
            sept_sept.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void sept_huit_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("sept_huit", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            sept_huit.BorderBrush = Brushes.Blue;
            sept_huit.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void sept_neuf_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("sept_neuf", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            sept_neuf.BorderBrush = Brushes.Blue;
            sept_neuf.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void sept_dix_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("sept_dix", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            sept_dix.BorderBrush = Brushes.Blue;
            sept_dix.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void sept_onze_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("sept_onze", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            sept_onze.BorderBrush = Brushes.Blue;
            sept_onze.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        private void sept_douze_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime[] tabDate = RetourneSemaine((DateTime)dpk_datejour.SelectedDate);
            DateTime DateChoixSalle = retourneDateSelonNomBoutonetTabDate("sept_douze", tabDate);
            Window2 wnd = new Window2(thedaosalles, thedaotheme, DateChoixSalle);
            sept_douze.BorderBrush = Brushes.Blue;
            sept_douze.BorderThickness = new Thickness(4);
            wnd.ShowDialog();
        }

        public static DateTime retourneDateSelonNomBoutonetTabDate(string nameButton, DateTime[] unTabDate)
        {
            DateTime dateRetourne = new DateTime();
            int position = nameButton.IndexOf('_');
            string extraction = nameButton.Substring(0,position);
            switch(extraction)
            {
                case "un":
                    dateRetourne = unTabDate[0];
                    dateRetourne = affecteHeureSelonNomBouton(nameButton, dateRetourne);
                    break;
                case "deux":
                    dateRetourne = unTabDate[1];
                    dateRetourne = affecteHeureSelonNomBouton(nameButton, dateRetourne);
                    break;

                case "trois":
                    dateRetourne = unTabDate[2];
                    dateRetourne = affecteHeureSelonNomBouton(nameButton, dateRetourne);
                    break;

                case "quatre":
                    dateRetourne = unTabDate[3];
                    dateRetourne = affecteHeureSelonNomBouton(nameButton, dateRetourne);
                    break;

                case "cinq":
                    dateRetourne = unTabDate[4];
                    dateRetourne = affecteHeureSelonNomBouton(nameButton, dateRetourne);
                    break;

                case "six":
                    dateRetourne = unTabDate[5];
                    dateRetourne = affecteHeureSelonNomBouton(nameButton, dateRetourne);
                    break;

                case "sept":
                    dateRetourne = unTabDate[6];
                    dateRetourne = affecteHeureSelonNomBouton(nameButton, dateRetourne);
                    break;

                default:
                    break;
            }

            return dateRetourne;
        }

        public static DateTime affecteHeureSelonNomBouton(string nomBouton, DateTime uneDate)
        {
            DateTime dateretour;
            int position = nomBouton.IndexOf('_');
            string extraction = nomBouton.Substring(position + 1);
            if (extraction == "un")
            {
                dateretour = new DateTime(uneDate.Year, uneDate.Month, uneDate.Day, 10, 0, 0);
                return dateretour;
            }
            if (extraction == "deux")
            {
                dateretour = new DateTime(uneDate.Year, uneDate.Month, uneDate.Day, 11, 0, 0);
                return dateretour;
            }
            if (extraction == "trois")
            {
                dateretour = new DateTime(uneDate.Year, uneDate.Month, uneDate.Day, 12, 0, 0);
                return dateretour;
            }
            if (extraction == "quatre")
            {
                dateretour = new DateTime(uneDate.Year, uneDate.Month, uneDate.Day, 13, 0, 0);
                return dateretour;
            }
            if (extraction == "cinq")
            {
                dateretour = new DateTime(uneDate.Year, uneDate.Month, uneDate.Day, 14, 0, 0);
                return dateretour;
            }
            if (extraction == "six")
            {
                dateretour = new DateTime(uneDate.Year, uneDate.Month, uneDate.Day, 15, 0, 0);
                return dateretour;
            }
            if (extraction == "sept")
            {
                dateretour = new DateTime(uneDate.Year, uneDate.Month, uneDate.Day, 16, 0, 0);
                return dateretour;
            }
            if (extraction == "huit")
            {
                dateretour = new DateTime(uneDate.Year, uneDate.Month, uneDate.Day, 17, 0, 0);
                return dateretour;
            }
            if (extraction == "neuf")
            {
                dateretour = new DateTime(uneDate.Year, uneDate.Month, uneDate.Day, 18, 0, 0);
                return dateretour;
            }
            if (extraction == "dix")
            {
                dateretour = new DateTime(uneDate.Year, uneDate.Month, uneDate.Day, 19, 0, 0);
                return dateretour;
            }
            if (extraction == "onze")
            {
                dateretour = new DateTime(uneDate.Year, uneDate.Month, uneDate.Day, 20, 0, 0);
                return dateretour;
            }
            if (extraction == "douze")
            {
                dateretour = new DateTime(uneDate.Year, uneDate.Month, uneDate.Day, 21, 0, 0);
                return dateretour;
            }
            return new DateTime();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            foreach(Button btn in uneListebouton )
            {
                btn.BorderBrush = Brushes.Gray;
                btn.BorderThickness = new Thickness(0.5);
            }
        }
    }


}
