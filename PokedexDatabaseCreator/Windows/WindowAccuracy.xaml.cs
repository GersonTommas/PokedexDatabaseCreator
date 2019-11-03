﻿using System;
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
    /// Interaction logic for WindowAccuracy.xaml
    /// </summary>
    public partial class WindowAccuracy : Window
    {
        public WindowAccuracy()
        {
            InitializeComponent(); Reload();
        }

        private void Reload()
        {
            Tb1.Text = "";
            Lb1.ItemsSource = null;
            Db.DBConnect();
            Lb1.ItemsSource = Db.DBTickets.AllAccuracyTable;
        }

        private void Submit()
        {
            Db.DBTickets.SubmitChanges(); Reload();
        }

        private void DeleteEntry_Click(object sender, RoutedEventArgs e)
        {
            if (Lb1.SelectedIndex != -1)
            {
                Db.DBTickets.AllAccuracyTable.DeleteOnSubmit((DBAccuracyClass)Lb1.SelectedItem); Submit();
            }
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            Submit();
        }

        private void AddEntry_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Tb1.Text))
            {
                try
                {
                    var newTicket = Db.DBTickets.GlobalNewAccuracy;
                    newTicket.Number = Convert.ToInt32(Tb1.Text);
                    Db.DBTickets.AllAccuracyTable.InsertOnSubmit(newTicket);

                    Submit();
                }
                catch { }
            }
        }
    }
}
