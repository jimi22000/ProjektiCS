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
        //TODO listbox vaihdettava listview objektiksi
        //TODO xaml tiedostosta template näyttämään määrä, tekstin kanssa

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

        public MainWindow()
        {
            InitializeComponent();
            inventaario.ItemsSource = inventaarioItems;
            StreamReader reader = File.OpenText("save.txt");
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
            //Lisää listaan itemi
            InventaarioItem item1 = new InventaarioItem();
            item1.Text = tarvikkeet.Text; //lue tarvikkeet teksti
            int maara = int.Parse(määrä.Text);
            item1.Count = maara; //lue määrä textboxista
            bool found = false;
            foreach (var item in inventaarioItems)
            {
                if (item1.ToString().Contains(tarvikkeet.Text))
                {
                    found = true;
                    inventaarioItems.Remove(new InventaarioItem() { Text = item1.Text, Count = item1.Count });
                    inventaarioItems.Add(new InventaarioItem() { Text = item1.Text, Count = item1.Count });
                    break;
                }
            }
            if (!found)
            {
                inventaarioItems.Add(new InventaarioItem() { Text = item1.Text, Count = item1.Count });
            }
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
            var listbox = (ListBox)sender;
            _selectedinventoryitem = (InventaarioItem)listbox.SelectedValue;
        }

        private void tallenna_Click(object sender, RoutedEventArgs e) //tämä nappula tallentaa inventaario listan tiedot tiedostoon nimeltä save.txt
        {
            const string sPath = "save.txt";
            System.IO.File.WriteAllLines(sPath, inventaarioItems.Cast<string>().ToArray());
        }

        private void poista_Click(object sender, RoutedEventArgs e)
        {
            //tämä poistaa koko rivin
            //inventaario.Items.RemoveAt(inventaario.SelectedIndex);
            if (_selectedinventoryitem != null)
            {
                if (_selectedinventoryitem.Count > 0) 
                {
                    _selectedinventoryitem.Count -= 1;
                }
                else
                {
                    inventaarioItems.Remove(_selectedinventoryitem);
                }
            }
        }
    }
}
