using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate
{
    using System.Globalization;

    public class Ad
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Rooms { get; set; }
        public int Area { get; set; }
        public int Floors { get; set; }
        public Category Category { get; set; }
        public Seller Seller { get; set; }
        public bool FreeOfCharge { get; set; }
        public string ImageUrl { get; set; }
        public string LatLong { get; set; }
        public DateTime CreateAt { get; set; }

        public Ad(int id, string description, int rooms, int area, int floors,
            Category category, Seller seller, bool freeOfCharge,
            string imageUrl, string latLong, DateTime createAt)
        {
            Id = id;
            Description = description;
            Rooms = rooms;
            Area = area;
            Floors = floors;
            Category = category;
            Seller = seller;
            FreeOfCharge = freeOfCharge;
            ImageUrl = imageUrl;
            LatLong = latLong;
            CreateAt = createAt;
        }

        public static List<Ad> LoadFromCsv(string fileName)
        {
            var ads = new List<Ad>();
            var lines = File.ReadAllLines(fileName);

            for (int i = 1; i < lines.Length; i++)
            {
                var data = lines[i].Split(';');

                var category = new Category(
                    int.Parse(data[5]),
                    data[6]);   

                var seller = new Seller(
                    int.Parse(data[7]),
                    data[8],
                    data[9]);

                var ad = new Ad(
                    int.Parse(data[0]),
                    data[1],
                    int.Parse(data[2]),
                    int.Parse(data[3]),
                    int.Parse(data[4]),
                    category,
                    seller,
                    bool.Parse(data[10]),
                    data[11],
                    data[12],
                    DateTime.Parse(data[13])
                );

                ads.Add(ad);
            }

            return ads;
        }

        public double DistanceTo(double lat, double lon)
        {
            var coords = LatLong.Split(',');
            double lat1 = double.Parse(coords[0], CultureInfo.InvariantCulture);
            double lon1 = double.Parse(coords[1], CultureInfo.InvariantCulture);

            return Math.Sqrt(
                Math.Pow(lat - lat1, 2) +
                Math.Pow(lon - lon1, 2));
        }
    }}
