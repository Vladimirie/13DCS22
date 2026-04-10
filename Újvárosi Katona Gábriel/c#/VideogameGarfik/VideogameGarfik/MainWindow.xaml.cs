using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.IO;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VideogameGarfik
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<VideoGame> videoGames = new List<VideoGame>();
        public MainWindow()
        {
            InitializeComponent();

            List<string> lines = File.ReadLines("Video_Jatek_Eladasok.txt").ToList();
           
            lines.RemoveAt(0);

            foreach (string line in lines)
            {

                string[] split = line.Split('|');

                videoGames.Add(new VideoGame(split[0], split[1], split[2], split[3], split[4], double.Parse(split[5]), double.Parse(split[6]), int.Parse(split[7])));



            }

            datalist.ItemsSource = videoGames.ToList();

        }

        private void idk_Click(object sender, RoutedEventArgs e)
        {
            string fejleszto = videoGames.GroupBy(g => g.Fejleszto) .OrderByDescending(g => g.Count()).First().Key.ToString();
            gamecount.Content = videoGames.Where(g => g.Fejleszto == fejleszto).Select(g => g).Count();
            legtermekenyebb.Content = fejleszto;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
                Kereses kereses = new Kereses();
            kereses.ShowDialog();
            this.Show();
        }
    }
}