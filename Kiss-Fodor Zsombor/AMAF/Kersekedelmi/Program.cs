namespace Kersekedelmi
{

    //classok létrehozása 1. feladat
    class Kolonia
    {
        public string Azonosito { get; set; }
        public string Nev { get; set; }
        public string Szektor { get; set; }

        public Kolonia(string azonosito, string nev, string szektor)
        {
            Azonosito = azonosito;
            Nev = nev;
            Szektor = szektor;
        }

        public override string ToString()
        {
            return $"Kolónia neve: {Nev}. Azonosítója: {Azonosito}. Szektor neve: {Szektor}";
        }
    }

    class Szallitas
    {
        public Kolonia Forras { get; set; }
        public Kolonia Cel { get; set; }
        public int Mennyiseg { get; set; }
        
        public Szallitas(Kolonia forras, Kolonia cel, int mennyiseg)
        {
            Forras = forras;
            Cel = cel;
            Mennyiseg = mennyiseg;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            2. feladat – Két fájlt kell beolvasni:

            1. Olvasd be a kolóniákat és tárold olyan adatszerkezetben, amelyben gyorsan megtalálod egy kolónia objektumát azonosító alapján.
            2. Olvasd be a szállításokat és hozd létre a Szallitas objektumokat.
            */
            Dictionary<string, Kolonia> koliniak = new Dictionary<string, Kolonia>();
            string koloniaFile = "kolonia.csv";

            foreach (var kolonia in File.ReadAllLines(koloniaFile)) 
            {
                string[] s = kolonia.Split(";");
                string azon = s[0];
                string nev = s[1];
                string szektor = s[2];
                koliniak.Add(s[0], new Kolonia(azon, nev, szektor));
            }

            List<Szallitas>

            /*foreach (var koli in koliniak)
            {
                Console.WriteLine(koli);
            }*/



            /*
            3. feladat – Készíts olyan metódusokat vagy kódrészeket, amelyek:

            1. Kilistázzák minden kolóniát, és megadják, hány szállításban vett részt (forrásként vagy célként).
            2. Megkeresik a legforgalmasabb kolóniát (amely a legtöbb tonnát szállított be + ki összesen).
            3. Szektoronként add meg:
                o hány szállítás történt,
                o és mennyi az összes árumennyiség (tonnában).
             */

            /*
            4. feladat – Rendezd a kolóniákat:
            • összes árumennyiség szerint csökkenő sorrendbe,
            • azonos érték esetén név szerint növekvőbe.

            Ehhez használd az IComparable<Kolonia> interfészt vagy készíts saját IComparer<Kolonia> osztályt.
             */
        }
    }
}