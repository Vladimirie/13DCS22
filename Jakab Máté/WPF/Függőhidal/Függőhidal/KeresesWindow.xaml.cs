using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Fuggohidak
{
    public partial class KeresesWindow : Window
    {
        List<Fuggohid> hidak;

        public KeresesWindow(List<Fuggohid> lista)
        {
            InitializeComponent();
            hidak = lista;

            var orszagok = hidak
                .Select(h => h.Orszag)
                .Distinct()
                .OrderBy(o => o)
                .ToList();

            cbOrszag.ItemsSource = orszagok;
        }

        private void Kereses_Click(object sender, RoutedEventArgs e)
        {
            if (cbOrszag.SelectedItem == null) return;

            string orszag = cbOrszag.SelectedItem.ToString();

            var talalatok = hidak
                .Where(h => h.Orszag == orszag)
                .Select(h => h.Nev);

            txtEredmeny.Text = string.Join("\n", talalatok);
        }

        private void Bezaras_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
