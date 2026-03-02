namespace LINQ_filmes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var db = new FilmekDBContext();

            /*
            1. Színes filmek: Listázd ki az összes olyan film címét, amelyik "színes"!
            2. Hosszú filmek: Mely filmek hosszabbak 120 percnél? A listát rendezd csökkenő sorrendbe hossz szerint.
            3. Élő alkotók: Kérd le azon alkotók nevét, akiknél nincs kitöltve az elhunyt dátum (feltételezzük, hogy élnek), 
            és születésük szerint rendezd őket növekvő sorrendbe (a legidősebb elöl).
            4. Animációs kor: Írasd ki a legkorábban (legkisebb évszám) készült animációs film címét és évszámát.
            5. Adott év: Hány film készült az 1970-es évben?
            */
            //    SELECT `nev` FROM `filmek` Where filmek.szines = "színes";
            var szines = db.Filmek.Where(f => f.Szines == "színes").Select(f => f.Cim).ToList();
            Console.WriteLine("2 es feladat " + string.Join("\n", szines));
        }
    }
}
