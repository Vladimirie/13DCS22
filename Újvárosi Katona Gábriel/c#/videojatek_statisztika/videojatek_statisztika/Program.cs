using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace videojatek_statisztika
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<string> lines = File.ReadLines("Video_Jatek_Eladasok.txt").ToList();
            List<VideoGame> videoGames = new List<VideoGame>();
            lines.RemoveAt(0);

            foreach (string line in lines) {

                string[] split = line.Split('|');

                videoGames.Add(new VideoGame(split[0], split[1], split[2], split[3], split[4], double.Parse(split[5]), double.Parse(split[6]), int.Parse(split[7]) ) );


            }

            Console.WriteLine($"3 mas feladat: összesen {videoGames.Count()} játék szerepel a forrás állományban");

            int kritcount = 0;
            foreach (VideoGame videoGame in videoGames)
            {
                if (videoGame.Kritikusi_pontszam >= 9.5)
                {
                    kritcount++;
                }
                
            }
            Console.WriteLine($"4 es feladat: összesen {kritcount} videójáték szerepel a rendszerben amelynek  a kritikusi pontszáma legalább 9.5");

            double maxsale = videoGames[0].Osszes_eladas;
            int maxindex = 0;

            for (int i = 0; i < videoGames.Count; i++) { 
            
                if (videoGames[i].Osszes_eladas > maxsale)
                {
                    maxsale = videoGames[i].Osszes_eladas;
                    maxindex = i;
                }
            }
            Console.WriteLine($"5 ös feladat: a legtöbbet eladtott játék: {videoGames[maxindex].Nev + " "  + videoGames[maxindex].Konzol + " " + videoGames[maxindex].Osszes_eladas + " " + videoGames[maxindex].Kritikusi_pontszam}");


            string bekertadat = Console.ReadLine();

            VideoGame game = videoGames.Where(b => b.Kiado == bekertadat).OrderBy(f => f.Kiadas_eve).FirstOrDefault();

            if (game != null)
            {

                

                  Console.WriteLine($"6 os feladat: {game.Nev + " " + game.Kiadas_eve}");

            }
            else {

                Console.WriteLine("6 os feladat: A megadott kiadó nem található az \r\nadatbázisban.");
            }

            Console.WriteLine($" 7 es feladat:  { videoGames.Where(g => g.Mufaj == "Akció").Select(g => g).Count()}");



        }
    }
}
