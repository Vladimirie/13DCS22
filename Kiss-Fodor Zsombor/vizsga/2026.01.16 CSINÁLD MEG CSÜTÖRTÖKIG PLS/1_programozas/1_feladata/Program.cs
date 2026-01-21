namespace _1_feladata
{
    internal class Program
    {      
        static void Main(string[] args)
        {
            List<Ad> házak = loadCSV("realestates.csv");
            //Console.WriteLine(házak.Count());
            Console.WriteLine(ElsoFeladat(házak));
            Console.WriteLine(MasodikFeladat(házak));
            //Console.WriteLine(HarmadikFeladat(házak));
        }
        static List<Ad> loadCSV(string filePath)
        {
            List<Ad> adatok = new List<Ad>();
            string[] file = File.ReadAllLines(filePath);
            int indexer = 1;
            while (indexer < file.Length)
            {           
                //little cheat table
                //0: id	
                //1: rooms	
                //2: latlong	
                //3: floors	
                //4: area	
                //5: description	
                //6: freeOfCharge	
                //7: imageUrl	
                //8: createAt	
                //9: sellerId	
                //10: sellerName	
                //11: sellerPhone	
                //12: categoryId	
                //13: categoryName


                string[] splitLine = file[indexer].Split(";");
                Ad house = new Ad(
                    int.Parse(splitLine[4]),
                    new Category(int.Parse(splitLine[12]),
                    splitLine[13]), DateTime.Parse(splitLine[8]),
                    splitLine[5], int.Parse(splitLine[3]),
                    int.Parse(splitLine[0]),
                    splitLine[7],
                    splitLine[2],
                    int.Parse(splitLine[1]),
                    new Seller(int.Parse(splitLine[9]), splitLine[10], splitLine[11]),
                    int.Parse(splitLine[6])
                    );

                adatok.Add(house);
                indexer++; //my dumbass forgot to do this and the add and was wondering why nothing happened lmao
            }
            return adatok;           
        }
        static string ElsoFeladat(List<Ad> adatok)
        {
            double átlag = 0d;
            int házakSzáma = 0;
            foreach (Ad adat in adatok)
            {
                if (adat.Floors == 0 && adat.Category.Name == "ház")
                {
                    házakSzáma++;
                    átlag += adat.Area;
                }
            }
            átlag = Math.Round(átlag / házakSzáma, 2);
            return $"Földszinti ingatlanok átlagos alapterülete: {átlag} m2";
        }

        static string MasodikFeladat(List<Ad> adatok)
        {
            List<KeyValuePair<int, float>> távolságok = new List<KeyValuePair<int, float>>();
            foreach (Ad adat in adatok)
            {
                if (adat.Free == 0)
                {
                    float távolság = DistanceTo(adat.LatLong, 47.4164220114023f, 19.066342425796986f);
                    KeyValuePair<int, float> házAdat = new KeyValuePair<int, float>(adat.Id, távolság);
                    távolságok.Add(házAdat);
                }             
            }
            //float legközelebbi =;

            return $"";
        }

        static float DistanceTo(string latLong, float lati, float longi)
        {
                
            float a = 0f;             
            float b = 0f;
                
            string[] latiLongiread = latLong.Split(",");
                
            //float[] latiLong = { float.Parse(latiLongiread[0]), float.Parse(latiLongiread[1])};
                
            if (float.Parse(latiLongiread[0]) > lati) 
            {           
                a = float.Parse(latiLongiread[0]) - lati;    
            }       
            else
            {          
                a = lati - float.Parse(latiLongiread[0]);              
            }

            if (float.Parse(latiLongiread[1]) > longi)
                
            {
                b = float.Parse(latiLongiread[1]) - longi;
            }
            else
            {
                b = longi - float.Parse(latiLongiread[1]);
            }

            float c = Pitegorasz(a, b);

            return c;
        } 

        static float Pitegorasz(float a, float b)
        {
            double cSq = (a * a) + (b * b);
            Console.WriteLine(cSq);
            float c = (float)Math.Sqrt(cSq); //this should make it into a float without issue idk
            Console.WriteLine(c);
            return c;
        }
      
    }
}
