using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xaml.Schema;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Projekti
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void Tyhjennä()
        {
            username1.Text = "";
            password2.Text = "";
            email.Text = "";
            age.Text = "";
            perhe.Text = "";
            aikuiset.Text = "0";
            lapset.Text = "0";
        }
        private void login_Click(object sender, RoutedEventArgs e)
        {
            if (LogIn.Visibility == Visibility.Visible) 
            {
                LogIn.Visibility = Visibility.Hidden;
            }
            else
            {
                LogIn.Visibility = Visibility.Visible;
            }
        }

        private void newuser_Click(object sender, RoutedEventArgs e)
        {
            if (CreateNewUser.Visibility == Visibility.Visible)
            {
                CreateNewUser.Visibility = Visibility.Hidden;
            }
            else
            {
                CreateNewUser.Visibility = Visibility.Visible;
            }
        }

        private void age_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(age.Text, "[^0-9]"))
            {
                MessageBox.Show("Vain numeroita!");

                age.Text = "";
            }
            if (age.Text.Length > 2) 
            {
                MessageBox.Show("Virheellinen luku!");

                age.Text = "";
            }
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            aarjuusure win2 = new aarjuusure();
            win2.Show();
        }

        private void perhe_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (System.Text.RegularExpressions.Regex.IsMatch(perhe.Text, "[^0-9]"))
            {
                MessageBox.Show("Vain numeroita!");
                perhe.Text = "";
            }
            int perhemäärä;
            bool res = int.TryParse(perhe.Text, out perhemäärä);
            if (perhemäärä > 1)
            {
                aikuiset.Visibility = Visibility.Visible;
                lapset.Visibility = Visibility.Visible;
                AdultChild.Visibility = Visibility.Visible;
            }
            else if (perhemäärä == 1)
            {
                aikuiset.Visibility = Visibility.Hidden;
                lapset.Visibility = Visibility.Hidden;
                AdultChild.Visibility = Visibility.Hidden;
            }
            if (perhemäärä > 10)
            {
                MessageBox.Show("Oletko aivan varma?");
                perhe.Text = "";
            }
        }
        private void aikuiset_TextChanged(object sender, TextChangedEventArgs e)
        {
            aikuiset.Text = "1";

            if (System.Text.RegularExpressions.Regex.IsMatch(aikuiset.Text, "[^0-9]"))
            {
                MessageBox.Show("Vain numeroita!");
                aikuiset.Text = "1";
            }
        }

        private void lapset_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(lapset.Text, "[^0-9]"))
            {
                MessageBox.Show("Vain numeroita!");
                lapset.Text = "";
            }
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            Tyhjennä();
        }

        private void palaa_Click(object sender, RoutedEventArgs e)
        {
            CreateNewUser.Visibility = Visibility.Hidden;
            Tyhjennä();
        }

        private void clear2_Click(object sender, RoutedEventArgs e)
        {
            username.Text = "";
            password.Text = "";
        }

        private void palaa2_Click(object sender, RoutedEventArgs e)
        {
            username.Text = "";
            password.Text = "";
            LogIn.Visibility = Visibility.Hidden;
        }
        public void jatka_Click(object sender, RoutedEventArgs e)
        {
            bool jatka = false;

            string emailcheck = email.Text;
            if (emailcheck.EndsWith("@gmail.com"))
            {
                jatka = true;
            }
            else
            {
                MessageBox.Show("Sähköpostiosoitteen tulee päättyä '@gmail.com'");
            }

            if (jatka == true)
            {
                StreamWriter File = new StreamWriter("users.txt", true);
                string tallennettava = (username1.Text + "," + password2.Text + "," + email.Text + "," + perhe.Text + "," + aikuiset.Text + "," + lapset.Text);
                File.WriteLine(tallennettava);
                File.Close();
                MessageBox.Show("Käyttäjätunnus luotiin onnistuneesti!");
                CreateNewUser.Visibility = Visibility.Hidden;
                Tyhjennä();
            }
        }

        public void jatka2_Click(object sender, RoutedEventArgs e)
        {
            using (StreamReader sr = new StreamReader("users.txt"))
            {
                string rivi;
                string käyttäjä = username.Text;
                bool sallittu = false;
                while ((rivi = sr.ReadLine()) != null!)
                {
                    // Jaetaan rivi pilkun kohdalta kahteen osaan
                    string[] tiedot = rivi.Split(',');
                    // Tarkistetaan käyttäjänimi ja salasana
                    if (tiedot[0] == käyttäjä && tiedot[1] == password.Text)
                    {
                        sallittu = true;
                    }
                }
                if (sallittu == true)
                {
                    var tekstitiedosto = käyttäjä + ".txt";
                    if (!File.Exists(tekstitiedosto))
                    {
                        // Tarkistetaan, jos tiedosto on olemassa, jos ei, niin luodaan uusi
                        using (StreamWriter sw = File.CreateText(tekstitiedosto))
                        {
                        }
                    }

                    Päänäkymä win2 = new Päänäkymä(tekstitiedosto);
                    win2.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Virheellinen käyttäjätunnus tai salasana");
                }
            }
        }
        private void back2_Click(object sender, RoutedEventArgs e)
        {
            aloitus.Visibility = Visibility.Visible;
            GM_teksti.Visibility = Visibility.Visible;
            newuser.Visibility = Visibility.Visible;    
        }
    }
}