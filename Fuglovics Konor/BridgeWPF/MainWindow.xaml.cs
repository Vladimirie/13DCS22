using Microsoft.Win32;
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

namespace BridgeWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
	
    public partial class MainWindow : Window
    {
		public static List<Bridge> bridges = new();
        public MainWindow()
        {
            InitializeComponent();

        }

		private void Open(object sender, RoutedEventArgs e)
		{
			OpenFileDialog open = new();
			open.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
			if(open.ShowDialog() == true)
			{
				try
				{
					string[] line = File.ReadAllLines(open.FileName);
					bridges.Clear();
					for(int i = 1; i < line.Length; i++)
					{
						string[] data = line[i].Split("\t");
						Bridge bridge = new(int.Parse(data[0]), data[1], data[2], data[3], int.Parse(data[4]), int.Parse(data[5]));
						bridges.Add(bridge);
					}
					listbridge.ItemsSource = null;
					listbridge.ItemsSource = bridges;
					MessageBox.Show("File has been read", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
				}
				catch (Exception ex)
				{
					MessageBox.Show($"An error occured: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
		}

		private void Search(object sender, RoutedEventArgs e)
		{
			Search search = new(this);
			this.Hide();
			search.ShowDialog();
			this.Show();
		}

		private void Quit(object sender, RoutedEventArgs e)
		{
			if (MessageBox.Show("Do you wanna quit from this program?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
			{
				Application.Current.Shutdown();
			}
			
		}

		private void rad_before2k_isChecked(object sender, RoutedEventArgs e)
		{
			var count = bridges.Count(b => b.Year < 2000);
			amt.Text = count.ToString();
		}

		private void rad_after2k_isChecked(object sender, RoutedEventArgs e)
		{
			var count = bridges.Count(b => b.Year >= 2000);
			amt.Text = count.ToString();
		}
	}
}