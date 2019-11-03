using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Linq.Mapping;
using System.Data.SQLite;
using System.IO;

namespace PokedexDatabaseCreator
{
    class Db
    {
        #region Variables

        private static SQLiteConnection Conect() { return new SQLiteConnection("Data Source=" + Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TG\\Pokedex.db;foreign keys=true;"); }

        #endregion


        #region Global

        public static DBTicketsContext DBTickets;

        public static void DBConnect() { CreateTables(); DBTicketsConnect(); }
        public static void DBConnect(string _temp) { CreateTables(); DBTicketsConnect(); }

        public static void DBTicketsConnect() { DBTickets = new DBTicketsContext(Conect()); }

        #endregion


        #region Private

        private static void CreateTables()
        {
            //CreateTable("DROP TABLE [SolutionsTable]");
            CreateTable("CREATE TABLE IF NOT EXISTS [GenerationTable] ([ID] INTEGER PRIMARY KEY AUTOINCREMENT, [Number] INTEGER NOT NULL, [Name] TEXT NOT NULL)");
            CreateTable("CREATE TABLE IF NOT EXISTS [GameTable] ([ID] INTEGER PRIMARY KEY AUTOINCREMENT, [Generation] INTEGER NOT NULL, [Name] TEXT NOT NULL)");

            CreateTable("CREATE TABLE IF NOT EXISTS [TypeTable] ([ID] INTEGER PRIMARY KEY AUTOINCREMENT, [Name] TEXT NOT NULL)");
            CreateTable("CREATE TABLE IF NOT EXISTS [CategoryTable] ([ID] INTEGER PRIMARY KEY AUTOINCREMENT, [Name] TEXT NOT NULL)");
            CreateTable("CREATE TABLE IF NOT EXISTS [ContestTable] ([ID] INTEGER PRIMARY KEY AUTOINCREMENT, [Name] TEXT NOT NULL)");

            CreateTable("CREATE TABLE IF NOT EXISTS [PPTable] ([ID] INTEGER PRIMARY KEY AUTOINCREMENT, [Number] INTEGER NOT NULL)");
            CreateTable("CREATE TABLE IF NOT EXISTS [PowerTable] ([ID] INTEGER PRIMARY KEY AUTOINCREMENT, [Number] INTEGER NOT NULL)");
            CreateTable("CREATE TABLE IF NOT EXISTS [AccuracyTable] ([ID] INTEGER PRIMARY KEY AUTOINCREMENT, [Number] INTEGER NOT NULL)");
        }
        private static void CreateTable(string _STRtable)
        {
            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TG\\");
            using (var sqldb = Conect())
            {
                sqldb.Open();
                var commandTable01 = new SQLiteCommand(_STRtable, sqldb);
                commandTable01.ExecuteNonQuery();
                sqldb.Close();
            }
        }
        private static void DefaultOptions()
        {

        }

        #endregion
    }

    #region Databases

    #region Database

    [Database(Name = "MyDataBase")]
    public partial class DBTicketsContext : System.Data.Linq.DataContext
    {
        #region On Created

        private static MappingSource mappingSource = new AttributeMappingSource();

        partial void OnCreated();

        public DBTicketsContext(System.Data.IDbConnection connection) : base(connection, mappingSource) { OnCreated(); }

        #endregion


        #region Public New Entries

        // Solutions
        public DBGenerationClass GlobalNewGeneration { get { return new DBGenerationClass() { Id = FindMaxGenerationID() + 1 }; } }
        public DBGameClass GlobalNewGame { get { return new DBGameClass() { Id = FindMaxGameID() + 1 }; } }
        public DBTypeClass GlobalNewType { get { return new DBTypeClass() { Id = FindMaxTypeID() + 1 }; } }
        public DBCategoryClass GlobalNewCategory { get { return new DBCategoryClass() { Id = FindMaxCategoryID() + 1 }; } }
        public DBContestClass GlobalNewContest { get { return new DBContestClass() { Id = FindMaxContestID() + 1 }; } }
        public DBPPClass GlobalNewPP { get { return new DBPPClass() { Id = FindMaxPPID() + 1 }; } }
        public DBPowerClass GlobalNewPower { get { return new DBPowerClass() { Id = FindMaxPowerID() + 1 }; } }
        public DBAccuracyClass GlobalNewAccuracy { get { return new DBAccuracyClass() { Id = FindMaxAccuracyID() + 1 }; } }

        #endregion // Public New Entries

        #region Private New Entries
        private int FindMaxGenerationID() { try { return AllGenerationsTable.Select(x => x.Id).Max(); } catch { return 0; } }
        private int FindMaxGameID() { try { return AllGamesTable.Select(x => x.Id).Max(); } catch { return 0; } }
        private int FindMaxTypeID() { try { return AllTypesTable.Select(x => x.Id).Max(); } catch { return 0; } }
        private int FindMaxCategoryID() { try { return AllCategoriesTable.Select(x => x.Id).Max(); } catch { return 0; } }
        private int FindMaxContestID() { try { return AllContestsTable.Select(x => x.Id).Max(); } catch { return 0; } }
        private int FindMaxPPID() { try { return AllPPTable.Select(x => x.Id).Max(); } catch { return 0; } }
        private int FindMaxPowerID() { try { return AllPowerTable.Select(x => x.Id).Max(); } catch { return 0; } }
        private int FindMaxAccuracyID() { try { return AllAccuracyTable.Select(x => x.Id).Max(); } catch { return 0; } }

        #endregion // Private New Entries


        #region Tables

        public System.Data.Linq.Table<DBGenerationClass> AllGenerationsTable { get { return GetTable<DBGenerationClass>(); } }
        public System.Data.Linq.Table<DBGameClass> AllGamesTable { get { return GetTable<DBGameClass>(); } }
        public System.Data.Linq.Table<DBTypeClass> AllTypesTable { get { return GetTable<DBTypeClass>(); } }
        public System.Data.Linq.Table<DBCategoryClass> AllCategoriesTable { get { return GetTable<DBCategoryClass>(); } }
        public System.Data.Linq.Table<DBContestClass> AllContestsTable { get { return GetTable<DBContestClass>(); } }
        public System.Data.Linq.Table<DBPPClass> AllPPTable { get { return GetTable<DBPPClass>(); } }
        public System.Data.Linq.Table<DBPowerClass> AllPowerTable { get { return GetTable<DBPowerClass>(); } }
        public System.Data.Linq.Table<DBAccuracyClass> AllAccuracyTable { get { return GetTable<DBAccuracyClass>(); } }

        #endregion // Tables
    }

    [Database(Name = "MyDatabase")]

    #endregion


    #region Table Generation

    [Table(Name = "GenerationTable")]
    public class DBGenerationClass : ObservableClass
    {
        #region Private

        private int _Id, _Number; private string _Name;

        #endregion // Private


        #region Public

        [Column(IsPrimaryKey = true, Storage = "_Id", DbType = "Int NOT NULL", CanBeNull = false)]
        public int Id { get { return _Id; } set { if (_Id != value) { _Id = value; OnPropertyChanged("Id"); } } }


        [Column(Storage = "_Number")]
        public int Number { get { return _Number; } set { if (_Number != value) { _Number = value; OnPropertyChanged("Number"); } } }


        [Column(Storage = "_Name")]
        public string Name { get { return _Name; } set { if (_Name != value) { _Name = value; OnPropertyChanged("Name"); } } }

        #endregion // Public
    }

    #endregion // Table Generation


    #region Table Game

    [Table(Name = "GameTable")]
    public class DBGameClass : ObservableClass
    {
        #region Private

        private int _Id, _Generation; private string _Name;

        #endregion // Private


        #region Public

        [Column(IsPrimaryKey = true, Storage = "_Id", DbType = "Int NOT NULL", CanBeNull = false)]
        public int Id { get { return _Id; } set { if (_Id != value) { _Id = value; OnPropertyChanged("Id"); } } }


        [Column(Storage = "_Generation")]
        public int Generation { get { return _Generation; } set { if (_Generation != value) { _Generation = value; OnPropertyChanged("Generation"); } } }


        [Column(Storage = "_Name")]
        public string Name { get { return _Name; } set { if (_Name != value) { _Name = value; OnPropertyChanged("Name"); } } }

        #endregion // Public
    }

    #endregion // Table Game


    #region Table Type

    [Table(Name = "TypeTable")]
    public class DBTypeClass : ObservableClass
    {
        #region Private

        private int _Id; private string _Name;

        #endregion // Private


        #region Public

        [Column(IsPrimaryKey = true, Storage = "_Id", DbType = "Int NOT NULL", CanBeNull = false)]
        public int Id { get { return _Id; } set { if (_Id != value) { _Id = value; OnPropertyChanged("Id"); } } }


        [Column(Storage = "_Name")]
        public string Name { get { return _Name; } set { if (_Name != value) { _Name = value; OnPropertyChanged("Name"); } } }

        #endregion // Public
    }

    #endregion // Table Type


    #region Table Category

    [Table(Name = "CategoryTable")]
    public class DBCategoryClass : ObservableClass
    {
        #region Private

        private int _Id; private string _Name;

        #endregion // Private


        #region Public

        [Column(IsPrimaryKey = true, Storage = "_Id", DbType = "Int NOT NULL", CanBeNull = false)]
        public int Id { get { return _Id; } set { if (_Id != value) { _Id = value; OnPropertyChanged("Id"); } } }


        [Column(Storage = "_Name")]
        public string Name { get { return _Name; } set { if (_Name != value) { _Name = value; OnPropertyChanged("Name"); } } }

        #endregion // Public
    }

    #endregion // Table Category


    #region Table Contest

    [Table(Name = "ContestTable")]
    public class DBContestClass : ObservableClass
    {
        #region Private

        private int _Id; private string _Name;

        #endregion // Private


        #region Public

        [Column(IsPrimaryKey = true, Storage = "_Id", DbType = "Int NOT NULL", CanBeNull = false)]
        public int Id { get { return _Id; } set { if (_Id != value) { _Id = value; OnPropertyChanged("Id"); } } }


        [Column(Storage = "_Name")]
        public string Name { get { return _Name; } set { if (_Name != value) { _Name = value; OnPropertyChanged("Name"); } } }

        #endregion // Public
    }

    #endregion // Table Contest


    #region Table PP

    [Table(Name = "PPTable")]
    public class DBPPClass : ObservableClass
    {
        #region Private

        private int _Id, _Number;

        #endregion // Private


        #region Public

        [Column(IsPrimaryKey = true, Storage = "_Id", DbType = "Int NOT NULL", CanBeNull = false)]
        public int Id { get { return _Id; } set { if (_Id != value) { _Id = value; OnPropertyChanged("Id"); } } }


        [Column(Storage = "_Number")]
        public int Number { get { return _Number; } set { if (_Number != value) { _Number = value; OnPropertyChanged("Number"); } } }

        #endregion // Public
    }

    #endregion // Table PP


    #region Table Power

    [Table(Name = "PowerTable")]
    public class DBPowerClass : ObservableClass
    {
        #region Private

        private int _Id, _Number;

        #endregion // Private


        #region Public

        [Column(IsPrimaryKey = true, Storage = "_Id", DbType = "Int NOT NULL", CanBeNull = false)]
        public int Id { get { return _Id; } set { if (_Id != value) { _Id = value; OnPropertyChanged("Id"); } } }


        [Column(Storage = "_Number")]
        public int Number { get { return _Number; } set { if (_Number != value) { _Number = value; OnPropertyChanged("Number"); } } }

        #endregion // Public
    }

    #endregion // Table Power


    #region Table Accuracy

    [Table(Name = "AccuracyTable")]
    public class DBAccuracyClass : ObservableClass
    {
        #region Private

        private int _Id, _Number;

        #endregion // Private


        #region Public

        [Column(IsPrimaryKey = true, Storage = "_Id", DbType = "Int NOT NULL", CanBeNull = false)]
        public int Id { get { return _Id; } set { if (_Id != value) { _Id = value; OnPropertyChanged("Id"); } } }


        [Column(Storage = "_Number")]
        public int Number { get { return _Number; } set { if (_Number != value) { _Number = value; OnPropertyChanged("Number"); } } }

        #endregion // Public
    }

    #endregion // Table Accuracy

    #endregion
}