using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfApp5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            StreamReader reader = File.OpenText("save.txt");
            string line = reader.ReadLine();
            while (line != null)
            {
                inventaario.Items.Add((string)line);
                line = reader.ReadLine();
            }
            reader.Close();
        }

        private void lisää_Click(object sender, RoutedEventArgs e)
        {
            bool found = false;
            foreach (var item in inventaario.Items)
            {
                if (item.ToString().Contains(tarvikkeet.Text))
                {
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                inventaario.Items.Add(tarvikkeet.Text + " - " + määrä.Text);
            }
        }

        private void tarvikkeet_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void määrä_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void kauppalista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void inventaario_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void tallenna_Click(object sender, RoutedEventArgs e) //tämä nappula tallentaa inventaario listan tiedot tiedostoon nimeltä save.txt
        {
            const string sPath = "save.txt";
            System.IO.File.WriteAllLines(sPath, inventaario.Items.Cast<string>().ToArray());
        }

        private void avaa_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
