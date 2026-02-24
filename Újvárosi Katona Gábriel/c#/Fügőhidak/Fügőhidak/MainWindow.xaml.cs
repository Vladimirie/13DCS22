using Microsoft.Win32;
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
using System.IO;

namespace Fügőhidak
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<Fugohid> hidak = new List<Fugohid>();  
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Menumegniytas_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV féjlok (*.csv) |*.csv|Minden fájlok KURVAAA(*.*)|*.*";
            if (ofd.ShowDialog() == true) {
                try
                {
                    string[] sorok = File.ReadAllLines(ofd.FileName);
                    hidak.Clear();
                    List<Fugohid> hiddak = new List<Fugohid>();
                    for (int i = 1; sorok.Length > i; i++)
                    {
                        string[] s = sorok[i].Split('	');

                        hidak.Add( new Fugohid(int.Parse(s[0]), s[1], s[2], s[3], int.Parse(s[4]), int.Parse(s[5])));
                        
                    
                    }
                    lbHidak.ItemsSource = hidak;
                } catch (Exception ex )
                {
                    MessageBox.Show("Hiba a fájl belovasáskor" + ex.Message, "hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                    
                }
            }
        }

        private void MenuKereses_Click(object sender, RoutedEventArgs e)
        {

        }

        private void lbHidak_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}