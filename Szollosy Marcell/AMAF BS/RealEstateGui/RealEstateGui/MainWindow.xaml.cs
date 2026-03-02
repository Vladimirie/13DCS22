using System.Windows;

public partial class MainWindow : Window
{
    MySqlConnection conn;

    public MainWindow()
    {
        InitializeComponent();

        string connStr = "server=localhost;database=ingatlan;user=root;password=;";
        conn = new MySqlConnection(connStr);
        conn.Open();

        var cmd = new MySqlCommand("SELECT * FROM sellers", conn);
        var reader = cmd.ExecuteReader();
        List<Seller> sellers = new List<Seller>();

        while (reader.Read())
        {
            sellers.Add(new Seller(
                reader.GetInt32("id"),
                reader.GetString("name"),
                reader.GetString("phone")
            ));
        }

        reader.Close();

        listBoxsellers.ItemsSource = sellers;
    }

    private void BtnLoadAds_Click(object sender, RoutedEventArgs e)
    {
        var selected = (seller)listBoxsellers.SelectedItem;

        var cmd = new MySqlCommand(
            "SELECT COUNT(*) FROM ads WHERE sellerId=@id", conn);

        cmd.Parameters.AddWithValue("@id", selected.Id);

        int count = Convert.ToInt32(cmd.ExecuteScalar());

        lblAdCount.Content = count.ToString();
    }
}