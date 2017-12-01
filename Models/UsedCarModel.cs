using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealer.Models
{
    public class UsedCarModel
    {
        public IList<CarsData> carsdata { get; set; }

        public List<SelectListItem> carmakes { get; set; }
        public string carmakeselected { get; set; }

        public List<SelectListItem> caryears { get; set;}
        public string caryearselected { get; set; }
    }
}