using CarDealer.DataHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace CarDealer.Models
{
    public class Locations : IPopulateRow
    {
        public string LocationName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string Country { get; set; }
        public string LocationId { get; set; }
        
        public List<Locations> locationsdata { get; set; }
        public void PopulateRow(DataRow dr)
        {
            this.LocationName = (string)dr["LocationName"];
            this.AddressLine1 = (string)dr["AddressLine1"];
            this.AddressLine2 = (string)dr["AddressLine2"];
            this.City = (string)dr["City"];
            this.State = (string)dr["State"];
            this.Zipcode = (string)dr["Zipcode"];
            this.Country = (string)dr["Country"];
            this.LocationId = (string)dr["LocationId"];
        }
    }
}