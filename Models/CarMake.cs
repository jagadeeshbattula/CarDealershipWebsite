using CarDealer.DataHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace CarDealer.Models
{
    public class CarMake : IPopulateRow
    {
        public string Make { get; set; }

        public void PopulateRow(DataRow dr)
        {
            this.Make = (string)dr["Make"];
        }
    }
}