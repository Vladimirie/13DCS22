using System.IO;
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

namespace Olimpia2020GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
		private static List<Olimpia> _adatok = [];
		public MainWindow()
        {
			InitializeComponent();
        }
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			foreach (var fájl in File.ReadAllLines("Olimpia2020.csv").Skip(1))
			{
				string[] sor = fájl.Split(",");
				_adatok.Add(new Olimpia(sor[0], int.Parse(sor[1]), int.Parse(sor[2]), int.Parse(sor[3]), int.Parse(sor[4])));
			}
			országok.ItemsSource = _adatok;
		}

		private void országok_kiválasztva(object sender, SelectionChangedEventArgs e)
		{
			if(országok.SelectedItem is Olimpia kiválasztva)
			{
				arany.Content = kiválasztva.Arany.ToString();
				ezüst.Content = kiválasztva.Ezüst.ToString();
				bronz.Content = kiválasztva.Bronz.ToString();
			}
		}

		private void Magyar_érmek(object sender, RoutedEventArgs e)
		{

		}
	}
}