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
using System.Windows.Shapes;

namespace Projekti
{
    /// <summary>
    /// Interaction logic for aarjuusure.xaml
    /// </summary>
    public partial class aarjuusure : Window
    {
        public aarjuusure()
        {
            InitializeComponent();
        }

        private void no_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void yes_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
