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
using System.Linq;
using RealEstateGui;

namespace RealEstateGui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<Seller> Zeller = new List<Seller>();
        public MainWindow()
        {
            InitializeComponent();
        }  

        private void LBSellers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using var db = new HouseContext();
            LSellerName.Content =Zeller.Where(s => s.Name == LBSellers.SelectedItem.ToString());
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using var db = new HouseContext();
            Zeller = db.Sellers.ToList();
            LBSellers.ItemsSource = Zeller.Select(s => s.Name);
        }
    }
}