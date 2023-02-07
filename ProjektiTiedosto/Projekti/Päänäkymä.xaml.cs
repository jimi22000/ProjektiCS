using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Projekti
{
    /// <summary>
    /// Interaction logic for Päänäkymä.xaml
    /// </summary>
    public partial class Päänäkymä : Window
    {
        public Päänäkymä()
        {
            InitializeComponent();
        }

        private void Inventaario_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Tarkista_Click(object sender, RoutedEventArgs e)
        {
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Päänäkymä win2 = new Päänäkymä();
            win2.Show();
            
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win2 = new MainWindow();
            win2.Show();
            this.Close();
        }
    }
}
