using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RealEstateGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
		public static List<Seller> sellers = new List<Seller>();
		private readonly RealEstateDBContext _db;
        public MainWindow()
        {
            InitializeComponent();
			_db = new RealEstateDBContext();
        }
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			sellers = _db.Sellers.ToList();
			sellerlist.ItemsSource = sellers;
		}

		private void sellerlist_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if(sellerlist.SelectedItem is Seller selected)
			{
				textsellername.Text = selected.Name.ToString();
				textsellerphone.Text = selected.Phone.ToString();
			}
		}

		private void LoadAds(object sender, RoutedEventArgs e)
		{
			/*var result = _db.Sellers
				.Join(_db.RealEstates, s => s.ID, r => r.SellerID, (s,r) => s.ID).Count();
			textadverts.Text = result.ToString();*/
		}
	}
}