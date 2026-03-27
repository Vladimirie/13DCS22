using System.Diagnostics.Metrics;
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

namespace VideogamesGUI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
    {
		private static List<VideoGames> _db = [];
		private static SortedDictionary<string, int> _devs = [];
		public MainWindow()
        {
            InitializeComponent();
			foreach(var data in File.ReadAllLines("Video_Jatek_Eladasok.txt").Skip(1))
			{
				string[] line = data.Split("|");
				_db.Add(new VideoGames(line[0], line[1], line[2], line[3], line[4], double.Parse(line[5]), double.Parse(line[6]), int.Parse(line[7])));
			}
			games.ItemsSource = _db;
        }

		private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (games.SelectedItem is VideoGames selected)
			{
				pub.Content = selected.Publisher.ToString();
				dev.Content = selected.Developer.ToString();
				score.Content = selected.CriticScore.ToString();
			}
		}

		private void MostGames(object sender, RoutedEventArgs e)
		{
			/*var mostgames = _db	//Valamiért leáll az egész applikáció...
				.GroupBy(a => a.Developer)
				.Select(a => a.Key);
			MessageBox.Show(string.Join("\n", mostgames));*/
			var mostgames = _db.Where(a => a.Developer != "Unknown").GroupBy(a => a.Developer).Select(dev => new { A = dev.Key, B = dev.Count() }).OrderBy(x => x.B);
			var sol = mostgames.Last();
			MessageBox.Show($"Fejlesztö: {sol.A}\nJátékok: {sol.B}db");
		}

		private void Search(object sender, RoutedEventArgs e)
		{
			Window1 init = new();
			init.ShowDialog();
		}
	}
}