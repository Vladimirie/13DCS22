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
using System.Diagnostics;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.IO;
using System.Data;
using Org.BouncyCastle.Crypto.Modes.Gcm;

namespace AdminPanel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //
        string version = "0.1.1";
        DateTime currentTime = DateTime.Today;

        //megkapjuk az alap adatatok az adatbázishoz
        string Server = "localhost";
        string uid = "root";
        string Password = "";
        string DataBase = "restaurant";

        //0 semmilyen teszt, 1 UI teszt csak ezért a DB dolgok nem fognak működni
        int TestingType = 1;    

        //más fontos változók
        Dictionary<string, string> tables = new Dictionary<string, string>();

        public MainWindow()
        {
            InitializeComponent();

            if (TestingType == 0)
            {
                //program háttérbeli elindítása
                bool canProgress = DatabaseCheck();

                //megnézzük sikerült-e az adatbázishoz csatlakozás
                if (canProgress) //ha sikeres a csatlakozás
                {
                    TableButtonStart();
                    ReadCommands();
                    //SizeFit();
                }
                else //ha nem sikeres
                {
                    if (MessageBox.Show(
                        "Nem lehetett csatlakozni az adatbázishoz!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error)
                        == MessageBoxResult.OK)
                    {
                        Close();
                    }
                }
            }
            else
            {
                MessageBox.Show($"Éppen teszt módban van ez a program! Teszt Kód: {TestingType}", "Figyelem!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                TableButtonStart();
            }

            //beállítjuk a verziót és a mai napot
            Versin.Content = $"V{version} {currentTime.Year}.{currentTime.Month}.{currentTime.Day}";
        }

        //-----------------Indításkor lejátszodó kódok
        //itt megnézzük megy-e a csatalkozás a databasehez és visszatérünk az eredményével
        //ezzel megtudjuk le tudjuk-e futtatni a program többi részét zökkenőmentesen
        private bool DatabaseCheck()
        {
            try
            {
                //megproóbálunk csatlakozni a szerverhez
                string conString = "server=" + Server + ";uid=" + uid + ";pwd=" + Password;
                MySqlConnection con = new MySqlConnection(conString);
                con.Open();

                //ha nincs egy "restaurant" adatbázis akkor megcsináljuk
                string createDB = "CREATE DATABASE IF NOT EXISTS " + DataBase;
                MySqlCommand cmd = new MySqlCommand(createDB, con);
                int i = cmd.ExecuteNonQuery();

                return true; //sikeres a csatlakozás
            }
            catch
            {
                return false; //nem sikeres a csatlakozás
            }              
        }

        //megkeressük a "tables" nevű dropdown gombot és feltöltjük a megfelelő adatokkal
        private void TableButtonStart()
        {
            //a táblázataink és hozzátartozó kulcs-érték pár (felhaszánlónak kiírt név és SQL név)
            tables.Add("Allergének", "allergens");
            tables.Add("Italok", "drinks");
            tables.Add("Összetevők", "ingredients");
            tables.Add("Kínálat", "items");
            tables.Add("Kombó Kínálat", "comboItems");
            tables.Add("Dolgozók", "workers");
            tables.Add("Rendelések", "ongoingOrders");
            tables.Add("Kész rendelések", "completedOrders");

            //dropdown gombnak adatát a tables kulcs-érték párokkal feltöltjük és az első tagját írjuk ki
            TableBox.ItemsSource = tables.Keys;
            TableBox.SelectedIndex = 0;
        }

        //beolvassuk az SQL parancsokat majd tovább küldjük egy másik metódusnak
        private void ReadCommands()
        {
            string[] tableCommands = File.ReadAllLines("DataBaseCommands.txt");
            SendTablesAndRecords(tableCommands);
        }


        //az SQL parancsok lefuttatása a "restaurants" adatbázisnak
        private void SendTablesAndRecords(string[] tableCommands)
        {
            //csatlakozunk az adatbázishoz
            string conString = "server=" + Server + ";uid=" + uid + ";pwd=" + Password + ";database=" + DataBase;
            MySqlConnection con = new MySqlConnection(conString);
            con.Open();

            //lefutatjuk a paracsonkat
            foreach (string command in tableCommands)
            {
                //ha van valami beleírva a sorokba akkor futtassa csak le a kódot
                //így a beolvasandó kód sokkal de sokkal átláthatób és nem okozik problémát futáskor
                if (command != "")
                {
                    string createTable = command;
                    MySqlCommand cmd = new MySqlCommand(createTable, con);
                    int i = cmd.ExecuteNonQuery();
                }            
            }
        }

        private void SizeFit()
        {
            //még nem használt
        }

        //-----------------Bármikor lejátszodó kódok
        //Gombok Függvényei
        private void OpenAllPrograms(object sender, RoutedEventArgs e)
        {
            //megpróbáljuk a külső programokat elindítani
            //majd csinálni kell egy "Demo", "Éles" és "Hibrid" mód kapcsolót
            if (TestingType == 0)
            {           
                try
                {
                    Process.Start(@"..\..\..\..\..\Konor\KIOSK\KIOSK\bin\Debug\KIOSK.exe"); //KIOSZK program
                }
                catch
                {
                    MessageBox.Show("Nem lehetett elindítnai a programokat!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }       
        }

        private void ShowDataBase(object sender, RoutedEventArgs e)
        {
            if (TestingType == 0)
            {
                //megmutatja azt a táblázatot amit a TablexBox combobox elemből választottunk ki
                string tableToCall = tables[TableBox.SelectedItem.ToString()];

                string conString = "server=" + Server + ";uid=" + uid + ";pwd=" + Password + ";database=" + DataBase;

                string showT = "SELECT * FROM " + tableToCall;
                MySqlConnection connection = new MySqlConnection(conString);
                MySqlCommand cmdSel = new MySqlCommand(showT, connection);
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmdSel);
                da.Fill(dt);

                TableGrid.DataContext = dt;
            }
        }

        private void TableBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //szerintem nem lesz használva
        }
    }
}
