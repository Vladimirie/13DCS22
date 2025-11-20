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

namespace autoversen;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
/// 

class Car {
    public string Team { get; set; }
    public string Racer { get; set; }

    public int Eletktor { get; set; }
    public string Track { get; set; }

    public DateTime Korido { get; set; }
    public int Kor { get; set; }

    public Car(string team, string racer, int eletktor, string track, DateTime korido, int kor)
    {
        Team = team;
        Racer = racer;
        Eletktor = eletktor;
        Track = track;
        Korido = korido;
        Kor = kor;
    }
}

public partial class MainWindow : Window
{
    List<Car> cars = new List<Car>();
    public MainWindow()
    {
        InitializeComponent();
        //2
        List<string> fileRead = new List<string>(File.ReadLines("autoverseny.csv"));
        
        fileRead.RemoveAt(0);
        int adatlinecout = 0;
        foreach (string line in fileRead)
        {

            string[] split = line.Split(";");
            cars.Add(new Car(split[0], split[1], int.Parse(split[2]), split[3], DateTime.Parse(split[4]), int.Parse(split[5])));


            adatlinecout++;

        }
        //3
        MessageBox.Show($"{adatlinecout} sornyi adat található a fájlban");
        //4

        foreach(Car car in cars)
        {
            if (car.Racer == "Fürge Ferenc" && car.Track == "Gran Prix Circuit" &&  car.Kor == 3)
            {

                int minut = car.Korido.Minute;
                int time = minut * 60 + car.Korido.Second;
              
                MessageBox.Show($"{time.ToString()} Másodperc");

            }
        }



    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        //5
        string nev = INVISIBLE.Text;
        bool found = false;
        int min = 999999;
        DateTime bestime = cars[0].Korido;
        string besttrack = "+";
        foreach (Car car in cars) {
            int rtime = car.Korido.Second + car.Korido.Minute * 60;
            if (car.Racer == nev && rtime <  min )
            {
                found = true;
                min = rtime;
                bestime = car.Korido;
                besttrack = car.Track;


            }

        }

        string s = bestime.ToString();
        string[] split =  s.Split('.');



        if (found ) {
            MessageBox.Show($"{besttrack}   {split[3]}");
        } else
        {
            MessageBox.Show("Nem található ilyen nevü versenyző");
        }


    }

}