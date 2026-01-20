using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_feladata
{
    internal class Ad
    {
        public int Area { get; set; }
        public Category Category { get; set; }
        public DateTime CreateAt { get; set; }
        public string Description { get; set; }
        public int Floors { get; set; }
        public string ImageUrl { get; set; }
        public string LatLong { get; set; }
        public int Rooms { get; set; }
        public Seller Seller { get; set; }

        public Ad(int area, Category category, DateTime createAt, string description, int floors, string imageUrl, string latLong, int rooms, Seller seller)
        {
            Area = area;
            Category = category;
            CreateAt = createAt;
            Description = description;
            Floors = floors;
            ImageUrl = imageUrl;
            LatLong = latLong;
            Rooms = rooms;
            Seller = seller;
        }

        static List<Ad> loadCSV(string filePath)
        {
            List<Ad> adatok = new List<Ad>();
            string[] file = File.ReadAllLines(filePath);
            int indexer = 1;
            while (indexer < file.Length) 
            {
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
                Ad house = new Ad(int.Parse(splitLine[4]), new Category(1, "haz"), splitLine[5], );
            }
            return adatok;
        }
    }
}
