using System.Text;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Data;
using System.Runtime.InteropServices;
using System.Reflection;

namespace LibProject
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow: Window
	{
		class Konyv
		{
			public string szerzo{get;set;}
			public string cim{get;set;}
			public int kiadaseve{get;set;}
			public string isbn{get;set;}
			public string allapot{get;set;}

            public Konyv(string author, string title, int relYear, string iSBN, string state)
			{
				szerzo = author;
				cim = title;
                kiadaseve = relYear;
				isbn = iSBN;
				allapot = state;
			}
		}
		public MainWindow()
		{
			InitializeComponent();

            //Üres itemsource hogy a táblázat fejlécei megjelennjenek az adatok betöltése előtt is
            var dummylist = new List<Konyv>();
            libgrid.ItemsSource = dummylist;
        }

        private void btn_load_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "server=localhost;user=root;password=;database=konyvtar;";
            string query = "SELECT * FROM konyvek";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    libgrid.ItemsSource = dataTable.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt: " + ex.Message);
            }
        }

		private void btn_delete_Click(object sender, RoutedEventArgs e)
		{
            string connectionString = "server=localhost;user=root;password=;database=konyvtar;";
			string delete = "DELETE FROM konyvek WHERE isbn='" + txt_isbn.Text + "'";


            try {

                using (MySqlConnection connection = new MySqlConnection(connectionString))
				{
                    MySqlDataAdapter adapter = new MySqlDataAdapter(delete, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);


                }

            } catch (Exception ex)
			{
				MessageBox.Show("Hiba történt " + ex.Message);

			}
            btn_load_Click(sender, e);
            

        }

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
             string connectionString = "server=localhost;user=root;password=;database=konyvtar;";
            string query = "SELECT * FROM `konyvek` WHERE cim = '" + txt_isbn.Text + "'";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    libgrid.ItemsSource = dataTable.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt: " + ex.Message);
            }


        }

        private void Hozza_adas_btn_Click(object sender, RoutedEventArgs e)
        {
            if (szerzo_txtbox.Text != "" & cim_txtbox.Text != "" & kiadaseve_txtbox.Text != "" & isbn_txtbox.Text != "" & allapot_txtbox.Text != "")
            {
                // int.TryParse nak problémái voltak
                bool kiadasisnum = false;
                bool goodisbn = false;
                bool isbnhas_ = false;
                bool isnnhasnum = false;
                bool goodallapot = false;
                                    
                try
                {
                    int.Parse(kiadaseve_txtbox.Text);
                    kiadasisnum = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Kérem számot agyon meg évnek!");
                }
                {
                    foreach (char letter in isbn_txtbox.Text)
                    {
                        if (letter == '-') isbnhas_ = true;
                        if ((int)char.GetNumericValue(letter) != -1) isnnhasnum = true;

                    }
                    if (isnnhasnum & isbnhas_) goodisbn = true;

                    if (!goodisbn) MessageBox.Show("Kérem valid isbn-t agyon meg!");

                    if (allapot_txtbox.Text == "Olvasott" || allapot_txtbox.Text == "Olvasatlan")
                    {
                        goodallapot = true;
                    } else
                    {
                        MessageBox.Show("Kérem 'Olvasott' vagy 'Olvasatlan' t agyon meg álapotnak");
                    }


                    if (kiadasisnum & goodisbn & goodallapot)
                    {
                        string connectionString = "server=localhost;user=root;password=;database=konyvtar;";
                        string query = "INSERT INTO konyvek (szerzo, cim, kiadas_eve, isbn, allapot) VALUES (@szerzo, @cim, @kiadas_eve, @isbn, @allapot)";
                        try
                        {
                            using (MySqlConnection connection = new MySqlConnection(connectionString))
                            {
                                connection.Open();
                                using (var cmd = new MySqlCommand(query, connection))
                                {
                                    cmd.Parameters.AddWithValue("@szerzo", szerzo_txtbox.Text);
                                    cmd.Parameters.AddWithValue("@cim", cim_txtbox.Text);
                                    cmd.Parameters.AddWithValue("@kiadas_eve", kiadaseve_txtbox.Text);
                                    cmd.Parameters.AddWithValue("@isbn", isbn_txtbox.Text);
                                    cmd.Parameters.AddWithValue("@allapot", allapot_txtbox.Text);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Hiba történt: " + ex.Message);
                        }
                        btn_load_Click(sender, e);
                    }







                }
            }
            else
            {
                MessageBox.Show("Minden mezőt töltsön ki!");

            }
        } 

        }
    }

