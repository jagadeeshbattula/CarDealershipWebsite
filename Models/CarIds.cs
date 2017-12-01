using CarDealer.DataHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CarDealer.Models
{
    public class CarIds : IPopulateRow
    {
        public string CarId { get; set; }

        public IList<CarIds> caridslist { get; set; }

        public void PopulateRow(DataRow dr)
        {
            this.CarId = (string)dr["CarId"];

        }
    }
}