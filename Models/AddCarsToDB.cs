using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarDealer.Models
{
    public class AddCarsToDB
    {
        [Required(ErrorMessage = "Year manufactrued !")]
        public int Year { get; set; }
        [Required(ErrorMessage = "Vehicel Make!")]
        public string Make { get; set; }
        [Required(ErrorMessage = "vehicel Model is required!")]
        public string Model { get; set; }
        [Required(ErrorMessage = "Enter vehicel Price USD!")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Enter vehicel exterior color!")]
        public string Color { get; set; }
        [Required(ErrorMessage = "Vehicel Body Style is required!")]
        public string BodyStyle { get; set; }
        [Required(ErrorMessage = "Miles per Gallon is required!")]
        public int Mpg { get; set; }
        [Required(ErrorMessage = "Enter Drive Type !")]
        public string DriveType { get; set; }
        [Required(ErrorMessage = "Enter Miles on vehicel !")]
        public int Miles { get; set; }
        [Required(ErrorMessage = "Enter vehicel is New or Used !")]
        public string NewOrUsed { get; set; }
        [Required(ErrorMessage = "Enter vehicel Capacity !")]
        public int Capacity { get; set; }
        [Required(ErrorMessage = "Enter a unique CarID !")]
        public string CarId { get; set; }

        [Required(ErrorMessage = "Upload a Main Photo !")]
        public byte[] MainPhotoPath { get; set; }
        [Required(ErrorMessage = "Upload a Photo 2 !")]
        public byte[] Photo2 { get; set; }
        [Required(ErrorMessage = "Upload a Photo 3 !")]
        public byte[] Photo3 { get; set; }
        [Required(ErrorMessage = "Upload a Photo 4 !")]
        public byte[] Photo4 { get; set; }

        IList<AddCarsToDB>  addcars { get; set; }
    }
}