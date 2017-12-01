using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealer.Models
{
    public class CarsData
    {
        public int year { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public int price { get; set; }
        public string color { get; set; }
        public string bodyStyle { get; set; }
        public int mpg { get; set; }
        public string driveType { get; set; }
        public int miles { get; set; }
        public string newOrUsed { get; set; }
        public int capacity { get; set; }
        public string otherOptions { get; set; }
        public string cardId { get; set; }
    }
}