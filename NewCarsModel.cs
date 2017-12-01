using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealer.Models
{
    public class NewCarsModel
    {
        public IList<CarsData> carsdata { get; set; }

        public string carmakeselected { get; set; }
        public List<SelectListItem> carmake { get; set; }

        public string caryearselected { get; set; }
        public List<SelectListItem> caryear { get; set; }

        public IList<PhotoView> photoview { get; set; }

        
    }
}