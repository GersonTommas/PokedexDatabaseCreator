using System;
using System.Collections.Generic;
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

namespace PokedexDatabaseCreator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Db.DBConnect();
        }

        private void Generation_Click(object sender, RoutedEventArgs e)
        {
            Windows.WindowGeneration WG = new Windows.WindowGeneration(); WG.Show();
        }
        private void Game_Click(object sender, RoutedEventArgs e)
        {
            Windows.WindowGame WG = new Windows.WindowGame(); WG.Show();
        }
        private void Type_Click(object sender, RoutedEventArgs e)
        {
            Windows.WindowType WT = new Windows.WindowType(); WT.Show();
        }
        private void Contest_Click(object sender, RoutedEventArgs e)
        {
            Windows.WindowContest WC = new Windows.WindowContest(); WC.Show();
        }
        private void Category_Click(object sender, RoutedEventArgs e)
        {
            Windows.WindowCategory WC = new Windows.WindowCategory(); WC.Show();
        }
        private void PP_Click(object sender, RoutedEventArgs e)
        {
            Windows.WindowPP WP = new Windows.WindowPP(); WP.Show();
        }
        private void Power_Click(object sender, RoutedEventArgs e)
        {
            Windows.WindowPower WP = new Windows.WindowPower(); WP.Show();
        }
        private void Accuracy_Click(object sender, RoutedEventArgs e)
        {
            Windows.WindowAccuracy WA = new Windows.WindowAccuracy(); WA.Show();
        }
    }
}
