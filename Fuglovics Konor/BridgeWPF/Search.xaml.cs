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

namespace BridgeWPF
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Window
    {
		MainWindow mainwindow = new();
        public Search(MainWindow main)
        {
            InitializeComponent();
			main = mainwindow;
        }
		private void SearchBridges(object sender, RoutedEventArgs e)
		{
			var cnt = country.SelectedItem.ToString();
			var result = MainWindow.bridges.Where(b => b.Country == cnt).Select(b => b.Name);
			searchresult.Text = string.Join("\n", result);
		}
		private void Quit(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			var countries = MainWindow.bridges.Select(b => b.Country).ToHashSet();
			country.ItemsSource = countries;
		}
	}
}
