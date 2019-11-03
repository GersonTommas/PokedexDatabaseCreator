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
using System.Windows.Shapes;

namespace PokedexDatabaseCreator.Windows
{
    /// <summary>
    /// Interaction logic for WindowGame.xaml
    /// </summary>
    public partial class WindowGame : Window
    {
        public WindowGame()
        {
            InitializeComponent(); Reload(); Cb1.ItemsSource = Db.DBTickets.AllGenerationsTable;
        }

        private void Reload()
        {
            Tb1.Text = "";
            Lb1.ItemsSource = null;
            Db.DBConnect();
            Lb1.ItemsSource = Db.DBTickets.AllGamesTable;
            try { Cb1.SelectedIndex = 0; } catch { Cb1.SelectedIndex = -1; }
        }

        private void Submit()
        {
            Db.DBTickets.SubmitChanges(); Reload();
        }

        private void DeleteEntry_Click(object sender, RoutedEventArgs e)
        {
            if (Lb1.SelectedIndex != -1)
            {
                Db.DBTickets.AllGamesTable.DeleteOnSubmit((DBGameClass)Lb1.SelectedItem); Submit();
            }
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            Submit();
        }

        private void AddEntry_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Tb1.Text) && Cb1.SelectedIndex != -1)
            {
                var newTicket = Db.DBTickets.GlobalNewGame;
                newTicket.Name = Tb1.Text;
                newTicket.Generation = ((DBGenerationClass)Cb1.SelectedItem).Id;
                Db.DBTickets.AllGamesTable.InsertOnSubmit(newTicket);
                Submit();
            }
        }
    }
}
