using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace VideogameGarfik
{
    /// <summary>
    /// Interaction logic for Kereses.xaml
    /// </summary>
    public partial class Kereses : Window
    {
        List<VideoGame> videoGames = new List<VideoGame>();
        public Kereses()
        {
            InitializeComponent();
            List<string> lines = File.ReadLines("Video_Jatek_Eladasok.txt").ToList();

            lines.RemoveAt(0);

            foreach (string line in lines)
            {

                string[] split = line.Split('|');

                videoGames.Add(new VideoGame(split[0], split[1], split[2], split[3], split[4], double.Parse(split[5]), double.Parse(split[6]), int.Parse(split[7])));



            }
            

            pub.ItemsSource = videoGames.ToHashSet();
            mufaj.ItemsSource = videoGames.ToHashSet();
        }
        



        private void pub_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var game = (VideoGame)((Selector)sender).SelectedItem;

            kereslist.ItemsSource = videoGames.Where(g => g.Kiado ==  game.Kiado).ToList();
        }

        private void mufaj_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var game = (VideoGame)((Selector)sender).SelectedItem;
            kereslist.ItemsSource = videoGames.Where(g => g.Mufaj == game.Mufaj ).ToList();
        }
    }
}
