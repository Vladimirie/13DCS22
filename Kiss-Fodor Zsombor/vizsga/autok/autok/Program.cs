namespace autok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Auto> KocsiLista = new List<Auto>();

            Beolvas(KocsiLista, "autok.csv");
            Console.WriteLine("5. feladat: " + KocsiLista.Count + " autó található a listában");
            Console.WriteLine("6. feladat: Az autók esetében az átlagosan eladott darabszám " + AtlagKalk(KocsiLista));
            Console.WriteLine("7. feladat: Az elmúlt 5 évben gyártott autók:");
            UjjKocsi(KocsiLista);
            Console.WriteLine("8. feladat: Legsikeresebb márkák listája az eladott darabszám alapján:");
            Szorti(KocsiLista);
        }

        static void Beolvas(List<Auto> list, string readable)
        {
            string[] falj = File.ReadAllLines(readable);

            for (int i = 1; i < falj.Length; i++) //így átugorjuk az első sort
            {
                string[] s = falj[i].Split(';');
                list.Add(new Auto(int.Parse(s[0]), s[1], s[2], int.Parse(s[3]), s[4], int.Parse(s[5]), int.Parse(s[6])));
            }
        }

        static float AtlagKalk(List<Auto> list)
        {
            float atlag = 0;

            foreach (Auto kocsiAdat in list) {
                atlag += kocsiAdat.amount;
            }

            atlag = atlag / list.Count;
            atlag = MathF.Round(atlag, 1);
            return atlag;
        }

        static void UjjKocsi(List<Auto> list) { 
            foreach (Auto kocsiAdat in list)
            {
                if (2025 - kocsiAdat.year <= 5)
                {
                    Console.WriteLine("\t -" + kocsiAdat.make + " " + kocsiAdat.model + ": " + kocsiAdat.year);
                }
            }
        }

        static void Szorti(List<Auto> list)
        {
            bool sorted = false;

            
           
               for (int i = 0; i < list.Count; i++) {
                    for (int j = 0; j < list.Count - 1; j++)
                    {
                        if (list[j].amount < list[j + 1].amount)
                        {
                            Auto temp = list[j];

                            list[j] = list[j + 1];
                            list[j + 1] = temp;
                        }
                    }
               }
            

            foreach (Auto kocsiAdat in list)
            {
                Console.WriteLine("\t- " + kocsiAdat.make + ": "+ kocsiAdat.amount+" darab");
            }
        }
    }
}
