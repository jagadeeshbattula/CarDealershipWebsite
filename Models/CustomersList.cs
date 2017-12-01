using CarDealer.DataHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CarDealer.Models
{
    public class CustomersList : IPopulateRow
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool ContactByPhone { get; set; }
        public bool ContactByEmail { get; set; }
        public string DateTimeSeen { get; set; }
        public string CarId { get; set; }
        public IList<CustomersList> customerlist { get; set; }


        public void PopulateRow(DataRow dr)
        {
            this.FirstName = (string)dr["FirstName"];
            this.LastName = (string)dr["LastName"];
            this.Phone = (string)dr["Phone"];
            this.Email = (string)dr["Email"];
            this.ContactByPhone = (bool)dr["ContactByPhone"];
            this.ContactByEmail = (bool)dr["ContactByEmail"];
            this.DateTimeSeen = (string)dr["Date"];
            this.CarId = (string)dr["CarId"];
        }
    }
}