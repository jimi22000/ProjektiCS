using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        }

        private void settings_Click(object sender, RoutedEventArgs e)
        {
            login.Visibility = Visibility.Hidden;
            newuser.Visibility = Visibility.Hidden;
            Quit.Visibility = Visibility.Hidden;
            settings.Visibility = Visibility.Hidden;
            GM_teksti.Visibility = Visibility.Hidden;
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

            int perheenjäsenet = 5;

            if (perheenjäsenet > 10)
            {
                aikuiset.Visibility = Visibility.Visible;
                lapset.Visibility = Visibility.Visible;
            }
        }
    }
}
