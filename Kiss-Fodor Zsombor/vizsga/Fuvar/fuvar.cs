using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuvar
{
    internal class fuvar
    {
        public fuvar(int taxiId, 
            DateTime startTime, 
            int travelTime, 
            float travelledDistance, 
            float cost, 
            float tip, 
            string paymentMethod)
        {
            TaxiId = taxiId;
            StartTime = startTime;
            TravelTime = travelTime;
            TravelledDistance = travelledDistance;
            Cost = cost;
            Tip = tip;
            PaymentMethod = paymentMethod;
        }

        public int TaxiId { get; set; }
        public DateTime StartTime { get; set; }
        public int TravelTime { get; set; }
        public float TravelledDistance { get; set; }
        public float Cost { get; set; }
        public float Tip { get; set; }
        public string PaymentMethod { get; set; }
    }
}
