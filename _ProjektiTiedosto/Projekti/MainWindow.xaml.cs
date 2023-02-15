using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
            aikuiset.Text = "";
            lapset.Text = "";
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

        private void settings_Click(object sender, RoutedEventArgs e)
        {
            login.Visibility = Visibility.Hidden;
            newuser.Visibility = Visibility.Hidden;
            Quit.Visibility = Visibility.Hidden;
            settings.Visibility = Visibility.Hidden;
            GM_teksti.Visibility = Visibility.Hidden;
            LogIn.Visibility = Visibility.Hidden;
            CreateNewUser.Visibility = Visibility.Hidden;
            back.Visibility = Visibility.Visible;
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            aarjuusure win2 = new aarjuusure();
            win2.Show();
        }


        private void back_Click(object sender, RoutedEventArgs e)
        {
            login.Visibility = Visibility.Visible;
            newuser.Visibility = Visibility.Visible;
            Quit.Visibility = Visibility.Visible;
            settings.Visibility = Visibility.Visible;
            GM_teksti.Visibility = Visibility.Visible;
            back.Visibility= Visibility.Hidden;
        }

        private void perhe_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (System.Text.RegularExpressions.Regex.IsMatch(perhe.Text, "[^0-9]"))
            {
                MessageBox.Show("Vain numeroita!");
                perhe.Text = "";
            }
            //tää kusee. pitää keksii miten korjataan!!
            int määrä;
            bool res = int.TryParse(perhe.Text, out määrä);
            if (määrä > 1)
            {
                aikuiset.Visibility = Visibility.Visible;
                lapset.Visibility = Visibility.Visible;
                AdultChild.Visibility = Visibility.Visible;
            }
            if (määrä > 10)
            {
                MessageBox.Show("Oletko aivan varma?");
                perhe.Text = "";
            }
        }
        private void aikuiset_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(aikuiset.Text, "[^0-9]"))
            {
                MessageBox.Show("Vain numeroita!");
                aikuiset.Text = "";
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Päänäkymä win2 = new Päänäkymä();
            win2.Show();
            this.Close();
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
            if (email.Text.Length == 0)
            {
                MessageBox.Show("Enter an email.");
                email.Focus();
            }
            else if (!Regex.IsMatch(email.Text, @"^[a-zA-Z][\w.-][a-zA-Z0-9]@[a-zA-Z0-9][\w.-][a-zA-Z0-9].[a-zA-Z][a-zA-Z.]$"))
            {
                MessageBox.Show("Enter a valid email.");
                email.Select(0, email.Text.Length);
                email.Focus();
            }



        }
    }
}
