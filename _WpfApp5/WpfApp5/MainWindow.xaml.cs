using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ObservableCollection<InventaarioItem> inventaarioItems= new ObservableCollection<InventaarioItem>();

        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }
            public override string ToString()
            {
                return Text;
            }
        }

        public class InventaarioItem
        {
            public string Text { get; set; }
            public int Count { get; set; }
        }


        public MainWindow()
        {
            InitializeComponent();
            inventaario.ItemsSource = inventaarioItems;
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
            //Lisää listaan itemi
            InventaarioItem item1 = new InventaarioItem();
            bool found = false;
            foreach (var item in inventaario.Items)
            {
                if (item.ToString().Contains(tarvikkeet.Text))
                {
                    found = true;
                    inventaario.Items.Remove(item1);
                    item1.Text = tarvikkeet.Text; //lue tarvikkeet teksti
                    int maara = int.Parse(määrä.Text);
                    item1.Count = maara; //lue määrä jostain textboxista
                    inventaarioItems.Add(item1);
                    break;
                }
            }
            if (!found)
            {
                item1.Text = tarvikkeet.Text;
                int maara = int.Parse(määrä.Text);
                item1.Count = maara; 
                inventaarioItems.Add(item1);
            }
            ArrayList q = new ArrayList();
            foreach (object o in inventaario.Items)
                q.Add(o);
            q.Sort();
            inventaario.Items.Clear();
            foreach (object o in q)
            {
                inventaario.Items.Add(o);
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

        private void poista_Click(object sender, RoutedEventArgs e)
        {
            inventaario.Items.RemoveAt(inventaario.SelectedIndex);
        }

        private void combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void test_Click(object sender, RoutedEventArgs e)
        {
            ComboboxItem item = new ComboboxItem();
            int vallue = int.Parse(value.Text);
            item.Text= teksti.Text;
            item.Value = vallue;
            combo.Items.Add(item);
            combo.SelectedIndex = 0;
        }

        private void teksti_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void value_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void poisto_Click(object sender, RoutedEventArgs e)
        {
            combo.Items.RemoveAt((int) combo.SelectedIndex);
        }
    }
}
