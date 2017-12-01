using CarDealer.DataHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace CarDealer.Models
{
    public class CarYear: IPopulateRow
    {
        public string Year { get; set; }

        public void PopulateRow(DataRow dr)
        {
            this.Year = (string)dr["Year"];
        }
    }
}