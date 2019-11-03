using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Globalization;
using System.Windows.Data;

namespace PokedexDatabaseCreator
{
    class Shared
    {
    }


    #region Property Changed
    public abstract class ObservableClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name)); }
    }
    #endregion // Property Changed


    public class GenerationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        { try { var ret = (from x in Db.DBTickets.AllGenerationsTable where x.Id == (int)value select x).First(); return ret.Name; } catch { return "Hello"; } }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) { throw new NotImplementedException("Not implemented."); }
    }
}
