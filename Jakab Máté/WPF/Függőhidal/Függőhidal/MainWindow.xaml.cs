using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Fuggohidak
{
    public partial class MainWindow : Window
    {
        List<Fuggohid> hidak = new List<Fuggohid>();

        public MainWindow()
        {
            InitializeComponent();
        }

        // FÁJL MEGNYITÁS
        private void Megnyitas_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV fájl (*.csv)|*.csv";

            if (ofd.ShowDialog() == true)
            {
                hidak.Clear();
                lbHidak.Items.Clear();

                var sorok = File.ReadAllLines(ofd.FileName, System.Text.Encoding.UTF8);

                for (int i = 1; i < sorok.Length; i++) // fejléc kihagyása
                {
                    var adatok = sorok[i].Split('\t');

                    Fuggohid uj = new Fuggohid
                    {
                        Helyezes = int.Parse(adatok[0]),
                        Nev = adatok[1],
                        Hely = adatok[2],
                        Orszag = adatok[3],
                        Hossz = int.Parse(adatok[4]),
                        AtadasEve = int.Parse(adatok[5])
                    };

                    hidak.Add(uj);
                }

                lbHidak.ItemsSource = hidak;
            }
        }

        // LISTBOX KIVÁLASZTÁS
        private void lbHidak_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbHidak.SelectedItem is Fuggohid kivalasztott)
            {
                txtHely.Text = kivalasztott.Hely;
                txtOrszag.Text = kivalasztott.Orszag;
                txtHossz.Text = kivalasztott.Hossz.ToString();
                txtEv.Text = kivalasztott.AtadasEve.ToString();
            }
        }

        // RÁDIÓGOMBOK
        private void Radio_Checked(object sender, RoutedEventArgs e)
        {
            if (rbElott.IsChecked == true)
            {
                lblDarab.Content = hidak.Count(h => h.AtadasEve < 2000);
            }
            else if (rbUtan.IsChecked == true)
            {
                lblDarab.Content = hidak.Count(h => h.AtadasEve >= 2000);
            }
        }

        // KERESÉS ABLAK
        private void Kereses_Click(object sender, RoutedEventArgs e)
        {
            KeresesWindow kw = new KeresesWindow(hidak);
            kw.Owner = this;
            kw.ShowDialog();
        }

        // KILÉPÉS
        private void Kilepes_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
