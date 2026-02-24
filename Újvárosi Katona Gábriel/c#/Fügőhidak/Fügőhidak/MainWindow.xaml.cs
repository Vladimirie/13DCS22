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
                    for (int i = 1; sorok.Length > i; i++)
                    {
                        string[] s = sorok[i].Split('	');
                    int helyezes =  int.Parse(s[0]);
                    string nev = s[1];
                        
                    
                    }
                } catch (Exception efas )
                {
                    MessageBox.Show("Hiba a fájl belovasáskor" + efas.Message, "hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                    
                }
            }
        }

        private void MenuKereses_Click(object sender, RoutedEventArgs e)
        {

        }

        private void lHibák_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}