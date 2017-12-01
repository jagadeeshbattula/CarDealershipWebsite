using CarDealer.DataHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealer.Models
{
    public class ServiceApointment
    {

        public List<Locations> locations { get; set; }
        [Required(ErrorMessage = "Select a location !")]
        public string locationselected { get; set; }

        [Required(ErrorMessage = "Choose Vehicel Year !")]
        public int caryearselected { get; set; }
        public List<SelectListItem> caryear { get; set; }

        [Required(ErrorMessage = "Select a Vehicel make !")]
        public string carmakeselected { get; set; }
        public List<SelectListItem> carmake { get; set; }

        [Required(ErrorMessage = "Select a Vehicel model !")]
        public string carmodelselected { get; set; }
        public List<SelectListItem> carmodel { get; set; }


        public bool oilChange { get; set; }
        public bool tyreServices { get; set; } //balancing allignment Rotation
        public bool brakeservices { get; set; }
        public bool emmisionCheckup { get; set; }
        public bool maintenance { get; set; }
        public bool electricalServices { get; set; }
        public bool heatingCoolingServices { get; set; }
        public bool batteryServices { get; set; }
        public bool fluidFlush { get; set; } //transmission filters


        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        [Required(ErrorMessage = "Select a prefered is required.")]
        public DateTime DOB { get; set; }
        [Required(ErrorMessage = "Select prefered time !")]
        public string timeselected { get; set; }


        public List<SelectListItem> timeintervals { get; set; }
        [Required(ErrorMessage = "First Name is required !")]
        public string firstname{get;set;}
        [Required(ErrorMessage = "Last Name is required !")]
        public string lastname { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        public string email { get; set; }
        [Required(ErrorMessage = "Phone is required.")]
        public int phone { get; set; }

        


    }
}