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

namespace Projekti
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Päänäkymä : Window
    {
        private ObservableCollection<InventaarioItem> inventaarioItems = new ObservableCollection<InventaarioItem>();
        InventaarioItem item1 = new InventaarioItem();
        public class InventaarioItem
        {
            public string? Text { get; set; }
            public int Count { get; set; }
            //public override string? ToString()
            //{
            //    return Text;
            //}
        }

        private InventaarioItem? _selectedinventoryitem;
        //public InventaarioItem ValittuInventaarioItemi { get; set; }
        
        private string _tekstitiedosto;

        public Päänäkymä(string tekstitiedosto)
        {
            InitializeComponent();
            _tekstitiedosto = tekstitiedosto;
            inventaario.ItemsSource = inventaarioItems;
            StreamReader reader = File.OpenText(tekstitiedosto);
            string? line = reader.ReadLine();

            while (line != null)
            {
                if (line != null)
                {
                    var item = new InventaarioItem() { Text = line };
                    inventaarioItems.Add(item);
                }

                line = reader.ReadLine();
            }
            reader.Close();
        }
        private void lisää_Click(object sender, RoutedEventArgs e)
        {
            lisaus();
            //Alla olevan koodin pitäisi järjestää lista a-ö
            //ArrayList q = new ArrayList();
            //foreach (object o in inventaarioItems)
            //    q.Add(o);
            //q.Sort();
            //inventaarioItems.Clear();
            //foreach (object o in q)
            //{
            //    inventaarioItems.Add(o);
            //}
        }

        private void lisaus()
        {
            //Lisää listaan itemi
            item1.Text = tarvikkeet.Text; //lue tarvikkeet teksti
            int maara = int.Parse(määrä.Text);
            item1.Count = maara; //lue määrä textboxista
            bool found = false;
            foreach (var item in inventaarioItems)
            {
                if (item1.ToString().Contains(tarvikkeet.Text))
                {
                    found = true;
                    MessageBox.Show("On jo");
                    break;
                }
            }
            if (!found)
            {
                inventaarioItems.Add(item1);
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
            //TODO lisää nappula jolla valitut tuotteet kauppalistalle, myös tekstiboxit jotta saadaan lisättyä erillisiä tuotteita kauppalistalle ja clear nappula.
        }

        private void inventaario_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listbox = (ListBox)sender;
            _selectedinventoryitem = (InventaarioItem)listbox.SelectedValue;
        }
        // Tallentaa oikeaan tiedostoon "Projekti.Päänäkymä+InventaarioItem"
        private void tallenna_Click(object sender, RoutedEventArgs e)
        {
            List<string> tekstiLista = new List<string>();

            foreach (InventaarioItem item in inventaarioItems)
            {
                tekstiLista.Add(item.Text);
            }

            // tallennetaan tekstitiedostoon kaikki listan tekstit
            File.WriteAllLines(_tekstitiedosto, tekstiLista);
        }

        private void poista_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedinventoryitem != null)
            {
                if (_selectedinventoryitem.Count > 1)
                {
                    //TODO laita toimimaan.
                    _selectedinventoryitem.Count -= 1;
                    inventaarioItems.Remove(_selectedinventoryitem);
                    inventaarioItems.Add(item1);
                }
                else
                {
                    inventaarioItems.Remove(_selectedinventoryitem);
                }
            }
        }
    }
}