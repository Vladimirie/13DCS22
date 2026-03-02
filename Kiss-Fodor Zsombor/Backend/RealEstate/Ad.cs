using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate
{
    internal class Ad
    {
        public int Area { get; set; }
        public Category Category { get; set; }
        public DateTime CreateAt { get; set; }
        public string Description { get; set; }
        public int Floors { get; set; }
        public bool FreeOfCharge { get; set; }
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string LatLong { get; set; }
        public int Rooms { get; set; }
        public Seller Seller { get; set; }

        public static List<Ad> ad = new List<Ad>();

        private Ad(string line)
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

            string[] adatok = line.Split(";");
                Area = int.Parse(adatok[4]); //Area
                Category = new Category(int.Parse(adatok[12]), adatok[13]);//Category
                CreateAt = Convert.ToDateTime(adatok[8]);//Created
                Description = adatok[5];//Description
                Floors = int.Parse(adatok[3]);//Floors
                FreeOfCharge = true || adatok[6] == "1";//FreeOfCharge
                Id = int.Parse(adatok[0]);//Id
                ImageUrl = adatok[7];//Url
                LatLong = adatok[2];//LatLong
                Rooms = int.Parse(adatok[1]);//Rooms
                Seller = new Seller(int.Parse(adatok[9]), adatok[10], adatok[11]);//Seller             
        }

        public static List<Ad> LoadFromCSV(string csv)
        {
            string[] sorok = File.ReadAllLines(csv);        
            for (int i = 1; i < sorok.Length; i++)
            {
                ad.Add(new Ad(sorok[i]));                       
            }
            return ad;
        }
    }
}
