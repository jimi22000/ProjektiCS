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

        }

        private void newuser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            login.Visibility = Visibility.Hidden;
            newuser.Visibility = Visibility.Hidden;
            Quit.Visibility = Visibility.Hidden;
            settings.Visibility = Visibility.Hidden;
            GM_Teksti.Visibility = Visibility.Hidden;
            toka.Visibility = Visibility.Visible;
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            aarjuusure win2 = new aarjuusure();
            win2.Show();
        }
        
    }
}
