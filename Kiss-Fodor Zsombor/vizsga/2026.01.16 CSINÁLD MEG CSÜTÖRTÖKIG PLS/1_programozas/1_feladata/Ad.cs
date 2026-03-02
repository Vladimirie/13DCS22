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
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string LatLong { get; set; }
        public int Rooms { get; set; }
        public Seller Seller { get; set; }
        public int Free { get; set; }

        public Ad(int area, Category category, DateTime createAt, string description, int floors,int id, string imageUrl, string latLong, int rooms, Seller seller, int free)
        {
            Area = area;
            Category = category;
            CreateAt = createAt;
            Description = description;
            Floors = floors;
            Id = id;
            ImageUrl = imageUrl;
            LatLong = latLong;
            Rooms = rooms;
            Seller = seller;
            Free = Free;
        }

        
    }
}
